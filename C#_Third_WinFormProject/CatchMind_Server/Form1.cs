using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchMind_Server
{
    public partial class Form1 : Form
    {
        Socket acceptSocket;
        IPEndPoint ipep;

        Thread tAccept;
        bool isAccept;


        object keyObj = new object();
        List<Socket> clientList = new List<Socket>();

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.isAccept = false;
                this.acceptSocket.Close();

                // 모든 클라이언트와의 연결을 종료
                closeAllClient();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            this.btn_Start.Enabled = true;
            this.btn_Stop.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.btn_Start.Enabled = true;
            this.btn_Stop.Enabled = false;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            this.acceptSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int port = Int32.Parse(tb_Port.Text);
            this.ipep = new IPEndPoint(IPAddress.Any, port);
            this.acceptSocket.Bind(this.ipep);
            this.acceptSocket.Listen(100);
            Console.WriteLine("서버 시작");

            this.isAccept = true;
            tAccept = new Thread(new ThreadStart(ThreadAccept));
            tAccept.Start();

            this.btn_Start.Enabled = false;
            this.btn_Stop.Enabled = true;
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                this.isAccept = false;
                this.acceptSocket.Close();

                closeAllClient();
            } catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            this.btn_Start.Enabled = true;
            this.btn_Stop.Enabled = false;
        }

        void closeAllClient()
        {
            lock(this.keyObj)
            {
                foreach(Socket clientSocket in clientList)
                {
                    clientSocket.Close();
                }
            }
        }

        void ThreadAccept()
        {
            while(this.isAccept)
            {
                try
                {
                    Console.WriteLine("서버 접속 대기중...");
                    Socket clientSocket = this.acceptSocket.Accept();

                    lock(this.keyObj)
                    {
                        this.clientList.Add(clientSocket);
                    }
                    Console.WriteLine("클라이언트 접속 성공");

                    Thread tRecv = new Thread(new ParameterizedThreadStart(ThreadRecv));
                    tRecv.Start(clientSocket);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception:" + e.Message);
                }
            }

            Console.WriteLine("ThreadAccept 종료 ~");
        }

        void ThreadRecv(object sock)
        {
            Console.WriteLine("클라이언트 담당 스레드 시작 !");
            Socket clientSocket = sock as Socket;

            NetworkStream ns = new NetworkStream(clientSocket);
            StreamReader sr = new StreamReader(ns);

            while(true)
            {
                Monitor.Enter(keyObj);
                try
                {
                    string packet = sr.ReadLine();
                    Console.WriteLine("수신: " + packet);
                    sendAllData(packet);
                }catch(Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                    closeClient(clientSocket);
                    break;
                }
                Monitor.Exit(keyObj);
            }
            Console.WriteLine("ThreadRecv 종료 ~");
        }
        void closeClient(Socket clientSocket)
        {
            lock (this.keyObj)
            {
                foreach(Socket socket in clientList)
                {
                    if(socket == clientSocket)
                    {
                        socket.Close();
                        clientList.Remove(socket);
                        break;
                    }
                }
            }
        }
        void sendAllData(string packet, Socket exceptSocket = null)
        {
            lock (this.keyObj)
            {
                foreach(Socket clientSocket in clientList)
                {
                    if(clientSocket != exceptSocket)
                    {
                        NetworkStream ns = new NetworkStream(clientSocket);
                        StreamWriter sw = new StreamWriter(ns);
                        sw.WriteLine(packet);
                        sw.Flush();
                    }
                }
            }
        }
    }
}

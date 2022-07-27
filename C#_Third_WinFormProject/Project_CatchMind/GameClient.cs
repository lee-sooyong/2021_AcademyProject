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

namespace Project_CatchMind
{
    public partial class GameClient : Form
    {
        Socket clientSocket;
        IPEndPoint ipep;

        const string IP = "127.0.0.1";
        const int PORT = 9000;

        Thread tRecv;
        private bool isRecv;

        delegate void AddMsgLog(string log);
        AddMsgLog addMsgLog = null;

        private int x { get; set; }
        private int y { get; set; }

        private int preX;
        private int preY;
        private int cnt = 0;
        private Point p; //좌표

        public GameClient()
        {
            InitializeComponent();
            this.Size = new Size(1200, 850);
        }

        private void ThreadRecv()
        {
            NetworkStream ns = new NetworkStream(this.clientSocket);
            StreamReader sr = new StreamReader(ns);
            Graphics g = this.CreateGraphics();

            while (this.isRecv)
            {
                try
                {
                    String response = sr.ReadLine();
                    String[] dataArr = response.Split(new char[] { '|' });

                    string data = dataArr[0];
                    switch (data)
                    {
                        case "D":
                            x = Int32.Parse(dataArr[1]);
                            y = Int32.Parse(dataArr[2]);
                            int isStart = Int32.Parse(dataArr[3]);
                            int numColor = Int32.Parse(dataArr[4]);

                            Pen pen = new Pen(Brushes.Black, 3);

                            selectPen(numColor, isStart);

                            preX = x;
                            preY = y;

                            Console.WriteLine("수신: " + response);
                            break;
                        case "C":
                            Console.WriteLine("채팅");
                            string message = dataArr[1];
                            addLogListBox("수신: " + message);
                            Console.WriteLine("수신: " + message);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                    this.isRecv = false;
                    this.clientSocket = null;
                }
            }
            Console.WriteLine("서버 접속 종료~");
        }

        private void btn_Access_Click(object sender, EventArgs e)
        {
            this.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.ipep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            Console.WriteLine("서버 접속 시도");
            this.clientSocket.Connect(this.ipep);
            Console.WriteLine("서버 접속 완료");

            this.isRecv = true;
            tRecv = new Thread(new ThreadStart(ThreadRecv));
            tRecv.Start();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.isRecv = false;
                if (this.clientSocket != null && this.clientSocket.Connected)
                {
                    this.clientSocket.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void GameClient_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                p.X = e.X;
                p.Y = e.Y;

                preX = p.X;
                preY = p.Y;

                if (this.clientSocket != null && this.clientSocket.Connected)
                {
                    NetworkStream ns = new NetworkStream(this.clientSocket);
                    StreamWriter sw = new StreamWriter(ns);
                    object packet = String.Format("D|{0}|{1}|1|{2}", p.X, p.Y, cnt);
                    sw.WriteLine(packet);
                    sw.Flush();
                    Console.WriteLine("송신 : " + packet);
                }
                Console.WriteLine($"p.x : {p.X} p.y : {p.Y}");
            }
        }

        private void GameClient_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            
            if (Capture && e.Button == MouseButtons.Left)
            {
                p.X = e.X; 
                p.Y = e.Y;
                g.Dispose();
            }

            if (this.clientSocket != null && this.clientSocket.Connected)
            {
                object packet = String.Format("D|{0}|{1}|0|{2}", p.X, p.Y, cnt);
                NetworkStream ns = new NetworkStream(this.clientSocket);
                StreamWriter sw = new StreamWriter(ns);
                sw.WriteLine(packet);
                sw.Flush();
                Console.WriteLine("송신 : " + packet);
            }
        }
        private void addLogListBox(string log)
        {
            if (lb_Log.InvokeRequired)
            {
                Invoke(addMsgLog, new object[] { log });
            }
            else
            {
                lb_Log.Items.Add(log);
                lb_Log.SelectedIndex = lb_Log.Items.Count - 1;
            }
        }

        private void tb_SendData_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.clientSocket != null && this.clientSocket.Connected)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        string text = tb_SendData.Text;
                        NetworkStream ns = new NetworkStream(this.clientSocket);
                        StreamWriter sw = new StreamWriter(ns);

                       
                        string data = String.Format("C|{0}", text);

                        sw.WriteLine(data);
                        sw.Flush();
                        addLogListBox("송신 : " + text);
                        break;
                }
            }
            else
            {
                this.tb_SendData.Text = "";
            }
        }

        private void btn_PrintSuggestion_Click(object sender, EventArgs e)
        {
            string[] nature = new string[5] { "백두산", "한강", "아마존강", "폭포", "동굴" };
            string[] stationery = new string[5] { "필통", "지우개", "만년필", "책가방", "색연필" };
            string[] fruit = new string[5] { "멜론", "수박", "참외", "딸기", "키위" };

            string suggestion = "";

            Random rand = new Random();

            int rNum = rand.Next(1, 4);
            int rNum1 = rand.Next(0, 4);

            switch(rNum)
            {
                case 1:
                    suggestion = nature[rNum1];
                    break;
                case 2:
                    suggestion = stationery[rNum1];
                    break;
                case 3:
                    suggestion = fruit[rNum1];
                    break;
            }
            tb_Suggestion.Text = suggestion; 
        }

        private void selectPen(int numColor, int isStart)
        {
            Graphics g = this.CreateGraphics();
            if (numColor == 0)
            {
                if (isStart == 1)
                    g.DrawLine(Pens.Black, x, y, x, y);
                else if (isStart == 0)
                    g.DrawLine(Pens.Black, preX, preY, x, y);
            }
            if (numColor == 1)
            {
                if (isStart == 1)
                    g.DrawLine(Pens.Red, x, y, x, y);
                else if (isStart == 0)
                    g.DrawLine(Pens.Red, preX, preY, x, y);
            }
            if (numColor == 2)
            {
                if (isStart == 1)
                    g.DrawLine(Pens.Blue, x, y, x, y);
                else if (isStart == 0)
                    g.DrawLine(Pens.Blue, preX, preY, x, y);
            }
            if (numColor == 3)
            {
                if (isStart == 1)
                    g.DrawLine(Pens.Green, x, y, x, y);
                else if (isStart == 0)
                    g.DrawLine(Pens.Green, preX, preY, x, y);
            }
            if (numColor == 4)
            {
                if (isStart == 1)
                    g.DrawLine(Pens.Orange, x, y, x, y);
                else if (isStart == 0)
                    g.DrawLine(Pens.Orange, preX, preY, x, y);
            }
            if (numColor == 5)
            {
                if (isStart == 1)
                    g.FillEllipse(Brushes.White, x, y, 10, 10);
                else if (isStart == 0)
                    g.FillEllipse(Brushes.White, x, y, 10, 10);
            }


        }

        private void pb_Black_Click(object sender, EventArgs e)
        {
            this.cnt = 0;
        }

        private void pb_Red_Click(object sender, EventArgs e)
        {
            this.cnt = 1;
        }

        private void pb_Blue_Click(object sender, EventArgs e)
        {
            this.cnt = 2;
        }

        private void pb_Green_Click(object sender, EventArgs e)
        {
            this.cnt = 3;
        }

        private void pb_Yellow_Click(object sender, EventArgs e)
        {
            this.cnt = 4;
        }

        private void pb_Eraser_Click(object sender, EventArgs e)
        {
            this.cnt = 5;
        }

        private void pb_Reset_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
        }
    }
}


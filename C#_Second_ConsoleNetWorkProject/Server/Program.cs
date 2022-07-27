using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

/* Main Thread(전체에서 1개)
       1) 접속 클라이언트와 Accept 처리
       2) 클라이언트 담당 스레드 생성 요청 후
          스레드의 매개변수로 소켓 전달
   Work Thread(클라이언트 당 1개씩 계속 생성)
       1) threadRead 메서드의 동작을 수행
          - 클라이언트의 데이터 수신
          - 수신 데이터 화면에 표시
          - 그리고 다시 수신 대기 */

namespace _114_MultiThreadServer
{
    class Program
    {
        static object keyObj = new object(); //임계영역 동기화 객체
        static List<Socket> socketList = new List<Socket>(); // 소켓 저장

        static Dictionary<string, Socket> idMap = new Dictionary<string, Socket>();
        static Dictionary<Socket, string> socketMap = new Dictionary<Socket, string>();

        const int PORT = 9000;
        static void Main(string[] args)
        {
            /* Ipv4, 연결지향형, 신뢰성(정확성)
               Accept역할 담당 소켓
               휴대폰 */

            Socket serverSocket =
                new Socket(AddressFamily.InterNetwork,
                           SocketType.Stream,
                           ProtocolType.Tcp);
            // 주소(현재 Host IP, PORT에 정의된 숫자)
            // 휴대폰에 부여할 전화번호
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, PORT);

            Console.WriteLine("\n\n                                                                                                   ");
            Console.WriteLine("\t     ▣▣▣▣▣▣    ▣▣▣▣▣▣   ▣▣▣▣▣   ▣              ▣   ▣▣▣▣▣▣    ▣▣▣▣▣        ");
            Console.WriteLine("\t    ▣              ▣              ▣       ▣   ▣            ▣   ▣               ▣       ▣       ");
            Console.WriteLine("\t    ▣              ▣              ▣        ▣   ▣          ▣    ▣               ▣        ▣      ");
            Console.WriteLine("\t    ▣              ▣              ▣       ▣     ▣        ▣     ▣               ▣       ▣       ");
            Console.WriteLine("\t     ▣▣▣▣▣      ▣▣▣▣▣▣   ▣▣▣▣▣       ▣      ▣       ▣▣▣▣▣▣    ▣▣▣▣▣        ");
            Console.WriteLine("\t              ▣    ▣              ▣  ▣            ▣    ▣       ▣               ▣  ▣            ");
            Console.WriteLine("\t              ▣    ▣              ▣    ▣           ▣  ▣        ▣               ▣    ▣          ");
            Console.WriteLine("\t              ▣    ▣              ▣      ▣          ▣▣         ▣               ▣      ▣        ");
            Console.WriteLine("\t   ▣▣▣▣▣▣      ▣▣▣▣▣▣  ▣▣      ▣▣        ▣           ▣▣▣▣▣▣   ▣▣      ▣▣      ");
            Console.WriteLine("\t                                                                                                   ");
            Console.WriteLine("\n\n                                                                                                   ");

            // 소켓에 주소 부여(휴대폰 개통)
            serverSocket.Bind(ipep);
            serverSocket.Listen(100); // 이통사와 연결
            while (true)
            {
                Console.WriteLine("\t\t\t\t\t\t[서버] 접속 대기중...");

                Socket connSocket = serverSocket.Accept();
                Monitor.Enter(keyObj);
                socketList.Add(connSocket);
                Monitor.Exit(keyObj);
                Console.WriteLine("\t\t\t\t\t\t[서버] 클라이언트 접속 연결 ~ ");
                Thread thread =
                    new Thread(new ParameterizedThreadStart(threadRead));
                thread.Start(connSocket);
                Console.WriteLine("\t\t\t\t\t\t[서버] 클라이언트 스레드 담당 ~ ");
            }
        }

        static void threadRead(object sock)
        {
            Socket connSocket = (Socket)sock;
            NetworkStream ns = new NetworkStream(connSocket);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);


            try
            {
                bool isRun = true;
                while (isRun)
                {

                    String strMsg = sr.ReadLine();
                    Console.WriteLine("\t\t\t\t\t\t  :" + strMsg);

                    isRun = processPacket(strMsg, connSocket, sw, sr);

                    if (strMsg == null)
                        break;
                }
            }
            catch (Exception e) // 예외 발생 시 여기로 점프
            {
                Console.WriteLine(e.Message);
            }
            finally // 정상, 예외 모두 무조건 최종 실행되는 구문
            {

                removeRegisterSocket(connSocket);

                Console.WriteLine("\t\t\t\t\t\t[서버] 클라이언트 접속 종료...");
                if (sr != null) sr.Close();
                if (ns != null) ns.Close();
                if (connSocket != null)
                    connSocket.Close();
            }
        }
        static void removeRegisterSocket(Socket connSocket)
        {
            Monitor.Enter(keyObj);

            socketList.Remove(connSocket);

            string id = socketMap[connSocket];

            socketMap.Remove(connSocket);
            idMap.Remove(id);

            Monitor.Exit(keyObj);
        }
        static bool processPacket(String strPacket, Socket connSocket,
                            StreamWriter sw, StreamReader sr)
        {
            bool isRun = true;
            String[] dataArr =
                 strPacket.Split(new char[] { '|' });
            string id = "";
            string cmd = dataArr[0];
            string subCmd = "";
            switch (cmd)
            {
                case "I":
                    id = dataArr[1];
                    Console.WriteLine("\t\t\t\t\t\t[관리자] 클라이언트 id 수신 : " + id);
                    moveListToMap(connSocket, id);
                    break;
                case "C":
                    subCmd = dataArr[1];
                    if (subCmd == "E")
                    {
                        bool isEnable = isChatting(connSocket);
                        if (isEnable)
                            sw.WriteLine("C|O");
                        else
                            sw.WriteLine("C|F");
                        sw.Flush();

                    }
                    else if (subCmd == "M")
                    {
                        bool isEnable = isChatting(connSocket);
                        if (isEnable)
                        {
                            string msg = dataArr[2];
                            sendAllMsg(msg, connSocket);
                        }
                        else
                        {
                            sw.WriteLine("C|F");
                            sw.Flush();
                        }
                    }
                    break;
                case "E":
                    Console.WriteLine("\t\t\t\t\t\t[서버] 클라이언트 종료 요청");
                    isRun = false;
                    break;
            }
            return isRun;

        }
        static void moveListToMap(Socket connSocket, string id)
        {
            Monitor.Enter(keyObj);
            socketList.Remove(connSocket);
            idMap.Add(id, connSocket);
            socketMap.Add(connSocket, id);
            Monitor.Exit(keyObj);
        }

        static bool isChatting(Socket connSocket)
        {
            bool isEnable = true;
            Monitor.Enter(keyObj);
            foreach (Socket socket in socketList)
            {
                if (socket == connSocket)
                {
                    isEnable = false;
                    break;
                }
            }
            Monitor.Exit(keyObj);

            return isEnable;
        }
        static void sendAllMsg(String strMsg, Socket exceptionSocket)
        {
            Monitor.Enter(keyObj);

            string sendId = socketMap[exceptionSocket];

            foreach (var data in idMap)
            {
                string id = data.Key;
                Socket socket = data.Value;
                if (id != sendId)
                {
                    NetworkStream ns = new NetworkStream(socket);
                    StreamWriter sw = new StreamWriter(ns);
                    sw.WriteLine(String.Format("C|M|[{0}] {1}", sendId, strMsg));
                    sw.Flush();
                }
            }

            Monitor.Exit(keyObj);
        }
    }
}

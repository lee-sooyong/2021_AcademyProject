using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SignUp
{
    class Menu
    {
        public const int ID = 1;
        public const int CHATTING = 2;
        public const int EXIT = 3;
    }
    class CHAT_MODE
    {
        public const int CHATTING = 1;

    }
    class ChattingClient
    {
        static string myId = "";
        static int chatMode = 0;
        
       
        const string IP = "192.168.0.8";
        const int PORT = 9000;

        static Socket clientSocket = null;
        static IPEndPoint ipep = null;
        public void Chat()
        {
      
            clientSocket =
                new Socket(AddressFamily.InterNetwork,
                           SocketType.Stream,
                           ProtocolType.Tcp);

            ipep =
                new IPEndPoint(IPAddress.Parse(IP), PORT);

          
            clientSocket.Connect(ipep);
            
           

            // 4. 서버에 데이터 전송
           

            Console.WriteLine("\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t ▣▣▣  ▣  ▣   ▣▣  ▣▣▣ ▣▣▣  ▣▣▣  ▣▣    ▣   ▣▣▣     ");
            Console.WriteLine("\t\t\t\t▣       ▣  ▣  ▣  ▣   ▣     ▣      ▣    ▣ ▣   ▣  ▣       ");
            Console.WriteLine("\t\t\t\t▣       ▣▣▣  ▣▣▣   ▣     ▣      ▣    ▣  ▣  ▣  ▣  ▣▣      ");
            Console.WriteLine("\t\t\t\t▣       ▣  ▣  ▣  ▣   ▣     ▣      ▣    ▣   ▣ ▣  ▣   ▣       ");
            Console.WriteLine("\t\t\t\t ▣▣▣  ▣  ▣  ▣  ▣   ▣     ▣    ▣▣▣  ▣    ▣▣   ▣▣▣          ");
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t\t\t\t채팅 접속은 ENTER  >> ");
            Console.ReadKey();
            menuLoop();

            // 5. 접속 종료
            //clientSocket.Close();
        }
        static void menuLoop()
        {
            bool isRun = true;
            while (isRun)
            {
                clearScreen();
                showMenu();
                int sel = getSelMenu();

                switch (sel)
                {
                    case Menu.ID:
                        runId(clientSocket);
                        break;
                    case Menu.CHATTING:
                        runChatting(clientSocket);
                        break;
                    case Menu.EXIT:
                        runExit(clientSocket);
                        isRun = false;
                        clientSocket.Close();
                        break;
                }
            }
        }
        static void showMenu()
        {
            Console.WriteLine("\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t[exit] 입력 시 종료");
            Console.WriteLine("\t\t\t\t\t\t1. ID 입력");
            Console.WriteLine("\t\t\t\t\t\t2. 채팅");
            Console.WriteLine("\t\t\t\t\t\t3. 종료");
            Console.WriteLine();
        }

        static void clearScreen()
        {
            Console.Clear();
        }

        static int getSelMenu()
        {
            Console.Write("\t\t\t\t\t\tselect Menu >> ");
            int sel = Int32.Parse(Console.ReadLine());
            return sel;
        }
        static void runId(Socket clientSocket)
        {
            Console.Write("\t\t\t\t\t\tID 입력하세요 >> ");
            String id = Console.ReadLine();
            myId = id;      // static 멤버로 id를 기억해 놓음

            String packet =
                String.Format("I|{0}", id);

            NetworkStream ns = new NetworkStream(clientSocket);
            StreamWriter sw = new StreamWriter(ns);
            sw.WriteLine(packet);
            sw.Flush();
        }
        static void runChatting(Socket clientSocket)
        {
            String packet = "C|E";

            NetworkStream ns = new NetworkStream(clientSocket);
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);
            sw.WriteLine(packet);
            sw.Flush();
            String response = sr.ReadLine();
            String[] dataArr = response.Split(new char[] { '|' });
            String mainCmd = dataArr[0];
            String subCmd = dataArr[1];
            if (mainCmd == "C")
            {
                if (subCmd == "O")
                {
                    chatMode = CHAT_MODE.CHATTING;
                    Thread thread = new Thread(new ParameterizedThreadStart(threadRead));
                    thread.Start(clientSocket);

                    while (true)
                    {
                        //Console.Write($"{myId}: ");
                        String msg = Console.ReadLine();
                        if (msg == "[exit]")
                            break;
                        packet = String.Format("C|M|{0}", msg);
                        sw.WriteLine(packet);
                        sw.Flush();
                    }
                    clientSocket.Close();
                }
                else if (subCmd == "F")
                {
                    Console.WriteLine("\t\t\t\t\t\tid를 입력해야 채팅이 가능합니다\n");
                    Console.ReadKey();
                }
            }
        }
        static void runExit(Socket clientSocket)
        {
            String packet = "E|";

            NetworkStream ns = new NetworkStream(clientSocket);
            StreamWriter sw = new StreamWriter(ns);
            sw.WriteLine(packet);
            sw.Flush();
        }

        static void processChat(string msg)
        {
            string[] dataArr = msg.Split(new char[] { '|' });
            string mainCmd = dataArr[0];
            string subCmd = dataArr[1];
            
            switch (mainCmd)
            {

                case "C":
                    if (subCmd == "M")
                    {
                        Console.WriteLine(dataArr[2]);
                    }
                    break;
                case "W":
                    if (subCmd == "M")
                    {
                        Console.WriteLine(dataArr[2]);
                    }
                    break;
            }
        }
        static void threadRead(object sock)
        {

            Socket clientSocket = (Socket)sock;
            NetworkStream ns = new NetworkStream(clientSocket);
            StreamReader sr = new StreamReader(ns);


            try
            {
                while (true)
                {

                    String strMsg = sr.ReadLine();
                    processChat(strMsg);

                }

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);

            }
            finally
            {
                Console.WriteLine("\t\t\t\t\t\t[클라이언트] : 서버 접속 종료");
                if (sr != null) sr.Close();
                if (ns != null) ns.Close();
                if (clientSocket != null) clientSocket.Close();

                reConnectById();
            }


        }
        static void reConnectById()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork,
                             SocketType.Stream,
                             ProtocolType.Tcp);

            ipep = new IPEndPoint(IPAddress.Parse(IP), PORT);

            clientSocket.Connect(ipep);

            String packet = String.Format("I|{0}", myId);

            NetworkStream ns = new NetworkStream(clientSocket);
            StreamWriter sw = new StreamWriter(ns);
            sw.WriteLine(packet);
            sw.Flush();

            //Console.WriteLine();
            //showMenu();
            //Console.Write("select Menu >> ");
        }
    }
}

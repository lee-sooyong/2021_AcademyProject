using SignUp.게시판;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp
{
    class LoginMenu
    {
        TimestampMenu timestampMenu = new TimestampMenu();
        ChattingClient chattingClient = new ChattingClient();
        CommunityMenu communityMenu = new CommunityMenu();

        public void main2Loop()
        {
            bool isRun = true;

            while (isRun)
            {
                clearScreen();
                printMenu2();
                int sel = selectMenu2();

                clearScreen();
                switch (sel)
                {
                    case 1:
                        communityMenu.mainLoop();
                        break;
                    case 2:
                        timestampMenu.main4Loop();
                        break;
                    case 3:
                        chattingClient.Chat();
                        break;
                    case 4:
                        programExit();
                        isRun = false;
                        break;
                    default:
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("잘못 입력하셨습니다.");
                        System.Threading.Thread.Sleep(500);
                        continue;
                }
            }
        }
        public void printMenu2()
        {
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\t\t\t\t▣▣     ▣▣  ▣▣▣▣  ▣▣    ▣  ▣▣  ▣▣  ");
            Console.WriteLine("\t\t\t\t▣ ▣   ▣ ▣  ▣        ▣ ▣   ▣   ▣    ▣");
            Console.WriteLine("\t\t\t\t▣  ▣ ▣  ▣  ▣▣▣    ▣  ▣  ▣   ▣    ▣ ");
            Console.WriteLine("\t\t\t\t▣   ▣    ▣  ▣        ▣   ▣ ▣   ▣    ▣  ");
            Console.WriteLine("\t\t\t\t▣   ▣    ▣  ▣▣▣▣  ▣    ▣▣    ▣▣▣  ");
            Console.ResetColor();
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t\t\t===============");
            Console.WriteLine("\t\t\t\t\t\t1. 게시판");
            Console.WriteLine("\t\t\t\t\t\t2. 타임스탬프");
            Console.WriteLine("\t\t\t\t\t\t3. 채팅방");
            Console.WriteLine("\t\t\t\t\t\t4. 돌아가기");
            Console.WriteLine("\t\t\t\t\t\t===============");
        }

        public int selectMenu2()
        {
            int sel = 0;

            Console.Write("\t\t\t\t\t\t메뉴 선택 >> ");
            sel = Int32.Parse(Console.ReadLine());

            return sel;
        }

        public static void clearScreen()
        {
            Console.Clear();
        }

        public void programExit()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t\t ▣▣▣   ▣▣  ▣▣  ▣▣▣");
            Console.WriteLine("\t\t\t\t\t\t▣    ▣   ▣    ▣     ▣");
            Console.WriteLine("\t\t\t\t\t\t▣    ▣   ▣    ▣     ▣");
            Console.WriteLine("\t\t\t\t\t\t ▣▣▣     ▣▣▣      ▣");
            Console.WriteLine("\n\n");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}

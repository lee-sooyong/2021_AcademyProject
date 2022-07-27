using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp.게시판
{
    class CommunityMenu
    {
        CommunityManager communityManager = new CommunityManager();

        public void mainLoop()
        {
            communityManager.initCommunity();

            bool isRun = true;

            while (isRun)
            {
                clearScreen();
                printMenu();
                int sel = selectMenu();

                clearScreen();
                switch(sel)
                {
                    case 1:
                        communityManager.insertCommunity();
                        break;
                    case 2:
                        communityManager.printFreeCommunity();
                        break;
                    case 3:
                        communityManager.printNoticeCommunity();
                        break;
                    case 4:
                        communityManager.printEventCommunity();
                        break;
                    case 5:
                        communityManager.programExit();
                        isRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void printMenu()
        {
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t\t ▣▣▣   ▣▣    ▣▣    ▣▣ ▣▣    ▣▣  ▣▣  ▣▣ ▣▣   ▣  ▣▣ ▣▣▣  ▣    ▣");
            Console.WriteLine("\t\t▣      ▣    ▣  ▣ ▣  ▣ ▣ ▣ ▣  ▣ ▣   ▣    ▣  ▣ ▣  ▣   ▣    ▣     ▣  ▣");
            Console.WriteLine("\t\t▣      ▣    ▣  ▣ ▣  ▣ ▣ ▣ ▣  ▣ ▣   ▣    ▣  ▣  ▣ ▣   ▣    ▣       ▣");
            Console.WriteLine("\t\t ▣▣▣   ▣▣    ▣  ▣▣  ▣ ▣  ▣▣  ▣    ▣▣▣   ▣   ▣▣  ▣▣   ▣       ▣");
            Console.ResetColor();
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t\t\t==================");
            Console.WriteLine("\t\t\t\t\t\t1. 게시글 입력");
            Console.WriteLine("\t\t\t\t\t\t2. 자유게시판 검색");
            Console.WriteLine("\t\t\t\t\t\t3. 공지사항 검색");
            Console.WriteLine("\t\t\t\t\t\t4. 이벤트 검색");
            Console.WriteLine("\t\t\t\t\t\t5. 종료");
            Console.WriteLine("\t\t\t\t\t\t==================");
        }

        public int selectMenu()
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
    }
}

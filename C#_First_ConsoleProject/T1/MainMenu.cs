using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    class MainMenu
    {
        GaligiManager galigimanager = new GaligiManager(); // 클라스 끌어올때 공간확보

        public void mainLoop()
        {
            galigimanager.loadDate(); //시작을 하면서 저장된 데이터를 로드
            bool isRun = true;
            while (isRun)
            {
                clearScreen();
                printMenu();
                int sel = selectMenu();

                clearScreen();

                printMenu();
                Console.Clear();

                switch (sel)
                {
                    case 1:
                        galigimanager.GaligiGame(); //"1. 게임 시작" 게임이 끝난 후 정보 저장
                        break;
                    case 2:
                        Console.WriteLine("------------기록------------");
                        galigimanager.showData();       //게임 기록                                    //"2. 게임 랭킹
                        Console.ReadKey();
                        break;
                    case 3:
                        galigimanager.deleteRank();
                        break;                           //"3. 랭킹 리셋"
                    case 4:
                        galigimanager.gameExit();
                        isRun = false;
                                                        // 프로그램 종료
                        break;

                    default:
                        Console.WriteLine("잘못 입력하셨습니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void printMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(44, 8);
            Console.WriteLine("TALIGI");
            Console.SetCursorPosition(44, 9);
            Console.WriteLine("=================");
            //Console.WriteLine("1. 게임 시작");
            //Console.WriteLine("2. 게임 기록");
            //Console.WriteLine("3. 기록 리셋");
            //Console.WriteLine("4. 종료");
            Console.SetCursorPosition(44, 10);
            Console.WriteLine("1.게임 시작");
            Console.SetCursorPosition(44, 11);
            Console.WriteLine("2.전체 기록");
            Console.SetCursorPosition(44, 12);
            Console.WriteLine("3.기록 초기화");
            Console.SetCursorPosition(44, 13);
            Console.WriteLine("4.나가기");
            Console.SetCursorPosition(44, 14);
            Console.WriteLine("=================");
            Console.SetCursorPosition(44, 15);
            Console.Write("메뉴 선택 >> ");
        }
        public int selectMenu()
        {
            int sel = 0;
            sel = Int32.Parse(Console.ReadLine());
            Console.SetCursorPosition(58, 15);

            return sel;
        }

        public static void clearScreen()
        {
            Console.Clear();
        }

       

        
    }
}   

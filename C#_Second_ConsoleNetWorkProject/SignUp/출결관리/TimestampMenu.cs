using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SignUp
{
    class TimestampMenu
    {
        TimestampManager timestampManager = new TimestampManager();

        public void main4Loop()
        {
            bool isRun = true;

            while (isRun)
            {
                clearScreen();
                printMenu();
                int sel = selectMenu();

                clearScreen();
                switch (sel)
                {
                    case 1:
                        timestampManager.insertSingup();
                        break;
                    case 2:
                        timestampManager.insertSingup2();
                        break;
                    case 3:
                        timestampManager.printAllTime();
                        //timestampManager.printAllTime1();
                        Console.WriteLine();
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
    
        public void printMenu()
        {
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t\t\t\t ▣▣▣   ▣▣   ▣         ▣▣▣   ▣▣▣ ▣▣▣");
            Console.WriteLine("\t\t\t\t▣    ▣  ▣ ▣  ▣        ▣    ▣  ▣     ▣");
            Console.WriteLine("\t\t\t\t▣    ▣  ▣  ▣ ▣        ▣    ▣  ▣▣   ▣▣");
            Console.WriteLine("\t\t\t\t ▣▣▣   ▣   ▣▣         ▣▣▣   ▣     ▣");
            Console.ResetColor();
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t\t\t================");
            Console.WriteLine("\t\t\t\t\t\t1. 출근");
            Console.WriteLine("\t\t\t\t\t\t2. 퇴근");
            Console.WriteLine("\t\t\t\t\t\t3. 출퇴근 확인");
            Console.WriteLine("\t\t\t\t\t\t4. 나가기");
            Console.WriteLine("\t\t\t\t\t\t================");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp
{
    class SignUpMenu
    {
        SignUpManager signupManager = new SignUpManager();
        LoginManager loginManager = new LoginManager();

        public void mainLoop()
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
                        loginManager.Login();
                        break;
                    case 2:
                        signupManager.insertSingup();
                        break;
                    case 3:
                        signupManager.printAllSignUp();
                        break;
                    case 4:
                        Console.WriteLine("\n\n\n\n\n\n\n\n\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\t\t\t▣▣▣▣▣    ▣      ▣    ▣▣▣▣▣                                ▣▣  ▣▣");
                        Console.WriteLine("\t\t\t▣      ▣     ▣    ▣    ▣                  ▣▣▣       ▣      ▣   ▣▣   ▣");
                        Console.WriteLine("\t\t\t▣     ▣       ▣  ▣     ▣                 ▣    ▣       ▣    ▣            ▣");
                        Console.WriteLine("\t\t\t▣  ▣▣         ▣▣      ▣▣▣▣          ▣       ▣    ▣     ▣            ▣");
                        Console.WriteLine("\t\t\t▣     ▣         ▣       ▣                 ▣       ▣▣▣       ▣          ▣");
                        Console.WriteLine("\t\t\t▣      ▣        ▣       ▣                                        ▣        ▣");
                        Console.WriteLine("\t\t\t▣▣▣▣▣        ▣        ▣▣▣▣▣                                ▣▣▣▣▣");
                        Console.WriteLine("\t\t\t                                                                       ▣▣▣▣");
                        Console.WriteLine("\t\t\t                                                                         ▣▣");
                        Console.WriteLine("\t\t\t                                                                          ▣");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t▣▣▣▣▣▣＼ ▣▣▣▣▣▣＼ ▣▣▣▣▣▣＼    ▣▣▣＼     ▣▣＼     ▣▣▣＼_ ▣▣▣＼  ▣▣▣▣▣＼");
            Console.ResetColor();
            Console.WriteLine("\t▣  ____  ▣ | ＼___▣  ____| ＼___▣  ____|  ▣ ______/    ▣  ▣ ＼   ▣ __▣  ▣ __▣ |  ▣   ___▣ |");
            Console.WriteLine("\t▣ /___/▣ __/      ▣ |           ▣ |     ▣  /          ▣ ___▣  |  ▣ | ▣  ▣ | ▣ |  ▣  |   ▣ |");
            Console.WriteLine("\t▣  ▣▣ 〈         ▣ |           ▣ |     ▣ |          ▣ |    ▣ |  ▣ | ▣  ▣ | ▣ |  ▣▣▣▣__/");
            Console.WriteLine("\t▣  ___ ▣ ＼       ▣ |___        ▣ |     ▣ ＼_____    ▣▣▣▣▣ |  ▣ | ▣  ▣ | ▣ |  ▣  __/");
            Console.WriteLine("\t▣ ＼___」▣ |      ▣     ＼      ▣ |     | ▣      ＼  ▣  ____▣ |  ▣ | ▣  ▣ | ▣ |  ▣  |");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t▣▣▣▣▣▣ | ▣▣▣▣▣▣ |      ▣ |      ＼ ▣▣▣ |  ▣ |    ▣ |  ▣ |  ▣▣  | ▣ | ▣▣ |");
            Console.WriteLine("\t＼___________/ ＼___________/      ＼_/        ＼______/  ＼_|    ＼_|  ＼_|  ＼___/  ＼_/ ＼___/  ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nㅁㅁㅁ  ㅁㅁㅁ   ㅁㅁㅁ    ㅁㅁ    ㅁㅁ  ㅁ  ㅁㅁㅁ            ㅁㅁㅁㅁ ㅁㅁㅁㅁ    ㅁㅁ  ㅁㅁㅁ ㅁㅁㅁ  ㅁㅁㅁ  ㅁㅁㅁ");
            Console.ResetColor();
            Console.WriteLine("ㅁ      ㅁ      ㅁ       ㅁ   ㅁ   ㅁ ㅁ ㅁ  ㅁ   ㅁ            ㅁ   ㅁ ㅁ    ㅁ  ㅁ   ㅁ    ㅁ ㅁ     ㅁ          ㅁ");
            Console.WriteLine("ㅁ      ㅁ      ㅁ      ㅁ     ㅁ  ㅁ ㅁ ㅁ  ㅁ    ㅁ           ㅁ  ㅁ  ㅁ    ㅁ ㅁ     ㅁ   ㅁ ㅁ     ㅁ          ㅁ");
            Console.WriteLine("ㅁㅁㅁ  ㅁㅁㅁ  ㅁ      ㅁ     ㅁ  ㅁ ㅁ ㅁ  ㅁ    ㅁ           ㅁㅁ    ㅁㅁㅁㅁ ㅁ     ㅁ   ㅁ ㅁㅁㅁ ㅁ          ㅁ");
            Console.WriteLine("    ㅁ  ㅁ      ㅁ      ㅁ     ㅁ  ㅁ ㅁ ㅁ  ㅁ    ㅁ           ㅁ      ㅁ  ㅁ   ㅁ     ㅁ   ㅁ ㅁ     ㅁ          ㅁ");
            Console.WriteLine("    ㅁ  ㅁ      ㅁ       ㅁ   ㅁ   ㅁ ㅁ ㅁ  ㅁ   ㅁ            ㅁ      ㅁ   ㅁ   ㅁ   ㅁ ㅁ ㅁ ㅁ     ㅁ          ㅁ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("ㅁㅁㅁ  ㅁㅁㅁ   ㅁㅁㅁ    ㅁㅁ    ㅁ  ㅁㅁ  ㅁㅁㅁ            ㅁㅁ     ㅁ     ㅁ   ㅁㅁ    ㅁ   ㅁㅁㅁ  ㅁㅁㅁ    ㅁ");
            Console.ResetColor();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t==============");
            Console.WriteLine("\t\t\t\t\t\t1. 로그인");
            Console.WriteLine("\t\t\t\t\t\t2. 회원가입");
            Console.WriteLine("\t\t\t\t\t\t3. 회원목록");
            Console.WriteLine("\t\t\t\t\t\t4. App 종료");
            Console.WriteLine("\t\t\t\t\t\t==============");
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

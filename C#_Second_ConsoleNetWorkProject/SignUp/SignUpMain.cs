using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp
{
    class SignUpMain
    {
        static void Main(string[] args)
        {

            while (true)
            {
                    int x = 52, y = 20;
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

                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.WriteLine("환영합니다.");
                    Console.WriteLine("\n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\t\t\t\t\t\t*아무 키를 누르세요*");
                    Console.ResetColor();
                    Console.ReadKey();
                    SignUpMenu Menu = new SignUpMenu();
                    Menu.mainLoop();
                    break;
                }
            }
        }
        
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp
{
    class TimestampPage
    {
        public string Attend { get; set; }
        public string Lle { get; set; }
        public string Name { get; set; }

        public void showInfo(int board)
        {
            Console.WriteLine("\t\t\t\t\t--------------- {0} ----------------", board);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t\t\t\t\t이름 : " + this.Name);
            Console.ResetColor();
            Console.Write("\t\t\t\t\t출근 : " + this.Attend);
            Console.WriteLine();
        }

        public void showInfo1(int board)
        {
            Console.Write("\t\t\t\t\t퇴근 : " + this.Lle);
            Console.WriteLine();
        }

        /*public void showInfo()
        {
            Console.WriteLine("출근 : " + this.Attend);
            Console.WriteLine("퇴근 : " + this.Lle);
        }*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp.게시판
{
    class Community
    {
        public string Title { get; set; }
        public string Contents { get; set; }

        public virtual void showInfo(int order)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("=======================================================================================================================");
            Console.ResetColor();
            Console.WriteLine("\t\t\t\t\t\t제목: " + this.Title);
            Console.WriteLine("\t\t\t\t\t\t내용: " + this.Contents);
        }

        public virtual void showInfo()
        {
            Console.WriteLine("\t\t\t\t\t\t제목: " + this.Title);
            Console.WriteLine("\t\t\t\t\t\t내용: " + this.Contents);
        }
    }
}

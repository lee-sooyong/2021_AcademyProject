using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp.게시판
{
    class NoticeCommunity : Community
    {
        public string Notice { get; set; }

        public override void showInfo(int order)
        {
            base.showInfo(order);
            Console.WriteLine("\t\t\t\t\t\t공지사항: " + this.Notice);
        }

        public override void showInfo()
        {
            base.showInfo();
            Console.WriteLine("\t\t\t\t\t\t공지사항: " + this.Notice);
        }
    }
}

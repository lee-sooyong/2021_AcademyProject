using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp.게시판
{
    class EventCommunity : Community
    {
        public string Event { get; set; }

        public override void showInfo(int order)
        {
            base.showInfo(order);
            Console.WriteLine("\t\t\t\t\t\t이벤트: " + this.Event);
        }

        public override void showInfo()
        {
            base.showInfo();
            Console.WriteLine("\t\t\t\t\t\t이벤트: " + this.Event);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    class GaligiInfo
    { 
        public string Name { get; set; }
        public double Time { get; set; }


       

        public void showInfo()
        {
            Console.WriteLine("이름 : " + this.Name);
            Console.WriteLine("시간 :{0:0.##}초",this.Time);
            Console.WriteLine("");
        }


    }
}

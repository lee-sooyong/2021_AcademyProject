using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp
{
    class SignUp
    {
        public string Id { get; set; }
        public string Pw { get; set; }
        public string Name { get; set; }
        public string Ssn { get; set; }
        public string Phone { get; set; }

        public void showInfo(int order)
        {
            Console.WriteLine("\t\t\t\t\t\t------ {0} ------", order);
            Console.WriteLine("\t\t\t\t\t\t아이디: " + this.Id);
            //Console.WriteLine("비밀번호: " + this.Pw);
            Console.WriteLine("\t\t\t\t\t\t이름: " + this.Name);
            //Console.WriteLine("주민번호: " + this.Ssn);
            Console.WriteLine("\t\t\t\t\t\t전화번호: " + this.Phone);
            Console.WriteLine();
        }

        public void showInfo()
        {
            Console.WriteLine("아이디: " + this.Id);
            Console.WriteLine("비밀번호: " + this.Pw);
            Console.WriteLine("이름: " + this.Name);
            Console.WriteLine("주민번호: " + this.Ssn);
            Console.WriteLine("전화번호: " + this.Phone);
        }
    }
}

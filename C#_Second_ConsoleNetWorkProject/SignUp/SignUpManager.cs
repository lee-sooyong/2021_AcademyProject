using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp
{
    class SignUpManager
    {
        SignUpDao signupDao = new SignUpDao();

        public void insertSingup()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t▣▣▣▣  ▣▣▣    ▣▣▣    ▣▣   ▣  ▣▣  ▣▣ ▣▣▣▣");
            Console.WriteLine("\t\t\t\t▣          ▣    ▣          ▣ ▣  ▣   ▣    ▣  ▣    ▣");
            Console.WriteLine("\t\t\t\t▣▣▣▣    ▣    ▣    ▣▣  ▣  ▣ ▣   ▣    ▣  ▣▣▣▣");
            Console.WriteLine("\t\t\t\t      ▣    ▣    ▣     ▣   ▣  ▣ ▣   ▣    ▣  ▣   ");
            Console.WriteLine("\t\t\t\t▣▣▣▣  ▣▣▣    ▣▣▣    ▣   ▣▣    ▣▣▣   ▣");
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t\t\t==== 회원정보 입력 ====");
            Console.Write("\t\t\t\t\t\t아이디 입력 >> ");
            string id = Console.ReadLine();
            Console.Write("\t\t\t\t\t\t비밀번호 입력 >> ");
            string pw = Console.ReadLine();
            Console.Write("\t\t\t\t\t\t이름 입력 >> ");
            string name = Console.ReadLine();
            Console.Write("\t\t\t\t\t\t주민번호 입력 >> ");
            string ssn = Console.ReadLine();
            Console.Write("\t\t\t\t\t\t전화번호 입력 >> ");
            string phone = Console.ReadLine();
            Console.Write("\t\t\t\t\t\t=================");

            SignUp signup = new SignUp();
            signup.Id = id;
            signup.Pw = pw;
            signup.Name = name;
            signup.Ssn = ssn;
            signup.Phone = phone;

            signupDao.insertSignUp(signup);
        }

        public void printAllSignUp()
        {
            ArrayList arrList = signupDao.searchAllSignUp();
            for (int i = 0; i < arrList.Count; i++)
            {
                    SignUp signup = (SignUp)arrList[i];
                    signup.showInfo(i + 1);   
            }
            Console.ReadLine();
        }
    }
}


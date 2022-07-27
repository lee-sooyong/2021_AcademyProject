using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SignUp
{
    class TimestampManager
    {
        TimestampDao timestampDao = new TimestampDao();

        public void insertSingup()
        {
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t ▣▣▣   ▣▣   ▣");
            Console.WriteLine("\t\t\t\t\t\t▣    ▣  ▣ ▣  ▣");
            Console.WriteLine("\t\t\t\t\t\t▣    ▣  ▣  ▣ ▣");
            Console.WriteLine("\t\t\t\t\t\t ▣▣▣   ▣   ▣▣ ");
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t\t\t============");
            Console.Write("\t\t\t\t\t\t출근자명 입력: ");
            string gowork1 = Console.ReadLine();
            string gowork = DateTime.Now.ToString("yyyy년 MM월 dd일 HH시 mm분");

            TimestampPage timestampPage = new TimestampPage();

            timestampPage.Name = gowork1;
            timestampPage.Attend = gowork;
            timestampDao.insertSignUp(timestampPage);
        }

        public void insertSingup2()
        {
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t ▣▣▣   ▣▣▣ ▣▣▣");
            Console.WriteLine("\t\t\t\t\t\t▣    ▣  ▣     ▣");
            Console.WriteLine("\t\t\t\t\t\t▣    ▣  ▣▣   ▣▣");
            Console.WriteLine("\t\t\t\t\t\t ▣▣▣   ▣     ▣");
            Console.WriteLine("\n");
            string goend = DateTime.Now.ToString("yyyy년 MM월 dd일 HH시 mm분");

            TimestampPage timestampPage = new TimestampPage();

            timestampPage.Lle = goend;
            timestampDao.insertSignUp2(timestampPage);
        }

        public void printAllTime()
        {
            ArrayList arrList = timestampDao.searchAllTime();
            ArrayList arrList1 = timestampDao.searchAllTime1();
            for (int i = 0; i < arrList.Count; i++)
            {
                TimestampPage TimePage = (TimestampPage)arrList[i];
                TimePage.showInfo(i + 1);
                TimestampPage TimePage1 = (TimestampPage)arrList1[i];
                TimePage1.showInfo1(i + 1);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        /*public void printAllTime1()
        {
            ArrayList arrList = timestampDao.searchAllTime1();
            for (int i = 0; i < arrList.Count; i++)
            {
                TimestampPage TimePage = (TimestampPage)arrList[i];
                TimePage.showInfo1(i + 1);
            }
            Console.ReadLine();
        }*/
    }
}

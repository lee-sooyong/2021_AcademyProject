using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp.게시판
{
    class CommunityManager
    {
        ArrayList arrList = new ArrayList();
        CommunityFile communityFile = new CommunityFile();

        public void initCommunity()
        {
            communityFile.loadFileCommunity(arrList);
        }

        public void insertCommunity()
        {
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t▣▣▣ ▣▣▣ ▣▣▣ ▣      ▣▣▣");
            Console.WriteLine("\t\t\t\t\t  ▣     ▣     ▣   ▣      ▣");
            Console.WriteLine("\t\t\t\t\t  ▣     ▣     ▣   ▣      ▣▣▣");
            Console.WriteLine("\t\t\t\t\t  ▣     ▣     ▣   ▣      ▣");
            Console.WriteLine("\t\t\t\t\t  ▣   ▣▣▣   ▣   ▣▣▣  ▣▣▣");
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t\t-----------------------------------");
            Console.WriteLine("\t\t\t\t\t\t" + "--- 게시판 선택 ---");
            Console.Write("\t\t\t\t\t1. 자유   2. 공지   3. 이벤트 >> ");
            int sel = Int32.Parse(Console.ReadLine());
            string title, contents;
            string notice;
            string event1;
            Community community;

            Console.WriteLine();
            Console.Write("\t\t\t\t\t\t제목 입력 >> ");
            title = Console.ReadLine();
            Console.Write("\t\t\t\t\t\t내용 입력 >> ");
            contents = Console.ReadLine();

            if(sel == 1)
            {
                community = new FreeCommunity();
                community.Title = title;
                community.Contents = contents;

                arrList.Add(community);
            }

            else if (sel == 2)
            {
                Console.Write("\t\t\t\t\t\t공지 입력 >> ");
                notice = Console.ReadLine();

                community = new NoticeCommunity();
                ((NoticeCommunity)community).Title = title;
                ((NoticeCommunity)community).Contents = contents;
                ((NoticeCommunity)community).Notice = notice;

                arrList.Add(community);
            }

            else if (sel == 3)
            {
                Console.Write("\t\t\t\t\t\t이벤트 입력 >> ");
                event1 = Console.ReadLine();

                community = new EventCommunity();
                ((EventCommunity)community).Title = title;
                ((EventCommunity)community).Contents = contents;
                ((EventCommunity)community).Event = event1;

                arrList.Add(community);
            }
        }

        public void printFreeCommunity()
        {
            Console.Write("\n\n\n\n");
            Console.WriteLine("\t\t\t\t   ▣▣▣▣      ▣▣▣▣        ▣▣▣▣      ▣▣▣▣                      ");
            Console.WriteLine("\t\t\t\t   ▣            ▣      ▣      ▣            ▣                                 ");
            Console.WriteLine("\t\t\t\t   ▣▣▣        ▣▣▣▣        ▣▣▣        ▣▣▣                             ");
            Console.WriteLine("\t\t\t\t   ▣            ▣    ▣        ▣            ▣                      ");
            Console.WriteLine("\t\t\t\t   ▣            ▣      ▣      ▣▣▣▣      ▣▣▣▣ ");
            Console.WriteLine("\n\n\n");
            for (int i = 0; i < arrList.Count; i++)
            {
                
                    Community community = (Community)arrList[i];
                    if (community is FreeCommunity)
                        community.showInfo(i + 1);
                
            }
            Console.ReadLine();
        }

        public void printNoticeCommunity()
        {
            Console.Write("\n\n\n\n");
            Console.WriteLine("\t\t  ▣▣      ▣     ▣▣▣      ▣▣▣▣▣    ▣▣▣▣▣    ▣▣▣     ▣▣▣▣");
            Console.WriteLine("\t\t  ▣  ▣    ▣   ▣      ▣        ▣            ▣       ▣          ▣");
            Console.WriteLine("\t\t  ▣    ▣  ▣   ▣      ▣        ▣            ▣       ▣          ▣▣▣▣");
            Console.WriteLine("\t\t  ▣      ▣▣   ▣      ▣        ▣            ▣       ▣          ▣");
            Console.WriteLine("\t\t  ▣        ▣     ▣▣▣          ▣        ▣▣▣▣▣    ▣▣▣     ▣▣▣▣");
            Console.WriteLine("\n\n\n");
            for (int i = 0; i < arrList.Count; i++)
            {
                Community community = (Community)arrList[i];
                if (community is NoticeCommunity)
                    community.showInfo(i + 1);
            }
            Console.ReadLine();
        }

        public void printEventCommunity()
        {
            Console.Write("\n\n\n\n");
            Console.WriteLine("\t\t\t\t▣▣▣▣  ▣▣    ▣▣  ▣▣▣▣  ▣▣    ▣   ▣▣▣▣");
            Console.WriteLine("\t\t\t\t▣         ▣      ▣   ▣        ▣ ▣   ▣      ▣");
            Console.WriteLine("\t\t\t\t▣▣▣      ▣    ▣    ▣▣▣    ▣  ▣  ▣      ▣");
            Console.WriteLine("\t\t\t\t▣           ▣  ▣     ▣        ▣   ▣ ▣      ▣");
            Console.WriteLine("\t\t\t\t▣▣▣▣      ▣▣      ▣▣▣▣  ▣    ▣▣      ▣");
            Console.WriteLine("\n\n\n");
            for (int i = 0; i < arrList.Count; i++)
            {
                Community community = (Community)arrList[i];
                if (community is EventCommunity)
                    community.showInfo(i + 1);
            }
            Console.ReadLine();
        }

        public void programExit()
        {
            communityFile.saveFileCommunity(arrList);
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t\t ▣▣▣   ▣▣  ▣▣  ▣▣▣");
            Console.WriteLine("\t\t\t\t\t\t▣    ▣   ▣    ▣     ▣");
            Console.WriteLine("\t\t\t\t\t\t▣    ▣   ▣    ▣     ▣");
            Console.WriteLine("\t\t\t\t\t\t ▣▣▣     ▣▣▣      ▣");
            Console.WriteLine("\n\n");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}

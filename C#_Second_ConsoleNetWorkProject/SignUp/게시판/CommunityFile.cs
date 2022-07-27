using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp.게시판
{
    class CommunityFile
    {
        const int FREE = 0;
        const int NOTICE = 1;
        const int EVENT = 2;

        public void loadFileCommunity(ArrayList arrList)
        {
            StreamReader sr = null;

            try
            {
                sr = new StreamReader("community.txt");
                Community community = null;
                int step = 0, kind = 0;

                while (sr.Peek() >= 0)
                {
                    string str = sr.ReadLine();
                    if (step == 0)
                    {
                        if (str == "free")
                        {
                            kind = FREE;
                            community = new FreeCommunity();
                        }
                        else if (str == "notice")
                        {
                            kind = NOTICE;
                            community = new NoticeCommunity();
                        }
                        else if (str == "event")
                        {
                            kind = EVENT;
                            community = new EventCommunity();
                        }

                        step++;
                    }

                    else if (step == 1)
                    {
                        if (kind == FREE)
                        {
                            ((FreeCommunity)community).Title = str;
                            step++;
                        }

                        else if (kind == NOTICE)
                        {
                            ((NoticeCommunity)community).Title = str;
                            step++;
                        }
                        
                        else if (kind == EVENT )
                        {
                            ((EventCommunity)community).Title = str;
                            step++;
                        }
                    }
                    else if (step == 2)
                    {
                        if (kind == FREE)
                        {
                            ((FreeCommunity)community).Contents = str;
                            step++;
                        }

                        else if (kind == NOTICE)
                        {
                            ((NoticeCommunity)community).Contents = str;
                            step++;
                        }

                        else if (kind == EVENT)
                        {
                            ((EventCommunity)community).Contents = str;
                            step++;
                        }
                    }
                    else if (step == 3)
                    {
                        if (kind == FREE)
                        {
                            arrList.Add(community);
                            step = 0;
                        }
                        else if (kind == NOTICE)
                        {
                            ((NoticeCommunity)community).Notice = str;
                            step++;
                        }
                        else if (kind == EVENT)
                        {
                            ((EventCommunity)community).Event = str;
                            step++;
                        }
                    }

                    else if (step == 4)
                    {
                        arrList.Add(community);
                        step = 0;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        public void saveFileCommunity(ArrayList arrList)
        {
            StreamWriter sw = new StreamWriter("community.txt");
            for (int i = 0; i < arrList.Count; i++)
            {
                Community community = (Community)arrList[i];
                if (community is FreeCommunity)
                {
                    sw.WriteLine("free");
                    sw.WriteLine(community.Title);
                    sw.WriteLine(community.Contents);
                    sw.WriteLine();
                }

                else if (community is NoticeCommunity)
                {
                    sw.WriteLine("notice");
                    sw.WriteLine(community.Title);
                    sw.WriteLine(community.Contents);
                    sw.WriteLine(((NoticeCommunity)community).Notice);
                    sw.WriteLine();
                }

                else if(community is EventCommunity)
                {
                    sw.WriteLine("event");
                    sw.WriteLine(community.Title);
                    sw.WriteLine(community.Contents);
                    sw.WriteLine(((EventCommunity)community).Event);
                    sw.WriteLine();
                }
            }
            sw.Close();
        }
    }
}

   


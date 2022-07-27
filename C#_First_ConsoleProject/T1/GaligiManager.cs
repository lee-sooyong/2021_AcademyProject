using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{

    class GaligiManager
    {
        ArrayList arrList = new ArrayList();
        GaligiFile galigiFile = new GaligiFile();
        

        public void insertData(double b)
        {
            Console.Clear();
            Console.WriteLine("--------정보 입력-------");
            Console.Write("이름 입력 >> ");
            string gameer = Console.ReadLine();

            GaligiInfo galigiInfo = new GaligiInfo();
            galigiInfo.Name = gameer;
            galigiInfo.Time = b;
            arrList.Add(galigiInfo);

        
            Console.WriteLine();
            Console.WriteLine("=========================");
            Console.WriteLine("이름: " + galigiInfo.Name);
            Console.WriteLine("기록: " + b);
            Console.WriteLine("=========================");
            galigiFile.saveGaligi(arrList);
            Console.WriteLine("저장되었습니다.");
            Console.Write("    Press Enter...");
        }
        public void showData()
        {
            for (int i = 0; i < arrList.Count; i++)
            {
                GaligiInfo Info = (GaligiInfo)arrList[i];
                Info.showInfo();
            }
        }
        public void loadDate()
        {
            galigiFile.loadFile(arrList);
        }

        public void gameExit()
        {
            Console.WriteLine("===== 프로그램 종료 =======");
        }

        


        public void deleteRank()
        {

            string path = "D:\\Lecture\\_03_Project\\_01_CSharpOOP_Project\\Team1\\T1_project\\T1\\T1\\bin\\Debug\\GaligiGamer.txt";

            Console.Write("기록을 초기화 하시겠습니까?(Y/N)");
            string answer = Console.ReadLine();
            if (answer == "y" || answer == "Y")
            {
                File.Delete(path);
                Console.WriteLine("기록파일이 삭제 되었습니다.");
                Console.WriteLine("게임을 다시 실행해 주십시오.");
                Console.ReadKey();
                Environment.Exit(0);
                

            }
            else if (answer != "y" || answer != "Y")
            {
                //Console.WriteLine("초기화가 취소 되었습니다.");
                Console.WriteLine("기록 초기화가 취소 되었습니다.");
            }
            Console.ReadLine();
        }
        static void BackGroundUpLine(int a, int b, int c) // x축 a~b 그리기, y축 c로 고정 (배경용)
        {
            for (int i = a; a < b; a++)
            {
                Console.CursorLeft = a;
                Console.CursorTop = c;
                Console.Write("▼");
            }
        }

        static void BackGroundDownLine(int a, int b, int c) // x축 a~b 그리기, y축 c로 고정 (배경용)
        {
            for (int i = a; a < b; a++)
            {
                Console.CursorLeft = a;
                Console.CursorTop = c;
                Console.Write("▲");
            }
        }


        static void StartLine() // 시작 라인
        {
            for (int Starty = 5; Starty < 20; Starty++) // 시작 라인 입력
            {
                Console.CursorLeft = 10;
                Console.CursorTop = Starty;
                Console.Write("□");
                Console.WriteLine();
            }
        }


        static void EndLine() // 끝 라인
        {
            for (int Endy = 5; Endy < 21; Endy++) // 끝 라인 입력
            {

                Console.CursorLeft = 60;
                Console.CursorTop = Endy;
                Console.Write("  ■");
                Console.WriteLine();

            }
        }

        static void CountDown() // 카운트 다운
        {
            int timeDy = 4; // 카운트 다운 y좌표
            for (int startCount = 3; startCount >= 1; startCount--) // 시작전 카운트 3 ~ 1 카운트
            {
                Console.CursorLeft = 10;
                Console.CursorTop = timeDy;
                Console.WriteLine("{0}", startCount);
                System.Threading.Thread.Sleep(1000);
            }
        }

        static void StartBlink()
        {
            Console.CursorLeft = 10;
            Console.CursorTop = 4;
            Console.WriteLine("시작!!!");
            System.Threading.Thread.Sleep(500);
            Console.CursorLeft = 10;
            Console.CursorTop = 4;
            Console.Write("         ");
        }
        public void GaligiGame()
        //public void GaligiGame()
        {
            //public void GaligiGame()

            Console.WriteLine("탈리기 = 타이핑 + 달리기");
            Console.WriteLine("게임방식 : 화면에 나오는 소문자를 입력하여 끝지점까지 도착하세요~");

            int x = 10, y = 12; // 시작 지점 x,y

            Random rand = new Random(); // 랜덤함수
            int randN = 0;// 랜덤 정수 선언 --> 랜덤 정수형 > 랜덤 소문자로 변환할 예정
            int Endx = 60;  // 끝 지점 x
            int Disqx = 4; // 실격 지점 x


            Stopwatch st = new Stopwatch(); // 스톱워치 불러오기
            int SWx = 70, SWy = 3; // 스톱워치 x y 좌표
            double SWtime = 0; // 스톱워치 시간

            int INx = 5, INy = 3; // 입력좌표 x y 좌표

            // 시작전 배경
            StartLine(); // 시작 라인
            EndLine();   // 끝 라인
            BackGroundUpLine(10, 60, 5); // 위 배경 라인
            BackGroundDownLine(10, 60, 20); // 밑 배경 라인

            // 캐릭터 시작점에 출력
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.Write("♬");


            CountDown(); // 시작전 카운트 다운
            StartBlink(); // 시작 깜박이


            // 게임시작

            st.Start(); // 스톱워치 시작
            while (x < Endx) // 끝지점 전까지 타이핑 게임
            {

                randN = rand.Next(97, 123);


                Console.CursorLeft = INx;
                Console.CursorTop = INy;

                Console.Write("{0} 입력 >> ", (char)randN); // 입력창

                Char inputCh = Console.ReadKey(true).KeyChar; // 문자 입력하자마자 정수형으로 변환



                if ((char)inputCh == randN)  // 입력 문자 일치
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("  ");
                    x += 2;

                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("♬");
                }

                else                         // 입력 문자 불일치
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("  ");
                    x -= 2;
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write("♬");

                    if (x == Disqx) // 실격 좌표로 갔을 경우
                    {
                        break;
                    }
                }

            }

            if (x == Disqx) // 실격 처리  ( x = 4 이거나 stone 맞은 경우) --> "끝" 표시
            {
                int x1 = 10, y1 = 12;
                Console.Clear();
                st.Stop(); // 스톱워치 끝
                SWtime = 0; // 실격 --> 기록 0초
                Console.Clear();

                for (int i = 0; i < 3; i++)
                {

                    Console.CursorLeft = x1;
                    Console.CursorTop = y1;
                    Console.WriteLine("실격!");
                    System.Threading.Thread.Sleep(500);
                    Console.CursorLeft = x1;
                    Console.CursorTop = y1;
                    Console.WriteLine("     ");
                    System.Threading.Thread.Sleep(500); // 밑에 후처리 ( SWtime = 0 이므로 기록 안나옴)

                }

            }


            if (x == Endx) // 끝지점 도달 --> "끝" 표시
            {

                st.Stop(); // 스톱워치 끝
                
                x = Endx + 2;

                for (int i = 0; i < 3; i++)
                {

                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.WriteLine("끝~!");
                    System.Threading.Thread.Sleep(500);
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.WriteLine("    ");
                    System.Threading.Thread.Sleep(500);


                }




                Console.CursorLeft = SWx;
                Console.CursorTop = SWy;
                SWtime = st.Elapsed.TotalMilliseconds / 1000;
                Console.WriteLine("{0:0.##}초 ", SWtime); // 밑에 기록 출력 및 후처리
                Console.ReadLine();
                insertData(SWtime);
                Console.ReadLine();
                
                
            }
        }
    }
}

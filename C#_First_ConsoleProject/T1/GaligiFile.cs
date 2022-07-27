using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    class GaligiFile
    {

        public void loadFile(ArrayList arrList)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("GaligiGamer.txt");
                GaligiInfo galigiInfo = null;
                int step = 0;

                while (sr.Peek() >= 0)
                {
                    string str = sr.ReadLine();
                    if (step == 0)
                    {
                        galigiInfo = new GaligiInfo();
                        galigiInfo.Name = str;

                        step++;
                    }
                    else if (step == 1)
                    {
                        //str =Console.WriteLine("{0:0.##}", str);
                        galigiInfo.Time = Double.Parse(str); //더블형변환 함수를 써서 string 값을 double로 바꿔서 타임값을 넣었습니다.
                        step++;
                    }
                    else
                    {
                        step = 0;
                        arrList.Add(galigiInfo);
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
                {
                    sr.Close();
                }
            }
        }

        public void saveGaligi(ArrayList arrayList)
        {
            StreamWriter sw = new StreamWriter("GaligiGamer.txt");

            for (int i = 0; i < arrayList.Count; i++)
            {
                GaligiInfo galigiInfo = (GaligiInfo)arrayList[i];
                sw.WriteLine(galigiInfo.Name);
                sw.WriteLine(galigiInfo.Time);
                sw.WriteLine(); //?
            }
            sw.Close(); //쓰고 난 후 닫아줘야함
        }

    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp
{
    class TimestampDao
    {
        private SqlConnection conn = null;

        private string connInfo =
            "server=localhost;database=Test_DB;" +
            "uid=Test_Login;pwd=p1234";

        public TimestampDao()
        {
            conn = new SqlConnection(connInfo);
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    //Console.WriteLine("출퇴근대장기록 창에 접속합니다.");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        ~TimestampDao()
        {
            if (conn != null)
                conn.Close();
        }

        public void insertSignUp(TimestampPage sign)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO dbo.TTable" + "\r\n" +
                                      "VALUES(@출근,@이름)";
                    cmd.Parameters.AddWithValue("@출근", sign.Attend);
                    cmd.Parameters.AddWithValue("@이름", sign.Name);
                    int cnt = cmd.ExecuteNonQuery(); // 서버로 sql전송 후 실행
                    Console.WriteLine("\t\t\t\t\t\t============");
                    Console.WriteLine("\t\t\t\t\t\t출근 등록완료");
                    Console.WriteLine("\t\t\t\t\t\t============");
                    Console.ReadKey(); 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
        public void insertSignUp2(TimestampPage sign)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO dbo.ETable" + "\r\n" +
                                      "VALUES(@퇴근)";
                    cmd.Parameters.AddWithValue("@퇴근", sign.Lle);

                    int cnt = cmd.ExecuteNonQuery(); // 서버로 sql전송 후 실행
                    Console.WriteLine("\t\t\t\t\t\t============");
                    Console.WriteLine("\t\t\t\t\t\t퇴근 등록완료");
                    Console.WriteLine("\t\t\t\t\t\t============");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        public ArrayList searchAllTime()
        {
            ArrayList addrList = new ArrayList();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM dbo.TTable";

                    SqlDataReader reader = cmd.ExecuteReader();
                    // 다음행에 읽어야 할 내용이 존재한다면
                    // true를 리턴하고 다음행으로 이동
                    // 더 이상 읽어야 할 내용이 다음에 없다면 false를 리턴

                    while (reader.Read())
                    {
                        string[] datas = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                            datas[i] = reader.GetValue(i).ToString();

                        TimestampPage TimePage = new TimestampPage();
                        TimePage.Attend = datas[1];
                        TimePage.Name = datas[2];
                        addrList.Add(TimePage);
                    }

                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

            return addrList;
        }

        public ArrayList searchAllTime1()
        {
            ArrayList addrList = new ArrayList();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM dbo.ETable";

                    SqlDataReader reader = cmd.ExecuteReader();
                    // 다음행에 읽어야 할 내용이 존재한다면
                    // true를 리턴하고 다음행으로 이동
                    // 더 이상 읽어야 할 내용이 다음에 없다면 false를 리턴

                    while (reader.Read())
                    {
                        string[] datas = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                            datas[i] = reader.GetValue(i).ToString();

                        TimestampPage TimePage1 = new TimestampPage();
                        TimePage1.Lle = datas[1];
                        addrList.Add(TimePage1);
                    }

                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

            return addrList;
        }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp
{
    class SignUpDao
    {
        private SqlConnection conn = null;

        private string connInfo =
            "server=localhost;database=Test_DB;" +
            "uid=Test_Login;pwd=p1234";

        public SignUpDao()
        {
            conn = new SqlConnection(connInfo);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        ~SignUpDao()
        {
            if (conn != null)
                conn.Close();
        }

        public void insertSignUp(SignUp sign)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO dbo.SignUp" + "\r\n" +
                                      "VALUES(@아이디, @비밀번호, @이름, @주민번호, @전화번호)";
                    cmd.Parameters.AddWithValue("@아이디", sign.Id);
                    cmd.Parameters.AddWithValue("@비밀번호", sign.Pw);
                    cmd.Parameters.AddWithValue("@이름", sign.Name);
                    cmd.Parameters.AddWithValue("@주민번호", sign.Ssn);
                    cmd.Parameters.AddWithValue("@전화번호", sign.Phone);
                    int cnt = cmd.ExecuteNonQuery(); // 서버로 sql전송 후 실행
                    Console.WriteLine();
                    Console.WriteLine("\t\t\t\t\t\t" + cnt + "행이 적용되었습니다");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        public ArrayList searchAllSignUp()
        {
            ArrayList addrList = new ArrayList();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM dbo.SignUp";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string[] datas = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                            datas[i] = reader.GetValue(i).ToString();

                        SignUp sign = new SignUp();
                        sign.Id = datas[1];
                        //sign.Pw = datas[1];
                        sign.Name = datas[3];
                        //sign.Ssn = datas[3];
                        sign.Phone = datas[5];
                        addrList.Add(sign);
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


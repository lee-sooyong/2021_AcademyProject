using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp
{
    class LoginManager
    {
        private SqlConnection conn = null;

        private string connInfo =
            "server=localhost;database=Test_DB;" +
            "uid=Test_Login;pwd=p1234";

        public LoginManager()
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

        ~LoginManager()
        {
            if (conn != null)
                conn.Close();
        }

        public void Login()
        {
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t\t\t\t▣        ▣▣▣     ▣▣▣    ▣▣▣   ▣▣   ▣ ");
            Console.WriteLine("\t\t\t\t▣       ▣    ▣   ▣           ▣     ▣ ▣  ▣  ");
            Console.WriteLine("\t\t\t\t▣       ▣    ▣  ▣  ▣▣▣    ▣     ▣  ▣ ▣  ");
            Console.WriteLine("\t\t\t\t▣▣▣▣  ▣▣▣    ▣▣▣ ▣  ▣▣▣   ▣   ▣▣ ");
            Console.ResetColor();
            Console.WriteLine("\n");
            Console.Write("\t\t\t\t\t\t아이디 입력 >> ");
            string id = Console.ReadLine();
            Console.Write("\t\t\t\t\t\t비밀번호 입력 >> ");
            string pw = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\t\t==============");

            
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM dbo.SignUp WHERE id=@아이디 AND pw=@비밀번호";

                    cmd.Parameters.AddWithValue("@아이디", id);
                    cmd.Parameters.AddWithValue("@비밀번호", pw);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string[] datas = new string[reader.FieldCount];

                        for (int i = 0; i < reader.FieldCount; i++)
                            datas[i] = reader.GetValue(i).ToString();

                        SignUp sign = new SignUp();
                        sign.Id = datas[1];
                        sign.Pw = datas[2];

                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("\t\t\t\t\t\t로그인 성공");
                        Console.WriteLine("\t\t\t\t\t\t다음화면에 접속합니다.");
                        LoginMenu loginmenu = new LoginMenu();
                        loginmenu.main2Loop();
                    }
                    else
                    {
                        reader.Read();
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("\t\t\t\t\t\t로그인 실패");
                        Console.WriteLine("\t\t\t\t\t\t메인화면으로 돌아갑니다.");
                        System.Threading.Thread.Sleep(500);
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}


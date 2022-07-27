using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_CatchMind
{
    static class GameDao
    {
        static string connInfo = "Server=localhost;database=Test_DB;uid=Test_Login;pwd=p1234";
        static SqlConnection conn = null;
        static bool overLapID = false;
        static GameDao()
        {
            conn = new SqlConnection(connInfo);

            conn.Open();

            if (conn.State != System.Data.ConnectionState.Open &&
                conn.State != System.Data.ConnectionState.Connecting)
                conn = null;
        }
        public static GameVo login(string id, string password)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM dbo.Game WHERE 아이디=@아이디 AND 비밀번호=@비밀번호";
            cmd.Parameters.AddWithValue("@아이디", id);
            cmd.Parameters.AddWithValue("@비밀번호", password);
            SqlDataReader reader = cmd.ExecuteReader();

            GameVo gameVo = null;
            if (reader.Read())
            {
                overLapID = true;
                gameVo = new GameVo();
                gameVo.Nickname = reader.GetValue(0).ToString();
                gameVo.Name = reader.GetValue(1).ToString();
                gameVo.Password = reader.GetValue(2).ToString();
            }
            else 
            {
                overLapID = false;
                MessageBox.Show("등록된 회원이 아니거나, 비밀번호가 틀렸습니다.");
            }

            reader.Close();
            cmd.Dispose();

            return gameVo;
        }

        public static GameVo SignIn(string Nickname, string id, string password, string passwordCheck)
        {
            GameVo gameVo = null;
            IdDoubleCheck(id, password);
            if(overLapID == true)
            {
                MessageBox.Show("이미 등록된 아이디가 있습니다.");
                Console.WriteLine("중복임...");
                return null;
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO dbo.Game" + "\r\n" + "VALUES(@아이디,@닉네임,@비밀번호)";
                    cmd.Parameters.AddWithValue("@아이디", id);
                    cmd.Parameters.AddWithValue("@닉네임", Nickname);

                    if (passwordCheck == password)
                    {
                        cmd.Parameters.AddWithValue("@비밀번호", password);
                        MessageBox.Show("회원가입이 완료되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("비밀번호가 일치하지 않습니다.\n 다시 입력해주세요!");
                        return null;
                    }

                    int cnt = cmd.ExecuteNonQuery();
                    Console.WriteLine("회원가입 " + cnt + " id " + id + " Nic " + Nickname + " pas "+ password);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
            }
            return gameVo;
        }

        public static GameVo DeleteId(string id, string password)
        {
            GameVo gameVo = null;
            Console.WriteLine("삭제 메서드 실행");

            login(id, password);

            if (overLapID)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "DELETE FROM dbo.Game WHERE 아이디=@아이디 AND 비밀번호=@비밀번호";
                        cmd.Parameters.AddWithValue("@아이디", id);
                        cmd.Parameters.AddWithValue("@비밀번호", password);
                        int cnt = cmd.ExecuteNonQuery();
                        MessageBox.Show("아이디가 삭제되었습니다.");
                        overLapID = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception : " + ex.Message);
                }
            }
            return gameVo;
        }

        public static GameVo IdDoubleCheck( string id, string password)
        {
            GameVo gameVo = null;
            SqlCommand cmd = new SqlCommand();
            Console.WriteLine("아이디 중복확인");

            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM dbo.Game WHERE 아이디=@아이디";
            cmd.Parameters.AddWithValue("@아이디", id);
            
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                overLapID = true;
                gameVo = new GameVo();
                gameVo.Nickname = reader.GetValue(0).ToString();
                gameVo.Name = reader.GetValue(1).ToString();
                gameVo.Password = reader.GetValue(2).ToString();
            }
            else
            {
                overLapID = false;
            }
            reader.Close();
            cmd.Dispose();
            return gameVo;
        }
    }
}

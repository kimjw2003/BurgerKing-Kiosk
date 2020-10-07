using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace BurgerKing_kiosk.viewModel.DB
{
    class connectDB
    {
        private String ip = "10.80.162.51";
        private String pwd = "1q2w3e4r!";
        private MySqlConnection conn;
 
        public bool OpenConnection(String dbname)
        {
            String connStr = "Server=" + ip + ";Database=kiosk;Uid=root;Pwd=" + pwd;
            conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("데이터베이스 서버에 연결할 수 없습니다.");
                        break;

                    case 1045:
                        Console.WriteLine("유저 ID 또는 Password를 확인해주세요.");
                        break;
                }
                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}

using BurgerKing_kiosk.viewModel.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model.DB
{
    class MoneyDB
    {
        private connectDB conDB = new connectDB();

        public bool GetUserName(String barcode)
        {

            MySqlConnection conn = conDB.OpenConnection();
            bool returnType = false;
            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                string sql = "SELECT * FROM user WHERE barcode=\"" + barcode + "\"";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    App.userData.name = (string)reader["name"];
                    returnType = true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("데이터베이스 서버에 연결할 수 없습니다.");
                        break;

                    case 1045:
                        Console.WriteLine("유저 ID 또는 Password를 확인해주세요.");
                        break;
                }
            }
            finally
            {
                conn.Close();
            }
            return returnType;
        }
    }
}

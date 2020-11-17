using BurgerKing_kiosk.viewModel.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace BurgerKing_kiosk.model.DB
{
    class CardDB
    {
        private connectDB conDB = new connectDB();

        public bool GetUserBarCode(String name)
        {

            MySqlConnection conn = conDB.OpenConnection();
            bool returnType = false;
            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                string sql = "SELECT * FROM user WHERE name=\"" + name + "\"";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    App.userData.barcode = (string)reader["barcode"];
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

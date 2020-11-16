using BurgerKing_kiosk.viewModel.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model.DB
{
    class FinishDB
    {
        private connectDB conDB = new connectDB();

        public bool SetOrderData(int orderIdx)
        {

            MySqlConnection conn = conDB.OpenConnection();
            bool returnType = false;
            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                string sql = string.Format($"INSERT INTO  kiosk.order(`menu`, `category`, `user`, `day`, `price`, `seat`, `sale`, `payment_method`, `time`, `count`) VALUES (" +
                    $"'{OrderModel.GetInstance()[orderIdx].Name}', '{OrderModel.GetInstance()[orderIdx].category}', '{App.userData.barcode}', '{DateTime.Today.ToString("yyyy-MM-dd")}', " +
                    $"{OrderModel.GetInstance()[orderIdx].Price}, {App.userData.seat}, {OrderModel.GetInstance()[orderIdx].sale}, '{App.userData.payment}','{DateTime.Now.ToString("HH:mm:ss")}', " +
                    $"{OrderModel.GetInstance()[orderIdx].Count});");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                Console.WriteLine(sql);
                cmd.ExecuteNonQuery();
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
            return returnType;
        }
    }
}

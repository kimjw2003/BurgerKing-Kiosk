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
                string sql = "INSERT INTO  kiosk.order(`menu`, `category`, `user`, `day`, `price`, `seat`, `sale`, `payment_method`, `time`) VALUES (@menu, @category, @user, @day, @price, @seat, @sale, @payment, @time);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@menu", OrderModel.GetInstance()[orderIdx].name);
                cmd.Parameters.AddWithValue("@category", OrderModel.GetInstance()[orderIdx].name);
                cmd.Parameters.AddWithValue("@user", App.userData.name);
                cmd.Parameters.AddWithValue("@day", DateTime.Today.ToString("yyyy-MM-dd"));
                cmd.Parameters.Add("@price", (MySqlDbType)SqlDbType.Int);
                cmd.Parameters["@price"].Value = OrderModel.GetInstance()[orderIdx].price;
                cmd.Parameters.Add("@seat", (MySqlDbType)SqlDbType.Int);
                cmd.Parameters["@seat"].Value = App.userData.seat;
                cmd.Parameters.Add("@sale", (MySqlDbType)SqlDbType.Int);
                cmd.Parameters["@sale"].Value = OrderModel.GetInstance()[orderIdx].sale;
                cmd.Parameters.AddWithValue("@payment", App.userData.payment);
                cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("HH:mm:ss"));
                Console.WriteLine(cmd.Parameters.ToString());
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

using BurgerKing_kiosk.viewModel.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model.DB
{
    class StatisticsDB
    {
        private connectDB conDB = new connectDB();

        public List<SaleModel> SelectOrderList(string WhereSql)
        {

            MySqlConnection conn = conDB.OpenConnection();

            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                string sql = "SELECT * FROM kiosk.order "+WhereSql;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<SaleModel> sales = new List<SaleModel>();
                SaleModel sale;

                while (reader.Read())
                {
                    sale = new SaleModel();
                    sale.category = (String)reader["category"];
                    sale.price = (int)reader["price"];
                    sale.sale = (int)reader["sale"];

                    sales.Add(sale);

                    Console.WriteLine(sale.price);
                }
                return sales;
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
            return null;
        }
    }
}



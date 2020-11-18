using BurgerKing_kiosk.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel.DB
{
    class SaleDB
    {
        private connectDB conDB = new connectDB();
        private List<SaleModel> sales = new List<SaleModel>();

        public List<SaleModel> Select(String payment_method)
        {

            MySqlConnection conn = conDB.OpenConnection();

            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                SaleModel sale;
                string sql = "SELECT * FROM kiosk.order " + payment_method;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sale = new SaleModel();
                    sale.price = (int)reader["price"];
                    sale.sale = (int)reader["sale"];

                    sales.Add(sale);
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
            return sales;
        }
    }
}


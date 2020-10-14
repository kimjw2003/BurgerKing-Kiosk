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
        private connectDB conn = new connectDB();
        private List<SaleModel> sales = null;

        public List<SaleModel> Select(String Columnname)
        {
            if (conn.OpenConnection() == true)
            {
                FoodModel menu;
                try
                {
                    string sql = "select "+ Columnname + " from sale";
                    MySqlCommand cmd = new MySqlCommand(sql, conn.conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        menu = new FoodModel();
                        menu.id = (int)reader["id"]; //todo - object형식이 int형으로 바뀌었는지 확인 안되면 밑에것도 함께 고침
                        menu.name = (string)reader["name"];
                        menu.picture = (string)reader["picture"];
                        menu.price = (int)reader["price"];
                        menu.sale = (int)reader["sale"];

                        //sales.Add(menu);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return sales;
        }
    }
}


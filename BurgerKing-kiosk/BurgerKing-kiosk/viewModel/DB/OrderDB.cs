using BurgerKing_kiosk.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace BurgerKing_kiosk.viewModel.DB
{
    class OrderDB
    {
        private connectDB conn = new connectDB();
        private List<FoodModel> menus = null;

        public List<FoodModel> Select(String tablename)
        {
            if (conn.OpenConnection() == true)
            {
                FoodModel menu;
                try
                {
                    string sql = "select * from " + tablename;
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

                        menus.Add(menu);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return menus;
        }
    }
}

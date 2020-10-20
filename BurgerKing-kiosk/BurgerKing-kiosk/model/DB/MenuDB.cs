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
    class MenuDB
    {
        private connectDB conDB = new connectDB();
        private List<MenuModel> menus = new List<MenuModel>();

        public List<MenuModel> GetMenu(String tablename)
        {
            MySqlConnection conn = conDB.OpenConnection();
            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                MenuModel menu;
                string sql = "select * from " + tablename;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    menu = new MenuModel();
                    menu.id = (int)reader["id"]; //todo - object형식이 int형으로 바뀌었는지 확인 안되면 밑에것도 함께 고침
                    Console.WriteLine(menu.id);
                    menu.name = (string)reader["name"];
                    menu.picture = (string)reader["picture"];
                    menu.price = (int)reader["price"];
                    menu.sale = (int)reader["sale"];

                    menus.Add(menu);
                }
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
            }
            Console.WriteLine(menus);
            return menus;
        }
    }
}

using BurgerKing_kiosk.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel.DB
{
    class TableDB
    {
        private connectDB conDB = new connectDB();
        private List<SaleModel> menus = new List<SaleModel>();

        public List<SaleModel> Insert(String tablename)
        {
            MySqlConnection conn = conDB.OpenConnection();
            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                SaleModel menu;
                string sql = "insert i * from " + tablename;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    menu = new SaleModel();

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

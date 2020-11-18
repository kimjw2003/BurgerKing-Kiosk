using BurgerKing_kiosk.viewModel.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model.DB
{
    class TableDB
    {
        private connectDB conDB = new connectDB();

        public List<TableModel> GetTable()
        {
            TableModel table;
            List<TableModel> list = new List<TableModel>();
            MySqlConnection conn = conDB.OpenConnection();
            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                string sql = "SELECT * FROM kiosk.table;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    table = new TableModel();
                    table.id = (int)reader["id"];
                   // table.OrderTime = DateTime.Parse((string)reader["OrderTime"]);
                    list.Add(table);
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
            return list;
        }
        public void UpdateTable(int id)
        {

            MySqlConnection conn = conDB.OpenConnection();
            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                string sql = string.Format($"UPDATE kiosk.table SET OrderTime = \"{DateTime.Now.ToString()}\" WHERE id = {id}");
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
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
            finally
            {
                conn.Close();
            }
        }
    }
}

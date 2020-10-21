using BurgerKing_kiosk.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BurgerKing_kiosk.viewModel.DB
{
    class TableDB
    {
        private connectDB conDB = new connectDB();

        public void AddTable(int tableId)
        {
            MySqlConnection conn = conDB.OpenConnection();
            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string sql = "INSERT Region (id, time) VALUES (" + tableId + ", '" + time + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
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
        }

        public List<TableModel> GetTable()
        {
            TableModel table;
            List<TableModel> list = new List<TableModel>();
            MySqlConnection conn = conDB.OpenConnection();
            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                string sql = "select * from table";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    table = new TableModel();
                    table.id = (int)reader["id"]; //todo - object형식이 int형으로 바뀌었는지 확인 안되면 밑에것도 함께 고침
                    table.time = (string)reader["name"];

                    list.Add(table);
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
            return list;
        }
    }
}

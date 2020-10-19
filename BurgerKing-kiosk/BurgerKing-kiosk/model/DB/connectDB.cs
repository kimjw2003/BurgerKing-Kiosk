using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace BurgerKing_kiosk.viewModel.DB
{
    class connectDB
    {
        private String ip = "10.80.162.51";
        private String port = "3306";
        private String pwd = "1q2w3e4r!";
        public MySqlConnection conn;
 
        public MySqlConnection OpenConnection()
        {
            String connStr = "Server=" + ip + ";Port=" + port + ";Database=kiosk;Uid=user1;Pwd=" + pwd;
            Console.WriteLine(connStr);
            conn = new MySqlConnection(connStr);
            return conn;
        }
        public bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}

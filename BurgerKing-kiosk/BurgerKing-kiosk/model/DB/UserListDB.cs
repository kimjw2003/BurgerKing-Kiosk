﻿using BurgerKing_kiosk.viewModel.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model.DB
{
    class UserListDB
    {

        private connectDB conDB = new connectDB();
        private List<UserModel> users = new List<UserModel>();

        public List<UserModel> GetUser()
        {
            MySqlConnection conn = conDB.OpenConnection();
            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                UserModel user;
                string sql = "select * from kiosk.user";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user = new UserModel();
                    user.name = (String)reader["name"]; 
                    user.barcode = (String)reader["barcode"];

                    users.Add(user);
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
            finally
            {
                conn.Close();
            }
            return users;
        }
    }
}

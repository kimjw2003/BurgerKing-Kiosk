﻿using BurgerKing_kiosk.viewModel.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model.DB
{
    class AutoLoginDB
    {
        private connectDB conDB = new connectDB();
        private Boolean AutoLogin;

        public Boolean GetBool()
        {
            MySqlConnection conn = conDB.OpenConnection();
            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                string sql = "select * from autologin";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AutoLogin= Convert.ToBoolean((System.SByte)reader["bool"]);
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
            Console.WriteLine(AutoLogin);
            return AutoLogin;
        }

        public void SetBool(Boolean AutoLogin)
        {
            MySqlConnection conn = conDB.OpenConnection();
            try
            {
                conn.Open();
                Console.WriteLine("DataBase연동 성공");
                string sql = "update autologin set bool ="+AutoLogin;
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
    }
}
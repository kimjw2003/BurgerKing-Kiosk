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
            
            return sales;
        }
    }
}


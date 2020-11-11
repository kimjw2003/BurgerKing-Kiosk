using BurgerKing_kiosk.model;
using BurgerKing_kiosk.model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel
{
    class StatisticsViewModel
    {
        StatisticsDB db = new StatisticsDB();

        public int GetCategorySaleCount(string Category)
        {
            string sql = "WHERE category = '" + Category+"'";
            List<SaleModel> sales = db.SelectOrderList(sql);
            return sales.Count;
        }

        public int GetCategorySalePrice(string Category)
        {
            int TotalPrice = 0;
            string sql = "WHERE category = '" + Category + "'";
            List<SaleModel> sales = db.SelectOrderList(sql);

            foreach(SaleModel sale in sales)
            {
                TotalPrice += sale.price;
            }

            return TotalPrice;
        }

        /*public SaleModel GetSeatCategorySaleCount(string Category, string Seat)
        {
            string sql = "WHERE "
        }*/
    }
}

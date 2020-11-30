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

        public List<SaleModel> GetMenuStatistics(string seat)
        {
            List<SaleModel> sales = new List<SaleModel>();
            string wheresql;
            if(seat == "0")
            {
                wheresql = null;
            }
            else
            {
                wheresql = "WHERE seat = '" + seat + "'";
            }
            List<string> menus = db.SelectMenuList(wheresql);

            foreach(string menu in menus)
            {
                String sql;
                if(seat == "0")
                {
                    sql = "WHERE menu = '" + menu + "' ";
                }
                else
                {
                    sql = "WHERE menu = '" + menu + "' AND seat = '"+seat+"'";
                }
                
                List<SaleModel> MenuSales = db.SelectOrderList(sql);

                SaleModel sale = new SaleModel();
                sale.menu = menu;

                foreach (SaleModel MenuSale in MenuSales)
                {
                    int SalePrice = CalculateSalePrice(MenuSale);

                    sale.count += MenuSale.count;
                    sale.price += SalePrice * MenuSale.count;
                }

               sales.Add(sale);
            }

            return sales;
        }

        public SaleModel GetCategoryStatistics(string Category, string seat)
        {
            SaleModel sale = new SaleModel();

            string sql = "WHERE category = '" + Category +"'";

            if (seat != "0")
            {
                sql += " AND seat = '" + seat + "'";
            }
     
            List<SaleModel> results = db.SelectOrderList(sql);

            foreach(SaleModel result in results)
            {
                int SalePrice = CalculateSalePrice(result);

                sale.count += result.count;
                sale.price += SalePrice * result.count;
            }

            return sale;
        }

        public int GetDailyStatistics(string date, string time)
        {
            int TotalPrice = 0;

            string sql = "WHERE day = '" + date + "'";

            if (time != null)
            {
                sql += "AND time LIKE '" + time + "%'";
            }

            List<SaleModel> Sales = db.SelectOrderList(sql);

            foreach (SaleModel Sale in Sales)
            {
                int SalePrice = CalculateSalePrice(Sale);
                TotalPrice += SalePrice * Sale.count;
            }

            return TotalPrice;
        }
        
        public List<SaleModel> GetUserStatistics(string barcode)
        {
            List<SaleModel> sales = new List<SaleModel>();
            string sql = "WHERE user ='" + barcode + "'";

            List<string> menus = db.SelectMenuList(sql);

            foreach (string menu in menus)
            {
              
                sql = "WHERE menu = '" + menu + "' AND user = '" + barcode + "'";
             

                List<SaleModel> MenuSales = db.SelectOrderList(sql);

                SaleModel sale = new SaleModel();
                sale.menu = menu;

                foreach (SaleModel MenuSale in MenuSales)
                {
                    int SalePrice = CalculateSalePrice(MenuSale);

                    sale.count += MenuSale.count;
                    sale.price += SalePrice * MenuSale.count;
                }

                sales.Add(sale);
            }

            return sales;
        }
        public StatisticsModel GetStatistics(String payment_method)
        {
            string sql = null;
            StatisticsModel result = new StatisticsModel();

            if (payment_method != null)
            {
                sql = "WHERE payment_method = '" + payment_method + "' ";
            }

            List<SaleModel> Sales = db.SelectOrderList(sql);

            foreach (SaleModel Sale in Sales)
            {
                float Originalprice = Sale.price;
                float SalePercent = (float)Sale.sale / 100;
                float PureSalePrice = Originalprice * (1 - SalePercent);
                float SalePrice = Originalprice * SalePercent;

                result.OriginalPrice += (int)Originalprice * Sale.count;
                result.SalePrice += (int)SalePrice * Sale.count;
                result.PureSalePrice += (int)PureSalePrice * Sale.count;
            }

            Console.WriteLine(result.OriginalPrice);

            return result;
        }

        public int CalculateSalePrice(SaleModel Sale)
        {
            float Originalprice = Sale.price;
            float SalePercent = (float)Sale.sale / 100;
            float SalePrice = Originalprice * (1 - SalePercent);

            return (int)SalePrice;
        }
    }
}

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

        public List<SaleModel> GetMenuSalePrice(string seat)
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

                foreach (SaleModel MenuSale in MenuSales)
                {
                    sale.menu = menu;
                    sale.count += MenuSale.count;
                    sale.price += (MenuSale.price*MenuSale.count);
                }

               sales.Add(sale);
            }

            return sales;
        }

        public SaleModel Test(string Category, string seat)
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
                float Originalprice = result.price;
                float SalePercent = (float)result.sale / 100;
                float SalePrice = Originalprice * (1 - SalePercent);

                sale.count += result.count;
                sale.price += (int)SalePrice * result.count;
            }

            return sale;
        }

        public int GetWholeSaleAmount(string date, string time)
        {
            int TotalPrice = 0;
            string sql = "WHERE day = '" + date + "' AND time LIKE '"+time+"%'";
            List<SaleModel> sales = db.SelectOrderList(sql);

            foreach (SaleModel sale in sales)
            {
                TotalPrice += sale.price * sale.count;
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

                foreach (SaleModel MenuSale in MenuSales)
                {
                    float Originalprice = MenuSale.price;
                    float SalePercent = (float)MenuSale.sale / 100;
                    float SalePrice = Originalprice * (1 - SalePercent);

                    sale.menu = menu;
                    sale.count += MenuSale.count;
                    sale.price += (int)SalePrice * MenuSale.count;
                }

                sales.Add(sale);
            }

            return sales;
        }
    }
}

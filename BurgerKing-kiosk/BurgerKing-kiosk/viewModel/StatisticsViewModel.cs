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

        public void GetMenuSalePrice(int seat)
        {
            
            List<SaleModel> sales = new List<SaleModel>();
            string wheresql;
            if(seat == 0)
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
                if(seat == 0)
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

                Console.WriteLine("메뉴:" + menu + " 수량:" + sale.count+" 총 가격:"+sale.price);

               sales.Add(sale);
            }
        }

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
                TotalPrice += sale.price * sale.count;
            }

            return TotalPrice;
        }

        public int GetSeatCategorySaleCount(string Category, int Seat)
        {
            string sql = "WHERE seat = '" + Seat + "' AND " + "category = '" + Category + "'";
            List<SaleModel> sales = db.SelectOrderList(sql);
            return sales.Count;
        }

        public int GetSeatCategorySalePrice(string Category, int Seat)
        {
            int TotalPrice = 0;
            string sql = "WHERE seat = '" + Seat + "' AND " + "category = '" + Category + "'";
            List<SaleModel> sales = db.SelectOrderList(sql);

            foreach (SaleModel sale in sales)
            {
                TotalPrice += sale.price * sale.count;
            }

            return TotalPrice;
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
        
        public int GetMemberSaleAmount(string barcode)
        {
            int TotalPrice = 0;
            string sql = "WHERE user = '" + barcode + "'";
            List<SaleModel> sales = db.SelectOrderList(sql);

            foreach (SaleModel sale in sales)
            {
                TotalPrice += sale.price * sale.count;
            }

            return TotalPrice;
        }

        public List<SaleModel> GetMemberSaleMenu(string barcode)
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
                    sale.menu = menu;
                    sale.count += MenuSale.count;
                    sale.price += (MenuSale.price * MenuSale.count);
                }

                Console.WriteLine("메뉴:" + menu + " 수량:" + sale.count + " 총 가격:" + sale.price);

                sales.Add(sale);
            }

            return sales;
        }
    }
}

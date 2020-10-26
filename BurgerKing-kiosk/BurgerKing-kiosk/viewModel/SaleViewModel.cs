using BurgerKing_kiosk.model;
using BurgerKing_kiosk.viewModel.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel
{
    class SaleViewModel
    {
        private List<SaleModel> sales = null;
        private List<String> result;
        public List<String> GetSale(String payment_method)
        {
            result = new List<string>();
            SaleDB sale = new SaleDB();
            sales = sale.Select(payment_method);


            float WholePrice = 0;
            float PurePrice = 0;
            float SalePrice = 0;

            foreach (SaleModel Sale in sales)
            {
                float price = Sale.price;
                float saleAmount = Sale.sale;
                float percent = saleAmount / 100;

                WholePrice += price;
                PurePrice += price * (1 - percent);
                SalePrice += price * percent;
            }

            result.Add(WholePrice.ToString());
            result.Add(PurePrice.ToString());
            result.Add(SalePrice.ToString());

            Console.WriteLine(WholePrice);
            Console.WriteLine(PurePrice);
            Console.WriteLine(SalePrice);

            return result;
        }
    }
}
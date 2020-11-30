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
        SaleDB db = new SaleDB();
        public StatisticsModel GetStatistics(String payment_method)
        {
            string sql = null;
            StatisticsModel result = new StatisticsModel();

            if (payment_method != null)
            {
                sql = "WHERE payment_method = '" + payment_method + "' ";
            }

            List<SaleModel> Sales = db.Select(sql);

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
    }
}
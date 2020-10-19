using BurgerKing_kiosk.model;
using BurgerKing_kiosk.viewModel.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BurgerKing_kiosk.viewModel
{
    class TableViewModel
    {
        private List<SaleModel> menus = new List<SaleModel>();

        public List<SaleModel> GetFood(String cartegory)
        {
            TableDB order = new TableDB();
            menus = order.Insert(cartegory);

            return menus;
        }
    }
}

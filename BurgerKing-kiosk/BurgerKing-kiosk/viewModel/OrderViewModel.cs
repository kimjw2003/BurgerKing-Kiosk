using BurgerKing_kiosk.model;
using BurgerKing_kiosk.viewModel.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel
{
    class OrderViewModel
    {
        private List<FoodModel> menus = null;

        public List<FoodModel> GetFood(String cartegory)
        {
            OrderDB order = new OrderDB();
            menus = order.Select(cartegory);

            Console.WriteLine(menus);
            return menus;
        }

    }
}

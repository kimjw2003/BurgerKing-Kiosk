using BurgerKing_kiosk.model;
using BurgerKing_kiosk.viewModel.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel
{
    public class MenuViewModel
    {
        MenuDB menu = new MenuDB();
        public List<MenuModel> GetMenus(String cartegory)
        {
            List<MenuModel> item = new List<MenuModel>();
            item = menu.GetMenu(cartegory);

            return item;
        }

    }
}

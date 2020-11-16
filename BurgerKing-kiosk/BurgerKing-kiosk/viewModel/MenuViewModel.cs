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
        MenuDB db = new MenuDB();
        public List<MenuModel> GetMenus(string cartegory)
        {
            if(cartegory == "burger")
            {
                return App.burgerList;
            }
            else if(cartegory == "side")
            {
                return App.sideList;
            }
            else
            {
                return App.desertList;
            }
        }

        public void GetDBMenus()
        {
            Category category = (Category)0;
            App.burgerList.AddRange(db.GetMenu(category));
            category = (Category)1;
            App.sideList.AddRange(db.GetMenu(category));
            category = (Category)2;
            App.desertList.AddRange(db.GetMenu(category));
        }

    }
}

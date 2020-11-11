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
            List<MenuModel> menu = new List<MenuModel>();
            
            
            foreach (var list in App.menuList)
            {
                if(list.category.ToString() == cartegory)
                {
                    menu.Add(list);
                }
            }
            

            return menu;
        }

        public void GetDBMenus()
        {
            App.menuList = new List<MenuModel>();
            Category category = (Category)0;
            App.menuList.AddRange(db.GetMenu(category));
            category = (Category)1;
            App.menuList.AddRange(db.GetMenu(category));
            category = (Category)2;
            App.menuList.AddRange(db.GetMenu(category));
        }

    }
}

using BurgerKing_kiosk.model;
using BurgerKing_kiosk.model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel
{
    class ApplySaleViewModel
    {
        ApplySaleDB db = new ApplySaleDB();

        public void SetMenuSetting (MenuModel menu)
        {
            db.SetMenuSetting(menu);
        }
    }
}

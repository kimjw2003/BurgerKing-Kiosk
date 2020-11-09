using BurgerKing_kiosk.model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel
{
    class MoneyViewModel
    {
        MoneyDB db = new MoneyDB();
        public bool GetName(String barcode)
        {
            return db.GetUserName(barcode);
        }
    }
}

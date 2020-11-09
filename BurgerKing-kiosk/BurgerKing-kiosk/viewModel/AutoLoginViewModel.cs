using BurgerKing_kiosk.model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel
{
    class AutoLoginViewModel
    {
        AutoLoginDB db = new AutoLoginDB();

        public Boolean GetBool()
        {
            return db.GetBool();
        }

        public void SetBool(Boolean AutoLogin)
        {
            db.SetBool(AutoLogin);
        }
    }
}

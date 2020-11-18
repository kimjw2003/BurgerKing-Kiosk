using BurgerKing_kiosk.model;
using BurgerKing_kiosk.model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel
{
    class FinishViewModel
    {
        FinishDB db = new FinishDB();
        public void SetOrderData()
        {
            App.tableList[App.userData.seat - 1].OrderTime = DateTime.Now;
            string day = App.tableList[App.userData.seat - 1].OrderTime.ToString("yyyy-MM-dd");
            string time = App.tableList[App.userData.seat - 1].OrderTime.ToString("HH:mm:ss");
            for (int i=0; i < OrderModel.GetInstance().Count; i++)
            {
                db.SetOrderData(i, day, time);
            }
        }
        public void ClearData()
        {
            App.userData = new UserModel();
            App.OrderNumber++;
            OrderModel.GetInstance().Clear();
        }

        public String AddZero(int num)
        {
            if (num < 10)
            {
                return "00" + num;
            }
            else if (num < 100)
            {
                return "0" + num;
            }
            else
            {
                return num + "";
            }
        }
    }
}

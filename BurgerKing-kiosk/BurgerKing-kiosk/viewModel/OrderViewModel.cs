using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurgerKing_kiosk.model;

namespace BurgerKing_kiosk.viewModel
{
    public class OrderViewModel
    {
        public List<OrderModel> GetOrderList()
        {
            return App.userData.order;
        }
        public void AddOrder(int id)
        {
            OrderModel food = new OrderModel();
            food.id = id;
            App.userData.order.Add(food);
        }
        public void DeleteAll()
        {
            App.userData.order.Clear();
            App.userData.seat = 0;
            App.userData.price = 0;
        }
        public List<OrderModel> DeleteOrder(int id)
        {
            int lengh = App.userData.order.Count;
            int i = 0;
            foreach (var list in App.userData.order)
            {
                if (i == lengh)
                {
                    App.userData.price -= list.price;
                }
                i++;
            }
            App.userData.order.RemoveAt(lengh);

            return App.userData.order;
        }
        public bool CheckTable()
        {
            if (App.userData.seat != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Table(int id)
        {
            App.userData.seat = id;
        }
    }
}

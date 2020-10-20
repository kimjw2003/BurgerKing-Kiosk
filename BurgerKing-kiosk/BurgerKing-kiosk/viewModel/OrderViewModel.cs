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
        public List<OrderModel> order = new List<OrderModel>();
        private int table = 0;

        public List<OrderModel> Show()
        {
            return order;
        }
        public void AddFood(int id)
        {
            OrderModel food = new OrderModel();
            food.id = id;
            order.Add(food);
        }
        public void DeleteAll()
        {
            this.order.Clear();
            this.table = 0;
        }
        public List<OrderModel> Delete(int id)
        {
            int lengh = order.Count;
            order.RemoveAt(lengh);

            return order;
        }
        public bool CheckTable()
        {
            if (table != 0)
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
            this.table = id;
        }
    }
}

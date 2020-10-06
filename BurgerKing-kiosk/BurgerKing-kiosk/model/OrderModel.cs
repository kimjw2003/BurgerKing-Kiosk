using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model
{
    class OrderModel
    {
        private List<FoodModel> foods;
        private int table = 0;
        
        public void AddFood(int id)
        {
            
        }
        public void DeleteAll()
        {
            this.foods = null;
            this.table = 0;
        }
        public List<FoodModel> Delete(int id)
        {
            return foods;
        }
        public bool CheckTable(int id)
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

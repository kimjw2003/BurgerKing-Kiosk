using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model
{
    class MenuViewModel
    {
        private List<FoodModel> foods = null;
        private int table = 0;

        public List<FoodModel> Show()
        {
            return foods;
        }
        public void AddFood(int id)
        {
            FoodModel food = new FoodModel();
            food.id = id;
            foods.Add(food);
        }
        public void DeleteAll()
        {
            this.foods.Clear();
            this.table = 0;
        }
        public List<FoodModel> Delete(int id)
        {
            int lengh = foods.Count;
            foods.RemoveAt(lengh);

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

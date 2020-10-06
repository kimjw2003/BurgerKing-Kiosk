using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model
{
    class FoodModel
    {
        public int id { get; set; }
        public String name { get; set; }
        public int price { get; set; }
        public String picture { get; set; }
        public int sale { get; set; }

        public FoodModel()
        {
        }
        public FoodModel(int id, string name, int price, string picture, int sale)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.picture = picture;
            this.sale = sale;
        }
    }
}

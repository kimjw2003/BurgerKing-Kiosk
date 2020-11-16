using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model
{

    public class OrderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int salePrice { get; set; }
        public int sale { get; set; }
        public Category category { get; set; }

        private static List<OrderModel> instance;

        public static List<OrderModel> GetInstance()
        {
            if (instance == null)
                instance = new List<OrderModel>();

            return instance;
        }
    }
}

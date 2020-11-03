using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model
{

    public class OrderModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public int price { get; set; }
        public int sale { get; set; }

        private static List<OrderModel> instance;

        public static List<OrderModel> GetInstance()
        {
            if (instance == null)
                instance = new List<OrderModel>();

            return instance;
        }
    }
}

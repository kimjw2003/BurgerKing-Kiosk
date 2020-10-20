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
        public String name { get; set; }
        public int price { get; set; }
        public int sale { get; set; }
        public int amount { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model
{
    public class UserModel
    {
        public String payment { get; set; } = "";
        public String name { get; set; } = "";
        public String barcode { get; set; } = "";
        public int seat { get; set; } = 0;
        public int price { get; set; } = 0;
        public List<OrderModel> order { get; set; }
    }
}

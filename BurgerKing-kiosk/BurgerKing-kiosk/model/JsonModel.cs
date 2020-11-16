using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model
{
    public class JsonModel
    {
        public int MSGType { get; set; }
        public String Id { get; set; }
        public String Content { get; set; } = "";
        public String ShopName { get; set; } = "BurgerKing";
        public String OrderNumber { get; set; }
        public bool Group { get; set; } = true;
        public List<OrderModel> Menus { get; set; }
    }
}

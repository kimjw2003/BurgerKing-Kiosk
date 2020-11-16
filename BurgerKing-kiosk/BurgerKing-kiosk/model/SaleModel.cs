using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model
{
    class SaleModel
    {
        public int idx { get; set; }
        public String menu { get; set; }
        public String category { get; set; }
        public String user { get; set; }
        public DateTime day { get; set; }
        public int price { get; set; }
        public int seat { get; set; }
        public int sale { get; set; }
        public String payment_method { get; set; }
        public int count { get; set; }

    }
}

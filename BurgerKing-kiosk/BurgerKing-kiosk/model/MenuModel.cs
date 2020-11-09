using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model
{
    public class MenuModel
    {
        public Category category { get; set; }
        public int id { get; set; }
        public String name { get; set; }
        public int price { get; set; }
        public String picture { get; set; }
        public int sale { get; set; }
        public int amount { get; set; }
        public int page { get; set; }

    }

    public enum Category
    {
        burger,
        side,
        desert,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.view.Pages
{
    public class Food
    {
        public Category category { get; set; }
        public string imageData { get; set; }
        public string title { get; set; }
    }

    public enum Category
    {
        BURGER,
        SIDE,
        DESERT,
    }
}

using BurgerKing_kiosk.model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel
{
    class EnergizingTimeViewModel
    {
        EnergizingTimeDB db = new EnergizingTimeDB();

        public TimeSpan GetTime()
        {
            List<TimeSpan> times = db.GetTime();
            TimeSpan Runtime = new TimeSpan(00,00,00);

            foreach (TimeSpan time in times)
            {
                Runtime += time;
            }

            return Runtime;
        }
    }
}

using BurgerKing_kiosk.model;
using BurgerKing_kiosk.viewModel.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BurgerKing_kiosk.viewModel
{
    class TableViewModel
    {

        public List<TableModel> GetSeat()
        {
            TableDB db = new TableDB();
            App.tableList = db.GetTable();
            return App.tableList;
        }
    }
}

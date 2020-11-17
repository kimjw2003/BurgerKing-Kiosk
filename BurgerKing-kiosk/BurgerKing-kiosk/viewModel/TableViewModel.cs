using BurgerKing_kiosk.model;
using BurgerKing_kiosk.model.DB;
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
    public class TableViewModel
    {
        TableDB db = new TableDB();
        public void GetTables()
        {
            App.tableList = db.GetTable();
        }
        public void UpdateTables(int id,bool isUsed)
        {
            Console.WriteLine(id);
            db.UpdateTable(id, isUsed);
            App.tableList = new List<TableModel>();
            App.tableList = db.GetTable();
        }
    }
}

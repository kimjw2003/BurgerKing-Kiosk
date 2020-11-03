using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model
{
    public class TableModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int id { get; set; }
        public String time { get; set; } = "";

        private bool _isUsed = false;
        public bool IsUsed
        {
            get => _isUsed;
            set
            {
                _isUsed = value;
                NotifyPropertyChanged(nameof(IsUsed));
            }
        }
    }
}

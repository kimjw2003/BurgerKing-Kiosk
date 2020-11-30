using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.model
{
    public class ServerModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool isConnect = false;
        public bool IsConnect
        {
            get => isConnect;
            set
            {
                isConnect = value;
                NotifyPropertyChanged(nameof(isConnect));
            }
        }
    }
}

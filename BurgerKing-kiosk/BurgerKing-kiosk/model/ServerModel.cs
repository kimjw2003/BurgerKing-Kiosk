using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace BurgerKing_kiosk.model
{
    public class ServerModel : INotifyPropertyChanged
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
                TimerEvent();
                NotifyPropertyChanged(nameof(IsConnect));
            }
        }
        private void TimerEvent()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += new EventHandler((object sender, EventArgs e) => {
                IsConnect = App.server.CheckClient();
                //Console.WriteLine(IsConnect);
            });
            timer.Start();
        }
    }
}

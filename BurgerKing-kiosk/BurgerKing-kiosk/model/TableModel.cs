using BurgerKing_kiosk.viewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace BurgerKing_kiosk.model
{
    static class Constants
    {
        public const int second = 60;
    }
    public class TableModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int id { get; set; }
        private int remainSeconds { get; set; }
        public int RemainSeconds
        {
            get => remainSeconds;
            set
            {
                remainSeconds = value;
                NotifyPropertyChanged(nameof(RemainSeconds));
            }
        }
        private DateTime endTime { get; set; }
        public DateTime EndTime
        {
            get => endTime;
            set
            {
                endTime = value;
                NotifyPropertyChanged(nameof(EndTime));
            }
        }
        private DateTime orderTime { get; set; }
        public DateTime OrderTime
        {
            get => orderTime;
            set
            {
                orderTime = value;
                NotifyPropertyChanged(nameof(OrderTime));
                endTime = orderTime.AddSeconds(Constants.second);
                TimeSpan second = endTime - DateTime.Now;
                if ((int)second.TotalSeconds >= 0 && (int)second.TotalSeconds <= 60)
                {
                    RemainSeconds = (int)second.TotalSeconds;
                    IsUsed = true;
                    SetRemainTimerEvent();
                }
            }
        }

        private bool isUsed = false;
        public bool IsUsed
        {
            get => isUsed;
            set
            {
                isUsed = value;
                NotifyPropertyChanged(nameof(IsUsed));
            }
        }
        private void SetRemainTimerEvent()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler((object sender, EventArgs e) => {
                if (RemainSeconds < 1)
                {
                    timer.Stop();
                    IsUsed = false;
                }
                RemainSeconds -= 1;
            });
            timer.Start();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;

namespace BurgerKing_kiosk
{
    /// <summary>
    /// Statistics.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Statistics : Window
    {
        DispatcherTimer timer2 = new DispatcherTimer();
        Stopwatch sw = new Stopwatch();
        String currentTime;
        TimeSpan tts;

        public Statistics(TimeSpan ts)
        {
            InitializeComponent();

            tts = ts;

            timer2.Interval = new TimeSpan(0, 0, 1);
            timer2.Tick += Stopwatch;
            timer2.Start();

            sw.Start();
        }

        private void Stopwatch(object sender, EventArgs e)
        {
            TimeSpan ts = sw.Elapsed;
            currentTime = String.Format("통계 {0:00}:{1:00}:{2:00}",
            ts.Hours+tts.Hours, ts.Minutes+tts.Minutes, ts.Seconds+tts.Seconds);
            Console.WriteLine(currentTime);
        }
    }
}

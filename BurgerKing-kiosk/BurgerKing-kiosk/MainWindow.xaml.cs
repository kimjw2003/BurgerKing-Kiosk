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

namespace BurgerKing_kiosk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();

            this.PreviewKeyDown += new KeyEventHandler(F2_KeyDown);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e) {
            frame_content.Source = new Uri("view/Pages/Home.xaml", UriKind.Relative);
        }

        private void F2_KeyDown(object sender, KeyEventArgs e)
        {
            Uri og = frame_content.Source;
            Uri compate = new Uri("view/Pages/Home.xaml", UriKind.Relative);
            if(og == compate)
            {
                if (e.Key == Key.F2)
                    frame_content.Source = new Uri("view/Pages/Statistics.xaml", UriKind.Relative);
            }
        }
    }
}

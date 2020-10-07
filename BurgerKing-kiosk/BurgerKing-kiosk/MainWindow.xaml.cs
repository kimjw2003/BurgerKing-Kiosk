using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Diagnostics;

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

            timer.Tick += Stopwatch;

            this.PreviewKeyDown += MainWindow_PreviewKeyDown;

            frame_content.Navigate(new Uri("view/Pages/Home.xaml", UriKind.Relative));
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                if (!frame_content.CanGoBack)
                {
                    Statistics statistics = new Statistics();
                    statistics.Show();
                    Close();
                } 
            }

        }

        private void Stopwatch(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            while (frame_content.CanGoBack == true)
            {
                frame_content.GoBack();
            }

            //frame_content.Navigate(new Uri("view/Pages/Home.xaml", UriKind.Relative));

        }
    }
}

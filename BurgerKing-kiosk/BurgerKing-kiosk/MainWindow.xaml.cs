using System;
using System.Windows;
using System.Windows.Input;
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

            this.PreviewKeyDown += MainWindow_PreviewKeyDown;
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                if (!frame_content.CanGoBack)
                    frame_content.Source = new Uri("view/Pages/Statistics.xaml", UriKind.Relative);
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

            do
            {
                Console.WriteLine("되는 중");
                frame_content.RemoveBackEntry();
            } while (frame_content.CanGoBack);

                frame_content.Source = new Uri("view/Pages/Home.xaml", UriKind.Relative);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BurgerKing_kiosk
{
    /// <summary>
    /// HomePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HomePage : Page
    {
        private BackgroundWorker loadingThread;

        public HomePage()
        {
            
            InitBW();
            loadingThread.RunWorkerAsync();
        }

        private void InitBW()
        {
            loadingThread = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            loadingThread.DoWork += Thread_DoWork;
            loadingThread.RunWorkerCompleted += Thread_RunWorkerCompleted;
        }

        private void Thread_DoWork(object sender, DoWorkEventArgs e)
        {
            InitializeComponent();
        }

        private void Thread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("로딩끝");
        }
        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                NavigationService.Navigate(new Uri("view/Pages/Order.xaml", UriKind.Relative));
            }
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                NavigationService.Navigate(new Uri("view/Pages/Order.xaml", UriKind.Relative));
            }
        }

        private void InitLoadWindow()
        {

        }

    }
}

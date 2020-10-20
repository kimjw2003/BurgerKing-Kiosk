using BurgerKing_kiosk.view;
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
        LoadingWindow lw;

        public HomePage()
        {
            InitializeComponent();
            //InitBW();
            //InitLoadWindow();
        }

        /*
        private void InitBW()
        {
            loadingThread = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            loadingThread.DoWork += Thread_DoWork;
            loadingThread.ProgressChanged += Thread_ProgressChanged;
            loadingThread.RunWorkerCompleted += Thread_RunWorkerCompleted;
        }

        private void Thread_DoWork(object sender, DoWorkEventArgs e)
        {
            InitializeComponent();
            for (int i = 0; i < 5000000; i++) ;
        }

        private void Thread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int per = e.ProgressPercentage;
            lw.progressBar.Value = per;
        }

        private void Thread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("로딩끝");
            lw.Close();
        }

        private void InitLoadWindow()
        {
            lw = new LoadingWindow();
            lw.Show();
            loadingThread.RunWorkerAsync();
        }
        */

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
            /*if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                NavigationService.Navigate(new Uri("view/Pages/Order.xaml", UriKind.Relative));
            }*/

            Statistics statistics = new Statistics();
            statistics.Show();
        }

    }
}

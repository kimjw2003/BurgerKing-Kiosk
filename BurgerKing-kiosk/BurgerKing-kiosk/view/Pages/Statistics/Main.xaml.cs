using BurgerKing_kiosk.model;
using BurgerKing_kiosk.model.DB;
using BurgerKing_kiosk.viewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BurgerKing_kiosk.view.Pages.Statistics
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Main : Page
    {

        DispatcherTimer timer = new DispatcherTimer();

        EnergizingTimeViewModel RuntimeVM = new EnergizingTimeViewModel();
        TimeSpan LastRuntime;

        AutoLoginViewModel loginVM = new AutoLoginViewModel();
        SaleViewModel SaleVM = new SaleViewModel();

        public Main()
        {
            LastRuntime = RuntimeVM.GetTime();

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();

            InitializeComponent();
            this.Loaded += Main_Loaded;
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            LoginOption.IsChecked = loginVM.GetBool();
            SetSaleText(null);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan TotalRuntime = App.ts + LastRuntime;
            TotalRuntimeString = String.Format("{0:00}:{1:00}:{2:00}",
            TotalRuntime.Hours, TotalRuntime.Minutes, TotalRuntime.Seconds);

            DataContext = null;
            DataContext = this;
        }

        private void SetSaleText(string payment_method) //db에서 할인율 불러와서 계산해야함
        {
            StatisticsModel result = SaleVM.GetStatistics(payment_method);

            WholeSalePrice = result.OriginalPrice;
            PureSalePrice = result.PureSalePrice;
            SalePrice = result.SalePrice;

            DataContext = null;
            DataContext = this;
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginOption.IsChecked == (bool?)true)
            {
                loginVM.SetBool(true);
                MessageBox.Show("자동로그인이 적용되었습니다");
            }
            else
            {
                loginVM.SetBool(false);
                MessageBox.Show("자동로그인이 해제되었습니다");
            }

        }

        private void AllBtnClick(object sender, RoutedEventArgs e)
        {
            SetSaleText(null);
        }

        private void CashBtnClick(object sender, RoutedEventArgs e)
        {
            SetSaleText("cash");
        }

        private void CreditBtnClick(object sender, RoutedEventArgs e)
        {
            SetSaleText("credit");
        }

        public string TotalRuntimeString { get; set; }
        public int WholeSalePrice { get; set; }
        public int PureSalePrice { get; set; }
        public int SalePrice { get; set; }

     
    }
}


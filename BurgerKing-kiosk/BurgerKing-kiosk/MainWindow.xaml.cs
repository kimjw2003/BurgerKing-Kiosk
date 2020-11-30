using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Diagnostics;
using BurgerKing_kiosk.model;
using System.Windows.Forms;
using BurgerKing_kiosk.view.Pages;
using BurgerKing_kiosk.model.DB;
using BurgerKing_kiosk.viewModel;

namespace BurgerKing_kiosk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        AutoLoginViewModel loginVM = new AutoLoginViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
            
            this.PreviewKeyDown += MainWindow_PreviewKeyDown;

            App.server.ConnectionServer();
            GetDB();

            this.Loaded += MainWindow_Loaded;
        }

        private void GetDB()
        {
            App.menuVM.GetDBMenus();

            TableDB db = new TableDB();
            App.tableList = db.GetTable();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (loginVM.GetBool())
            {
                frame_content.Navigate(new Uri("view/Pages/Home.xaml", UriKind.Relative));
            }
            else
            {
                LoginCheck();
            }

            DataContext = App.server.sModel;
        }

        public void ServerOn(object sender, RoutedEventArgs e)
        {
            if (!App.server.CheckClient())
            {
                App.server.ConnectionServer();
            }
        }

        private void LoginCheck()
        {
            LoginWin login = new LoginWin();
            login.Owner = this;

            bool? result = login.ShowDialog();

            if (result == true)
            {
                frame_content.Navigate(new Uri("view/Pages/Home.xaml", UriKind.Relative));

                if (login.CheckBox.IsChecked == (bool ?)true)
                {
                    loginVM.SetBool(true);
                }
            }
        }

        private void MainWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                if (!frame_content.CanGoBack)
                {
                    Statistics statistics = new Statistics();
                    statistics.Show();
                } 
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            if (App.totalPrice != 0)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("주문을 취소하시겠습니까?", "취소", MessageBoxButton.OKCancel);
                if (result != MessageBoxResult.OK)
                {
                    return;
                }
            }
            while (frame_content.CanGoBack == true)
            {
                frame_content.GoBack();
            }
            if (App.userData.seat != 0)
            {
                App.tableList[App.userData.seat - 1].IsUsed = false;
            }
            FinishViewModel viewModel = new FinishViewModel();
            viewModel.ClearData();
        }
    }
}

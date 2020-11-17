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

            App.menuVM.GetDBMenus();
            App.server.ConnectionServer();
            JsonModel json = new JsonModel();
            json.MSGType = 0;
            json.Id = "2110";
            App.server.SendServer(json);

            App.tableList.Add(new TableModel()
            {
                id = 1,
                IsUsed = false
            });
            App.tableList.Add(new TableModel()
            {
                id = 2,
                IsUsed = false
            });
            App.tableList.Add(new TableModel()
            {
                id = 3,
                IsUsed = false
            });
            App.tableList.Add(new TableModel()
            {
                id = 4,
                IsUsed = false
            });
            App.tableList.Add(new TableModel()
            {
                id = 5,
                IsUsed = false
            });
            App.tableList.Add(new TableModel()
            {
                id = 6,
                IsUsed = false
            });
            App.tableList.Add(new TableModel()
            {
                id = 7,
                IsUsed = false
            });
            App.tableList.Add(new TableModel()
            {
                id = 8,
                IsUsed = false
            });
            App.tableList.Add(new TableModel()
            {
                id = 9,
                IsUsed = false
            });

            this.Loaded += MainWindow_Loaded;
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
            while (frame_content.CanGoBack == true)
            {
                frame_content.GoBack();
                OrderModel.GetInstance().Clear();
            }
        }
    }
}

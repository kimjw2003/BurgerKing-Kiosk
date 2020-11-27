using BurgerKing_kiosk.model;
using BurgerKing_kiosk.viewModel;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace BurgerKing_kiosk
{
    /// <summary>
    /// FinishPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FinishPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        FinishViewModel viewModel = new FinishViewModel();
        int second = 1;
        public FinishPage()
        {
            InitializeComponent();
            Name.Text = App.userData.name;
            CardNum.Text = App.userData.barcode;
            OrderNum.Text = OrderNum.Text = viewModel.AddZero(App.OrderNumber);
            totalPrice.Text = App.totalPrice.ToString();

            TableViewModel tViewModel = new TableViewModel();
            tViewModel.UpdateTables(App.userData.seat);

            JsonModel json = new JsonModel();
            json.MSGType = 2;
            json.Id = "2102";
            json.OrderNumber = OrderNum.Text;
            json.Menus = App.userData.order;
            //App.server.SendServer(json);

            viewModel.SetOrderData();
            viewModel.ClearData();

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (second == 5)
            {
                timer.Stop();
                while (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
            }
            second += 1;
        }
    }
}

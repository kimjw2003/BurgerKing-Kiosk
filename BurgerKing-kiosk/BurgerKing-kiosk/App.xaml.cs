using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Diagnostics;
using BurgerKing_kiosk.model;
using BurgerKing_kiosk.viewModel;

namespace BurgerKing_kiosk
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 


    public partial class App : Application
    {
        public static MenuViewModel menuVM = new MenuViewModel();
        public static List<MenuModel> menuList = new List<MenuModel>();

        public static OrderViewModel orderVM = new OrderViewModel();
        public static List<OrderModel> orderList = new List<OrderModel>();
        public static int table = 0;
        public static int price = 0;

        DispatcherTimer timer = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
                
        public App()
        {
  
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            stopWatch.Start();
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = stopWatch.Elapsed;
           String currentTime = String.Format("{0:00}:{1:00}:{2:00}",
            ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        }
    }
}

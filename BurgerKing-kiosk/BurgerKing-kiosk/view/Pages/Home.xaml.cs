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
        NavigationWindow win;

        public HomePage()
        {
            
            InitializeComponent();
            this.Loaded += HomePage_Loaded;
            //MainWindow.KeyDown += new KeyEventHandler(Window_KeyDown);
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            this.KeyDown += new KeyEventHandler(Window_KeyDown);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                //if (!frame_content.CanGoBack)
                
                    Statistics statistics = new Statistics();
                    statistics.Show();
                
            }
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
            Statistics statistics = new Statistics();
            statistics.Show();
        }
    }
}

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

namespace BurgerKing_kiosk
{
    /// <summary>
    /// HomePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("view/Pages/Order.xaml", UriKind.Relative));
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
                Console.WriteLine(e.Key);
                NavigationService.Navigate(new Uri("view/Pages/Statistics.xaml", UriKind.Relative));
        }
    }
}

using BurgerKing_kiosk.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// TablePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TablePage : Page
    {
        MenuViewModel menu = new MenuViewModel();
        public TablePage()
        {
            InitializeComponent();
            this.DataContext = new viewModel.TableViewModel();
        }
        private void Click_Seat(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Debug.WriteLine(button.Name);
            if (!menu.CheckTable())
            {
                return;
            }
            switch (button.Name)
            {
                case "one":
                    break;
                case "two":
                    break;
                case "three":
                    break;
                case "four":
                    break;
                case "five":
                    break;
                case "six":
                    break;
                case "seven":
                    break;
                case "eight":
                    break;
                case "nine":
                    break;
            }
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void GoNext(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("view/Pages/HowPay.xaml", UriKind.Relative));
        }
    }
}

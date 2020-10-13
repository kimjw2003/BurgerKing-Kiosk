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
    /// PlacePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PlacePage : Page
    {
        public PlacePage()
        {
            InitializeComponent();

            this.DataContext = new viewModel.PlaceViewModel();
        }

        private void Packing(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("view/Pages/Table.xaml", UriKind.Relative));
        }
        private void Burial_meal(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("view/Pages/HowPay.xaml", UriKind.Relative));
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

using BurgerKing_kiosk.model;
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
    /// HowPayPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HowPayPage : Page
    {
        public HowPayPage()
        {
            InitializeComponent();
            Order.ItemsSource = listFood.ToList();
            this.DataContext = new viewModel.HowPayViewModel();
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void Money(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("view/Pages/Money.xaml", UriKind.Relative));
        }
        private void Card(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("view/Pages/Card.xaml", UriKind.Relative));
        }

        private List<FoodModel> listFood = new List<FoodModel>()
        {
            new FoodModel(){name="뭐시기",price=1000,amount=1},
            new FoodModel(){name="뭐시기",price=1000,amount=1},
            new FoodModel(){name="뭐시기",price=1000,amount=1},
            new FoodModel(){name="뭐시기",price=1000,amount=1},
        };
    }
}

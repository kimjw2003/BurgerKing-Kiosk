using BurgerKing_kiosk.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            orderCount.Text = App.orderVM.GetOrderList().Count.ToString();
            Order.ItemsSource = App.orderVM.GetOrderList();
            totalPrice.Text = App.totalPrice + "";
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
    }
}

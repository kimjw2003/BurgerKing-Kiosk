using BurgerKing_kiosk.viewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BurgerKing_kiosk.view.Pages
{
    /// <summary>
    /// Money.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Money : Page
    {
        MoneyViewModel viewModel = new MoneyViewModel();
        public Money()
        {
            InitializeComponent();
            barcode.Focus();
            totalPrice.Text = App.totalPrice + "";
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void barcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine(barcode.Text);
            if (viewModel.GetName(barcode.Text))
            {
                App.userData.barcode = barcode.Text;
                App.userData.payment = "cash";
                NavigationService.Navigate(new Uri("view/Pages/Finish.xaml", UriKind.Relative));
            }
        }
    }
}

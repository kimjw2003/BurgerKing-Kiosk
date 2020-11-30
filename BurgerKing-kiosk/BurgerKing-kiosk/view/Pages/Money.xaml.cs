using BurgerKing_kiosk.viewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            Console.WriteLine(barcode.Text);
            if (e.Key == Key.Return)
            {
                if (viewModel.GetName(barcode.Text))
                {
                    App.userData.barcode = barcode.Text;
                    App.userData.payment = "cash";
                    NavigationService.Navigate(new Uri("view/Pages/Finish.xaml", UriKind.Relative));
                }
                else
                {
                    barcode.Text = "";
                    MessageBox.Show("존재하지 않는 회원입니다.");
                }
            }
        }
    }
}

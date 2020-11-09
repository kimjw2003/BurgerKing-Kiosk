using BurgerKing_kiosk.viewModel;
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
    /// CardPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CardPage : Page
    {
        CardViewModel viewModel = new CardViewModel();
        public CardPage()
        {
            InitializeComponent();

            this.DataContext = new viewModel.CardViewModel();

            webcam.CameraIndex = 0;
            totalPrice.Text = App.totalPrice + "";
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void webcam_QrDecoded(object sender, string userName) {
            if (viewModel.GetBarcode(userName))
            {
                App.userData.name = userName;
                NavigationService.Navigate(new Uri("view/Pages/Finish.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("회원이 아니십니다.");
            }
        }

    }
}

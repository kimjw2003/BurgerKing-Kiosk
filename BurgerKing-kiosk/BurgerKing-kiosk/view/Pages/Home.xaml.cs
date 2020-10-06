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
            this.Loaded += HomePage_Loaded;
            this.PreviewKeyDown += HomePage_PreviewKeyDown;
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("로드 됨");
            
        }

        private void HomePage_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
                NavigationService.Navigate(new Uri("view/Pages/Statistics.xaml", UriKind.Relative));
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("view/Pages/Order.xaml", UriKind.Relative));
        }

    }
}

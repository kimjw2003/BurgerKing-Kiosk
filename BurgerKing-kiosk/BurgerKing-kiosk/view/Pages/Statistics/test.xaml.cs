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

namespace BurgerKing_kiosk.view.Pages.Statistics
{
    /// <summary>
    /// test.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class test : Page
    {
        public test()
        {
            InitializeComponent();

            this.Loaded += Test_Loaded;
        }

        private void Test_Loaded(object sender, RoutedEventArgs e)
        {
            lbCategory.SelectedIndex = 0;
        }

        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e) //카테고리 선택
        {

            if (lbCategory.SelectedIndex == -1) return;

            //Category category = (Category)lbCategory.SelectedIndex;
            //lbFood.ItemsSource = App.menuVM.GetMenus(category.ToString());

            if (lbCategory.SelectedIndex == 0)
            {
                frame_content.Navigate(new Uri("view/Pages/Statistics/Chart.xaml", UriKind.Relative));
            }
            else if(lbCategory.SelectedIndex == 1)
            {
                frame_content.Navigate(new Uri("view/Pages/Statistics/Category_Chart.xaml", UriKind.Relative));
            }
            else if (lbCategory.SelectedIndex == 2)
            {
                frame_content.Navigate(new Uri("view/Pages/Statistics/Seat_Chart.xaml", UriKind.Relative));
            }
            else if(lbCategory.SelectedIndex == 3)
            {
                frame_content.Navigate(new Uri("view/Pages/Statistics/Daily_Chart.xaml", UriKind.Relative));
            }
            else if (lbCategory.SelectedIndex == 4)
            {
                frame_content.Navigate(new Uri("view/Pages/Statistics/UserList.xaml", UriKind.Relative));
            }
            else if(lbCategory.SelectedIndex == 5)
            {
                frame_content.Navigate(new Uri("view/Pages/Statistics/Apply_Discount.xaml", UriKind.Relative));
            }
            else
            {
                frame_content.Navigate(new Uri("view/Pages/Statistics/Main.xaml", UriKind.Relative));
            }
        }
    }
}

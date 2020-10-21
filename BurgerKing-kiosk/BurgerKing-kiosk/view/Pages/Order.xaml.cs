
using BurgerKing_kiosk.model;
using BurgerKing_kiosk.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Windows.Threading;
using static BurgerKing_kiosk.model.MenuModel;

namespace BurgerKing_kiosk
{
    /// <summary>
    /// OrderPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();

            this.Loaded += OrderPage_Loaded;

            

            menu_List.ItemsSource = OrderData.GetInstance();
        }

        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lbCategory.SelectedIndex == -1) return;

            Category category = (Category)lbCategory.SelectedIndex;
            lbFood.ItemsSource = App.menuVM.GetMenus(category.ToString());
            lbFood.Items.Refresh();
        }

        private void OrderPage_Loaded(object sender, RoutedEventArgs e) {
            lbCategory.SelectedIndex = 0; //처음 실행 시 첫번째 카테고리가 선택되도록
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void order_order_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/Pages/Place.xaml", UriKind.Relative));
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            MenuModel orderList = (MenuModel)lbFood.SelectedItem;
            
            if(orderList != null)
            {
                OrderData.GetInstance().Add(new OrderData() { menuName = orderList.name, menuCount = 1, menuPrice = orderList.price });
                menu_List.Items.Refresh();
            }
            else
            {
                return;
            }


        }

        private void order_cancle_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/Pages/Home.xaml", UriKind.Relative));
            
        }

        private void del_Btn_Click(object sender, RoutedEventArgs e)
        {
            OrderData.GetInstance().Clear();
            menu_List.Items.Refresh();
        }
    }

    class OrderData
    {
        public string menuName { get; set; }
        public int menuCount { get; set; }
        public int menuPrice { get; set; }

        private static List<OrderData> instance;

        public static List<OrderData> GetInstance()
        {
            if (instance == null)
                instance = new List<OrderData>();

            return instance;
        }
    }


}

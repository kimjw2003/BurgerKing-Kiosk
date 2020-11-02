
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

        int totalPrice = 0;

        public OrderPage()
        {
            InitializeComponent();

            this.Loaded += OrderPage_Loaded;

            allPrice.Text = totalPrice + "";

            ordered_Menu_List.ItemsSource = OrderData.GetInstance();
        }

        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lbCategory.SelectedIndex == -1) return;

            Category category = (Category)lbCategory.SelectedIndex;
            lbFood.ItemsSource = App.menuVM.GetMenus(category.ToString());
            lbFood.Items.Refresh();
        }

        private void OrderPage_Loaded(object sender, RoutedEventArgs e) { //주문페이지가 시작되면 실행되는 함수
            lbCategory.SelectedIndex = 0; //처음 실행 시 첫번째 카테고리가 선택되도록
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e) //다음메뉴 버튼이 눌러지면 실행
        {

        }

        private void order_order_Btn_Click(object sender, RoutedEventArgs e) //주문버튼이 눌러지면 실행
        {
            NavigationService.Navigate(new Uri("/view/Pages/Place.xaml", UriKind.Relative));
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e) // 메뉴 리스트가 눌러지면 실행
        {
            
            MenuModel orderList = (MenuModel)lbFood.SelectedItem;
            
            if(orderList != null)
            {
                OrderData.GetInstance().Add(new OrderData() { menuName = orderList.name, menuCount = 1, menuPrice = orderList.price });

                int selectedPrice = 0;
                for(int i = 0; i<OrderData.GetInstance().Count; i++)
                {
                    selectedPrice = OrderData.GetInstance()[i].menuPrice;
                }
                int beforeTotalPrice = int.Parse(allPrice.Text);
                allPrice.Text = beforeTotalPrice + selectedPrice + "";
                ordered_Menu_List.Items.Refresh();
            }
            else
            {
                return;
            }


        }

        private void order_cancle_Btn_Click(object sender, RoutedEventArgs e) //주문취소를 누르면 실행
        {
            NavigationService.Navigate(new Uri("/view/Pages/Home.xaml", UriKind.Relative));

            OrderData.GetInstance().Clear();
            ordered_Menu_List.Items.Refresh();
        }

        private void allDel_Btn_Click(object sender, RoutedEventArgs e) //모두삭제 버튼
        {
            OrderData.GetInstance().Clear();
            ordered_Menu_List.Items.Refresh();

            totalPrice = 0;
            allPrice.Text = totalPrice.ToString();
        }

        private void ordered_Menu_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void upBtn_Click(object sender, RoutedEventArgs e) // +버튼 누르면 실행
        {
            OrderData data = (sender as Button).DataContext as OrderData;
            data.menuCount += 1;

            if (OrderData.GetInstance().Exists(x => x.menuName == data.menuName))
            {
                var allPrice_Int = int.Parse(allPrice.Text);
                allPrice_Int += data.menuPrice;

                allPrice.Text = allPrice_Int.ToString();
            }

                ordered_Menu_List.Items.Refresh();
        }
        private void downBtn_Click(object sender, RoutedEventArgs e) // -버튼누르면 실행
        {
            OrderData data = (sender as Button).DataContext as OrderData;
            
            data.menuCount -= 1;
            if(data.menuCount < 1)
            {
                if (OrderData.GetInstance().Exists(x => x.menuName == data.menuName))
                {
                    var allPrice_Int = int.Parse(allPrice.Text);
                    allPrice_Int -= data.menuPrice;

                    allPrice.Text = allPrice_Int.ToString();

                    OrderData.GetInstance().Remove(data);

                }

            }

            if (OrderData.GetInstance().Exists(x => x.menuName == data.menuName))
            {
                var allPrice_Int = int.Parse(allPrice.Text);
                allPrice_Int -= data.menuPrice;

                allPrice.Text = allPrice_Int.ToString();

            }

            ordered_Menu_List.Items.Refresh();
            

            

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

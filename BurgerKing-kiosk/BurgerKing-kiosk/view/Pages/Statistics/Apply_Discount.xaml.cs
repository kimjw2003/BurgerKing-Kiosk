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

namespace BurgerKing_kiosk.view.Pages.Statistics
{
    /// <summary>
    /// Apply_Discount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Apply_Discount : Page
    {

        int totalPrice = 0;
        public Apply_Discount()
        {
            InitializeComponent();

            this.Loaded += OrderPage_Loaded;

            //allPrice.Text = totalPrice + "";

           // ordered_Menu_List.ItemsSource = OrderData.GetInstance();
        }

        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lbCategory.SelectedIndex == -1) return;

            Category category = (Category)lbCategory.SelectedIndex;
            lbFood.ItemsSource = App.menuVM.GetMenus(category.ToString());
            lbFood.Items.Refresh();
        }

        private void OrderPage_Loaded(object sender, RoutedEventArgs e)
        {
            lbCategory.SelectedIndex = 0; //처음 실행 시 첫번째 카테고리가 선택되도록
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void order_order_Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("할인이 적용되었습니다");
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            MenuModel orderList = (MenuModel)lbFood.SelectedItem;

            if (orderList != null)
            {
                OrderData.GetInstance().Add(new OrderData() { menuName = orderList.name, menuCount = 1, menuPrice = orderList.price });

                int selectedPrice = 0;
                for (int i = 0; i < OrderData.GetInstance().Count; i++)
                {
                    selectedPrice = OrderData.GetInstance()[i].menuPrice;
                }
                //int beforeTotalPrice = int.Parse(allPrice.Text);
                //allPrice.Text = beforeTotalPrice + selectedPrice + "";
                //ordered_Menu_List.Items.Refresh();
            }
            else
            {
                return;
            }


        }

        private void order_cancle_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void del_Btn_Click(object sender, RoutedEventArgs e)
        {
            OrderData.GetInstance().Clear();
           // ordered_Menu_List.Items.Refresh();
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


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
        private static OrderData instance;


        public Apply_Discount()
        {
            InitializeComponent();

            this.Loaded += OrderPage_Loaded;

            this.DataContext = new OrderData();

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
                instance = new OrderData() { menuName = orderList.name, menuPrice = orderList.price, menuImg = orderList.picture, SalePercent = orderList.sale, Category = orderList.category.ToString() };
                
                Uri imageUri = new Uri(instance.menuImg, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);

                Select_Img.Source = imageBitmap;
                Select_Name.Text = instance.menuName;
                Select_Price.Text = instance.menuPrice.ToString()+"원";
                SetSalePercent();
                SetSalePrice();
            }
            else
            {
                return;
            }


        }

        private void SetSalePercent()
        {
            Select_Sale.Text = instance.SalePercent.ToString();
        }

        private void SetSalePrice()
        {
            int Original_Price = instance.menuPrice;
            int Sale_Percent = instance.SalePercent;
            Sale_Price.Text = (Original_Price - ((Original_Price / 100) * Sale_Percent)).ToString();
        }

        private void order_cancle_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            instance.SalePercent += 1;
            SetSalePrice();
            SetSalePercent();
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if(instance.SalePercent == 0)
            {
                return;
            }

            instance.SalePercent -= 1;
            SetSalePrice();
            SetSalePercent();
        }
    }

    class OrderData
    {
        public string menuName { get; set; }
        public String menuImg { get; set; }
        public int menuPrice { get; set; }
        public int SalePercent { get; set; }
        public string Category { get; set; }

        private static OrderData instance = new OrderData();

        public static OrderData GetInstance()
        {

            return instance;
        }
    }
}


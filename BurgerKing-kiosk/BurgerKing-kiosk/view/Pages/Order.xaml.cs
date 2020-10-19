
using BurgerKing_kiosk.model;
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
using static BurgerKing_kiosk.model.FoodModel;

namespace BurgerKing_kiosk
{
    /// <summary>
    /// OrderPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrderPage : Page
    {
        private OrderViewModel viewModel = new OrderViewModel();
        public OrderPage()
        {
            InitializeComponent();

            this.Loaded += OrderPage_Loaded;

            lbFood.ItemsSource = (viewModel.GetFood("kiosk.burger")).Where(x => x.category == Category.burger).ToList();
            lbFood.ItemsSource = (viewModel.GetFood("kiosk.side")).Where(x => x.category == Category.side).ToList();
            lbFood.ItemsSource = (viewModel.GetFood("kiosk.desert")).Where(x => x.category == Category.desert).ToList();

            OrderData.GetInstance().Add(new OrderData() {menuName = "샘플데이터", menuCount = 1, menuPrice = 10000});

            menu_List.ItemsSource = OrderData.GetInstance();
        }

        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCategory.SelectedIndex == -1) return;

            Category category = (Category)lbCategory.SelectedIndex;
            Console.WriteLine("0000000000000000000");
            Console.WriteLine(category.ToString());
            Console.WriteLine("00000000000000000000");
            lbFood.ItemsSource = (viewModel.GetFood(category.ToString())).Where(x => x.category == category).ToList();
            lbFood.Items.Refresh();
        }

        private void OrderPage_Loaded(object sender, RoutedEventArgs e) {
            
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
            if (lbFood.SelectedIndex == -1) 
                return; 

            FoodModel food = (FoodModel)lbFood.SelectedItem;

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

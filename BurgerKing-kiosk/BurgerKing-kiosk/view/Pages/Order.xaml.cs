
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
using static BurgerKing_kiosk.model.FoodModel;

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

            lbFood.ItemsSource = Food.Where(x => x.category == Category.BURGER).ToList();
            lbFood.ItemsSource = Food.Where(x => x.category == Category.SIDE).ToList();
            lbFood.ItemsSource = Food.Where(x => x.category == Category.DESERT).ToList();

            OrderData.GetInstance().Add(new OrderData() {menuName = "샘플데이터", menuCount = 1, menuPrice = 10000});

            menu_List.ItemsSource = OrderData.GetInstance();
        }

        private List<FoodModel> Food = new List<FoodModel>() {

            new FoodModel() { category = Category.BURGER, name = "기네스머쉬룸와퍼", picture = "/view/Images/Burger/기네스머쉬룸와퍼.png" },
            new FoodModel() { category = Category.BURGER, name = "기네스와퍼", picture = "/view/Images/Burger/기네스와퍼.png" },
            new FoodModel() { category = Category.BURGER, name = "콰트로치즈와퍼", picture = "/view/Images/Burger/콰트로치즈와퍼.png" },
            new FoodModel() { category = Category.BURGER, name = "기네스와퍼팩1", picture = "/view/Images/burger.png" }, 
            new FoodModel() { category = Category.BURGER, name = "기네스와퍼팩2", picture = "/view/Images/burger.png" },
            new FoodModel() { category = Category.BURGER, name = "기네스와퍼팩3", picture = "/view/Images/burger.png" }, 
            new FoodModel() { category = Category.BURGER, name = "와퍼", picture = "/view/Images/burger.png" },
            new FoodModel() { category = Category.BURGER, name = "불고기와퍼", picture = "/view/Images/burger.png" },
            new FoodModel() { category = Category.BURGER, name = "치즈와퍼", picture = "/view/Images/burger.png" },
            new FoodModel() { category = Category.BURGER, name = "치즈와퍼2", picture = "/view/Images/burger.png" },
            new FoodModel() { category = Category.BURGER, name = "치즈와퍼3", picture = "/view/Images/burger.png" },

            new FoodModel() { category = Category.SIDE,   name = "치킨", picture="/view/Images/side.png"},


            new FoodModel() { category = Category.DESERT, name = "디저트1", picture="/view/images/desert.png"}
        };

        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCategory.SelectedIndex == -1) return;

            Category category = (Category)lbCategory.SelectedIndex;
            lbFood.ItemsSource = Food.Where(x => x.category == category).ToList();
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


using BurgerKing_kiosk.view.Pages;
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
    /// OrderPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();

            this.Loaded += OrderPage_Loaded;

            List.ItemsSource = Food.Where(x => x.category == Category.BURGER).ToList();
            List.ItemsSource = Food.Where(x => x.category == Category.SIDE).ToList();
        }

        private List<Food> Food = new List<Food>() {
            new Food() { category = Category.BURGER, title = "기네스머쉬룸와퍼", imageData = "/view/Images/burger.png" },
            new Food() { category = Category.BURGER, title = "기네스와퍼", imageData = "/view/Images/burger.png" },
            new Food() { category = Category.BURGER, title = "콰트로치즈와퍼", imageData = "/view/Images/burger.png" },
            new Food() { category = Category.BURGER, title = "기네스와퍼팩1", imageData = "/view/Images/burger.png" }, 
            new Food() { category = Category.BURGER, title = "기네스와퍼팩2", imageData = "/view/Images/burger.png" },
            new Food() { category = Category.BURGER, title = "기네스와퍼팩3", imageData = "/view/Images/burger.png" }, 
            new Food() { category = Category.BURGER, title = "와퍼", imageData = "/view/Images/burger.png" }, 
            new Food() { category = Category.BURGER, title = "불고기와퍼", imageData = "/view/Images/burger.png" },
            new Food() { category = Category.BURGER, title = "치즈와퍼", imageData = "/view/Images/burger.png" },

            new Food() { category = Category.SIDE,   title = "치킨", imageData="/view/Images/side.png"}
        };

        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCategory.SelectedIndex == -1) return;

            Category category = (Category)lbCategory.SelectedIndex;
            List.ItemsSource = Food.Where(x => x.category == category).ToList();
        }

        private void OrderPage_Loaded(object sender, RoutedEventArgs e) {
            
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancleBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}

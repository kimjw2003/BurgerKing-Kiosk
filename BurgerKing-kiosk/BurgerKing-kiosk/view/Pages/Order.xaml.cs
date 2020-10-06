
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

            Loaded += OrderPage_Loaded;
        }

        private void OrderPage_Loaded(object sender, RoutedEventArgs e)
        {
            MyData.GetInstance().Add(new MyData() { dataA = "스트링 1", dataB = 1, dataC = "a" });
        MyData.GetInstance().Add(new MyData() { dataA = "스트링 2", dataB = 2, dataC = "b" });
        MyData.GetInstance().Add(new MyData() { dataA = "스트링 3", dataB = 3, dataC = "c"});
        
        burger_menu1.ItemsSource = MyData.GetInstance();
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Burger_Click(object sender, RoutedEventArgs e)
        {
            Burger.Foreground = new SolidColorBrush(Color.FromRgb(241, 85, 90));
            Side.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Desert.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void Side_Click(object sender, RoutedEventArgs e)
        {
            Burger.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Side.Foreground = new SolidColorBrush(Color.FromRgb(241, 85, 90));
            Desert.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void Desert_Click(object sender, RoutedEventArgs e)
        {
            Burger.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Side.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Desert.Foreground = new SolidColorBrush(Color.FromRgb(241, 85, 90));
        }

        private void CancleBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    class MyData
    {
        public string dataA { get; set; }
        public int dataB { get; set; }
        public string dataC { get; set; }

        private static List<MyData> instance;

        public static List<MyData> GetInstance()
        {
            if (instance == null)
                instance = new List<MyData>();

            return instance;
        }


    }

}

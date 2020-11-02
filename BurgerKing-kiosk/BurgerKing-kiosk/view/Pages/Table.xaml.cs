using BurgerKing_kiosk.model;
using BurgerKing_kiosk.viewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// TablePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TablePage : Page
    {
        OrderViewModel menu = new OrderViewModel();
        public TablePage()
        {
            InitializeComponent();
            this.DataContext = new viewModel.TableViewModel();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<TableModel> tableItems = new List<TableModel>();

            tableItems = App.tableList;

            lvTableList.ItemsSource = tableItems;
        }
        private void lvTableList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTable = (TableModel)lvTableList.SelectedItem;
            if (selectedTable.IsUsed)
            {
                MessageBox.Show("사용중인 테이블 입니다.");
                return;
                //selectedTable.IsUsed = false;
            }
            else
            {
                selectedTable.IsUsed = true;
            }
        }
        private void Click_Seat(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            Debug.WriteLine(btn.Name);
            if (!menu.CheckTable())
            {
                return;
            }
            switch (btn.Name)
            {
                case "one":
                    menu.SetTable(1);
                    break;
                case "two":
                    menu.SetTable(2);
                    break;
                case "three":
                    menu.SetTable(3);
                    break;
                case "four":
                    menu.SetTable(4);
                    break;
                case "five":
                    menu.SetTable(5);
                    break;
                case "six":
                    menu.SetTable(6);
                    break;
                case "seven":
                    menu.SetTable(7);
                    break;
                case "eight":
                    menu.SetTable(8);
                    break;
                case "nine":
                    menu.SetTable(9);
                    break;
            }
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void GoNext(object sender, RoutedEventArgs e)
        {
            if (!menu.CheckTable())
            {
                return;
            }
            NavigationService.Navigate(new Uri("view/Pages/HowPay.xaml", UriKind.Relative));
        }
    }
}

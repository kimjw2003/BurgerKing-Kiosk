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
        public TablePage()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lvTableList.ItemsSource = App.tableList;
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
        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void GoNext(object sender, RoutedEventArgs e)
        {
            if (!App.orderVM.CheckTable())
            {
                return;
            }
            NavigationService.Navigate(new Uri("view/Pages/HowPay.xaml", UriKind.Relative));
        }
    }
}

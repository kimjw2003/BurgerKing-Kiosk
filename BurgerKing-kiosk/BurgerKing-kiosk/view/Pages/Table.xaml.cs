using BurgerKing_kiosk.model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BurgerKing_kiosk
{
    /// <summary>
    /// TablePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TablePage : Page
    {
        int table = 0;
        public TablePage()
        {
            InitializeComponent();
            Loaded += Table_Loaded;
        }
        private void Table_Loaded(object sender, RoutedEventArgs e)
        {
            lvTable.ItemsSource = App.tableList;
        }
        private void lvTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (App.orderVM.GetTable() != 0)
            {
                table = App.orderVM.GetTable();
                App.orderVM.SetTable(0);
                return;
            }
            var selectedTable = (TableModel)lvTable.SelectedItem;
            if (selectedTable.IsUsed)
            {
                MessageBox.Show("사용중인 테이블 입니다.");
                return;
                //selectedTable.IsUsed = false;
            }
            else if (table != 0)
            {
                App.tableList[table - 1].IsUsed = false;
                selectedTable.IsUsed = true;
                table = selectedTable.id;
            }
            else
            {
                selectedTable.IsUsed = true;
                table = selectedTable.id;
            }
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            App.tableList[table - 1].IsUsed = false;
            table = 0;
            NavigationService.GoBack();
        }
        private void GoNext(object sender, RoutedEventArgs e)
        {
            if (table == 0)
            {
                MessageBox.Show("테이블을 선택해주세요.");
                return;
            }
            App.orderVM.SetTable(table);
            NavigationService.Navigate(new Uri("view/Pages/HowPay.xaml", UriKind.Relative));
        }
    }
}

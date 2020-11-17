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
            var selectedTable = (TableModel)lvTable.SelectedItem;
            if (selectedTable.IsUsed)
            {
                MessageBox.Show("사용중인 테이블 입니다.");
                return;
            }
            else if (App.orderVM.GetTable() != 0)
            {
                App.tableList[App.orderVM.GetTable() - 1].IsUsed = false;
                selectedTable.IsUsed = true;
                App.orderVM.SetTable(selectedTable.id);
            }
            else
            {
                selectedTable.IsUsed = true;
                App.orderVM.SetTable(selectedTable.id);
            }
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            App.tableList[App.orderVM.GetTable() - 1].IsUsed = false;
            NavigationService.GoBack();
        }
        private void GoNext(object sender, RoutedEventArgs e)
        {
            if (App.orderVM.GetTable() == 0)
            {
                MessageBox.Show("테이블을 선택해주세요.");
                return;
            }
            NavigationService.Navigate(new Uri("view/Pages/HowPay.xaml", UriKind.Relative));
        }
    }
}

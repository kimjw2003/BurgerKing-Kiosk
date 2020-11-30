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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BurgerKing_kiosk.view.Pages.Statistics
{
    /// <summary>
    /// Member_List.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Member_List : Page
    {
        StatisticsViewModel statisticsVM = new StatisticsViewModel();

        UserModel user;
        List<SaleModel> items;
        List<SaleModel> SortedList;

        public Member_List()
        {
            InitializeComponent();

            this.Loaded += MemberPage_Loaded;
            UserOrder.AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(myListView_OnColumnClick));
        }

        private void myListView_OnColumnClick(object sender, RoutedEventArgs e)
        {
            string column = ((GridViewColumnHeader)e.OriginalSource).Column.Header.ToString();

            if (MemberName != null)
            {
                if (column == "Count ▼")
                {
                    count.Header = "Count ▲";
                    SortedList = items.OrderByDescending(o => o.count).ToList();
                    UserOrder.ItemsSource = SortedList;
                }
                else if (column == "Count ▲")
                {
                    count.Header = "Count ▼";
                    SortedList = items.OrderBy(o => o.count).ToList();
                    UserOrder.ItemsSource = SortedList;
                }
            }
        }

        private void MemberPage_Loaded(object sender, RoutedEventArgs e)
        {
            UserListViewModel userVM = new UserListViewModel();
            UserList = userVM.GetUser();
            Users.DataContext = this;
        }

        private void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            user = (UserModel)Users.SelectedItem;
            MemberName = user.name;
            items = statisticsVM.GetUserStatistics(user.barcode);

            int price = 0;

            foreach(SaleModel item in items)
            {
                price += item.price;
            }

            TotalPrice = price.ToString() + "원";

            count.Header = "Count ▼";
            SortedList = items.OrderBy(o => o.count).ToList();
            UserOrder.ItemsSource = SortedList;

            DataContext = null;
            DataContext = this;
        }

        public List<UserModel> UserList {get; set;}
        public String MemberName { get; set; }
        public String TotalPrice { get; set; }
    }
}

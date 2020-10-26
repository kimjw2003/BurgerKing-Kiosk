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

namespace BurgerKing_kiosk.view.Pages.Statistics
{
    /// <summary>
    /// Member_List.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Member_List : Page
    {
        public Member_List()
        {
            InitializeComponent();

            this.Loaded += MemberPage_Loaded;
        }

        private void MemberPage_Loaded(object sender, RoutedEventArgs e)
        {
            UserListViewModel userVM = new UserListViewModel();
            List<UserListModel> items = userVM.GetUser();
       
            Users.ItemsSource = items;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

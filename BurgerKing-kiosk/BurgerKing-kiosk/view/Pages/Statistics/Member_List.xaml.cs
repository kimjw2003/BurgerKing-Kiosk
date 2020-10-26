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
            List<UserListModel> items = new List<UserListModel>();

            for(int i = 0; i<100; i++)
            {
                items.Add(new UserListModel() { name = "name" + i, barcode = i });
            }

            Members.ItemsSource = items;
        }
    }
}

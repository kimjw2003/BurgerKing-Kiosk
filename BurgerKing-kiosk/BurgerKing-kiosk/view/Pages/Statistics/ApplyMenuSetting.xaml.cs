using BurgerKing_kiosk.model;
using BurgerKing_kiosk.model.DB;
using BurgerKing_kiosk.viewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using static BurgerKing_kiosk.model.MenuModel;

namespace BurgerKing_kiosk.view.Pages.Statistics
{
    /// <summary>
    /// Apply_Discount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Apply_Discount : Page
    {
        int pageCount = 0;
        List<MenuModel> allMenuList = new List<MenuModel>();
        ApplyMenuSettingViewModel ApplyMenuSettingVM = new ApplyMenuSettingViewModel();

        public Apply_Discount()
        {
            InitializeComponent();

            this.Loaded += OrderPage_Loaded;

        }
        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e) //카테고리 선택
        {

            if (lbCategory.SelectedIndex == -1) return;

            pageCount = 0;

            Category category = (Category)lbCategory.SelectedIndex;
            //lbFood.ItemsSource = App.menuVM.GetMenus(category.ToString());
            if (lbCategory.SelectedIndex == 0)
            {
                lbFood.ItemsSource = App.burgerList.ToList();
            }
            else if (lbCategory.SelectedIndex == 1)
            {
                lbFood.ItemsSource = App.sideList.ToList();
            }
            else
            {
                lbFood.ItemsSource = App.desertList.ToList();
            }

            lbFood.Items.Refresh();

        }
        private void OrderPage_Loaded(object sender, RoutedEventArgs e)
        { //주문페이지가 시작되면 실행되는 함수

            //ordered_Menu_List.Items.Refresh();

            lbCategory.SelectedIndex = 0; //처음 실행 시 첫번째 카테고리가 선택되도록

            for (int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
            {
                allMenuList.Add(App.burgerList[i]);
            }
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e) //다음메뉴 버튼이 눌러지면 실행
        {
            if (lbCategory.SelectedIndex == 0 && (pageCount + 1) * 9 <= App.burgerList.Count)
            {
                allMenuList.Clear();
                pageCount += 1;
                for (int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
                {
                    if (i >= App.burgerList.Count) break;
                    allMenuList.Add(App.burgerList[i]);
                }
                lbFood.ItemsSource = allMenuList;
                lbFood.Items.Refresh();
            }


            else if (lbCategory.SelectedIndex == 1 && (pageCount + 1) * 9 <= App.sideList.Count)
            {
                allMenuList.Clear();
                pageCount += 1;
                for (int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
                {
                    if (i >= App.sideList.Count) break;
                    allMenuList.Add(App.sideList[i]);
                }
                lbFood.ItemsSource = allMenuList;
                lbFood.Items.Refresh();
            }


            else if (lbCategory.SelectedIndex == 2 && (pageCount + 1) * 9 <= App.desertList.Count)
            {
                allMenuList.Clear();
                pageCount += 1;
                for (int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
                {
                    if (i >= App.desertList.Count) break;
                    allMenuList.Add(App.desertList[i]);

                }
                lbFood.ItemsSource = allMenuList;
                lbFood.Items.Refresh();
            }

        }

        private void beforeBtn_Click(object sender, RoutedEventArgs e) //이전메뉴 버튼이 눌러지면 실행
        {

            if (lbCategory.SelectedIndex == 0 && pageCount > 0)
            {
                allMenuList.Clear();
                pageCount -= 1;
                for (int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
                {
                    if (i >= App.burgerList.Count) break;
                    allMenuList.Add(App.burgerList[i]);
                }
                lbFood.ItemsSource = allMenuList;
                lbFood.Items.Refresh();
            }

            else if (lbCategory.SelectedIndex == 1 && pageCount > 0)
            {
                allMenuList.Clear();
                pageCount -= 1;
                for (int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
                {
                    if (i >= App.sideList.Count) break;
                    allMenuList.Add(App.sideList[i]);
                }
                lbFood.ItemsSource = allMenuList;
                lbFood.Items.Refresh();
            }


            else if (lbCategory.SelectedIndex == 2 && pageCount > 0)
            {
                allMenuList.Clear();
                pageCount -= 1;
                for (int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
                {
                    if (i >= App.desertList.Count) break;
                    allMenuList.Add(App.desertList[i]);

                }
                lbFood.ItemsSource = allMenuList;
                lbFood.Items.Refresh();
            }
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e) // 메뉴 리스트가 눌러지면 실행
        {
          
            Selected_Menu = (MenuModel)lbFood.SelectedItem;

            if(Selected_Menu != null)
            {
                SelectMenuGrid.Visibility = Visibility;
                PreSoldOut = Selected_Menu.soldOut;
                PrePrice = Selected_Menu.price;
                PreSale = Selected_Menu.sale;
                PreSalePrice = Selected_Menu.salePrice;


                DataContext = null;
                DataContext = this;
            }
        }

        private void Apply_Btn_Click(object sender, RoutedEventArgs e)
        {
            Selected_Menu.salePrice = (int)PreSalePrice;
            Selected_Menu.sale = (int)PreSale;
            Selected_Menu.soldOut = PreSoldOut;

            ApplyMenuSettingVM.SetMenuSetting(Selected_Menu);
            lbFood.Items.Refresh();

            DataContext = null;
            DataContext = this;

            MessageBox.Show("적용되었습니다");
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            PreSale++;
            PreSalePrice = PrePrice * (1 - (PreSale/100));

            DataContext = null;
            DataContext = this;
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            PreSale--;
            PreSalePrice = PrePrice * (1 - (PreSale / 100));

            DataContext = null;
            DataContext = this;
        }

       
           
            public MenuModel Selected_Menu { get; set; }

            public bool PreSoldOut { get; set; }
            public float PrePrice { get; set; }

            public float PreSale { get; set; }

            public float PreSalePrice { get; set; }
       
    }
}
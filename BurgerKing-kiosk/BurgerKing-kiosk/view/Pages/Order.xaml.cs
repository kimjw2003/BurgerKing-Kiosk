
using BurgerKing_kiosk.model;
using BurgerKing_kiosk.viewModel;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
using System.Windows.Threading;
using static BurgerKing_kiosk.model.MenuModel;
using static BurgerKing_kiosk.model.OrderModel;

namespace BurgerKing_kiosk
{
    /// <summary>
    /// OrderPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrderPage : Page
    {
        int pageCount = 0;
        int totalPrice = 0;
        List<MenuModel> allMenuList = new List<MenuModel>();

        public OrderPage()
        {
            InitializeComponent();

            this.Loaded += OrderPage_Loaded;

            allPrice.Text = totalPrice + "";

            ordered_Menu_List.ItemsSource = OrderModel.GetInstance();
            

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

            ordered_Menu_List.Items.Refresh();
            
            lbCategory.SelectedIndex = 0; //처음 실행 시 첫번째 카테고리가 선택되도록

            for(int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
            {
                allMenuList.Add(App.burgerList[i]);
            }
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e) //다음메뉴 버튼이 눌러지면 실행
        {
            if (lbCategory.SelectedIndex == 0 && pageCount * 9 <= App.burgerList.Count)
            {
                allMenuList.Clear();
                for (int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
                {
                    if (i >= App.burgerList.Count) break;
                    allMenuList.Add(App.burgerList[i]);
                }
                pageCount += 1;
                lbFood.ItemsSource = allMenuList;
                lbFood.Items.Refresh();
            } 


            else if(lbCategory.SelectedIndex == 1 && pageCount * 9 <= App.sideList.Count)
            {
                allMenuList.Clear();
                for (int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
                {
                    if (i >= App.sideList.Count) break;
                    allMenuList.Add(App.sideList[i]);
                }
                pageCount += 1;
                lbFood.ItemsSource = allMenuList;
                lbFood.Items.Refresh();
            }


            else if (lbCategory.SelectedIndex == 2 && pageCount * 9 <= App.desertList.Count)
            {
                allMenuList.Clear();
                for (int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
                {
                    if (i >= App.desertList.Count) break;
                    allMenuList.Add(App.desertList[i]);

                }
                pageCount += 1;
                lbFood.ItemsSource = allMenuList;
                lbFood.Items.Refresh();
            }
            
        }

        private void beforeBtn_Click(object sender, RoutedEventArgs e) //이전메뉴 버튼이 눌러지면 실행
        {

            if (lbCategory.SelectedIndex == 0 && pageCount * 9 <= App.burgerList.Count)
            {
                allMenuList.Clear();
                for (int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
                {
                    if (i >= App.burgerList.Count) break;
                    allMenuList.Add(App.burgerList[i]);
                }
                pageCount += 1;
                lbFood.ItemsSource = allMenuList;
                lbFood.Items.Refresh();
            }


            else if (lbCategory.SelectedIndex == 1 && pageCount * 9 <= App.sideList.Count)
            {
                allMenuList.Clear();
                for (int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
                {
                    if (i >= App.sideList.Count) break;
                    allMenuList.Add(App.sideList[i]);
                }
                pageCount -= 1;
                lbFood.ItemsSource = allMenuList;
                lbFood.Items.Refresh();
            }


            else if (lbCategory.SelectedIndex == 2 && pageCount * 9 <= App.desertList.Count)
            {
                allMenuList.Clear();
                for (int i = pageCount * 9; i <= pageCount * 9 + 8; i++)
                {
                    if (i >= App.desertList.Count) break;
                    allMenuList.Add(App.desertList[i]);

                }
                pageCount -= 1;
                lbFood.ItemsSource = allMenuList;
                lbFood.Items.Refresh();
            }
        }
        private void order_order_Btn_Click(object sender, RoutedEventArgs e) //주문버튼이 눌러지면 실행
        {

            if (ordered_Menu_List.Items.Count == 0)
            {
                MessageBox.Show("메뉴가 선택되지 않았습니다.");
                return;
            }

            App.orderVM.AddOrder(OrderModel.GetInstance());
            App.totalPrice = Int32.Parse(allPrice.Text);
            NavigationService.Navigate(new Uri("/view/Pages/Place.xaml", UriKind.Relative));

            
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e) // 메뉴 리스트가 눌러지면 실행
        {

            MenuModel orderList = (MenuModel)lbFood.SelectedItem;

            
            if (orderList != null)
            {
   
                if (OrderModel.GetInstance().Exists(x => x.Name == orderList.name))
                {
                    var item = OrderModel.GetInstance().Find(x => x.Name == orderList.name);
                    item.salePrice += (item.salePrice / item.Count);
                    item.Count++;
                    
                }
                else {
                    OrderModel.GetInstance().Add(new OrderModel() { Name = orderList.name, Count = 1, Price = orderList.price, salePrice = orderList.salePrice, category = orderList.category, sale = orderList.sale });

                    lbFood.SelectedItem = null;

                    int selectedPrice = 0;
                    for (int i = 0; i < OrderModel.GetInstance().Count; i++)
                    {
                        selectedPrice = OrderModel.GetInstance()[i].salePrice;
                    }
                    int beforeTotalPrice = int.Parse(allPrice.Text);
                    allPrice.Text = beforeTotalPrice + selectedPrice + ""; //전체가격 작성

                    
                }

                ordered_Menu_List.Items.Refresh();
            }else {
                return;
            }

            var item2 = OrderModel.GetInstance().Find(x => x.Name == orderList.name);
            var allPrice_Int = int.Parse(allPrice.Text);

            if (item2.Count > 1)
            {
                allPrice_Int += (item2.salePrice / item2.Count);
                allPrice.Text = allPrice_Int.ToString();
            }
            lbFood.SelectedItem = null;
        }

        private void order_cancle_Btn_Click(object sender, RoutedEventArgs e) //주문취소를 누르면 실행
        {

            MessageBoxResult result = MessageBox.Show("주문을 취소하시겠습니까?","취소", MessageBoxButton.OKCancel);
            if(result == MessageBoxResult.OK) {
                OrderModel.GetInstance().Clear();
                ordered_Menu_List.Items.Refresh();
            } else {
                return;
            }

            NavigationService.GoBack();
        }

        private void allDel_Btn_Click(object sender, RoutedEventArgs e) //모두삭제 버튼
        {

            MessageBoxResult result = MessageBox.Show("주문목록을 삭제하시겠습니까?", "삭제", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                OrderModel.GetInstance().Clear();
                ordered_Menu_List.Items.Refresh();

                totalPrice = 0;
                allPrice.Text = totalPrice.ToString();
            }
            else
            {
                return;
            }

        }

        private void ordered_Menu_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void upBtn_Click(object sender, RoutedEventArgs e) // +버튼 누르면 실행
        {
            OrderModel data = (sender as Button).DataContext as OrderModel;
            

            if (OrderModel.GetInstance().Exists(x => x.Name == data.Name))
            {
                var allPrice_Int = int.Parse(allPrice.Text);
                allPrice_Int += (data.salePrice / data.Count);
                allPrice.Text = allPrice_Int.ToString();

                data.salePrice += (data.salePrice / data.Count);
            }
            data.Count += 1;
            
            ordered_Menu_List.Items.Refresh();
        }
        private void downBtn_Click(object sender, RoutedEventArgs e) // -버튼누르면 실행
        {
            OrderModel data = (sender as Button).DataContext as OrderModel;

            if (OrderModel.GetInstance().Exists(x => x.Name == data.Name))
            {


                var allPrice_Int = int.Parse(allPrice.Text);
                allPrice_Int -= (data.salePrice / data.Count);
                allPrice.Text = allPrice_Int.ToString();

                data.salePrice -= (data.salePrice / data.Count);
            }

            data.Count -= 1;

            if (data.Count < 1)
            {
                if (OrderModel.GetInstance().Exists(x => x.Name == data.Name))
                {
                    var allPrice_Int = int.Parse(allPrice.Text);
                    allPrice_Int -= data.Count;
                    allPrice.Text = allPrice_Int.ToString();

                    OrderModel.GetInstance().Remove(data);
                }
            }

            

            ordered_Menu_List.Items.Refresh();
        }

        private void delete_Btn_Click(object sender, RoutedEventArgs e) //개별삭제 버튼 누를시 실행
        {
            OrderModel data = (sender as Button).DataContext as OrderModel;

            if(OrderModel.GetInstance().Exists(x => x.Name == data.Name))
            {
                OrderModel.GetInstance().Remove(data);

                var allPrice_Int = int.Parse(allPrice.Text);
                allPrice_Int -= data.salePrice;
                allPrice.Text = allPrice_Int.ToString();

            }

            ordered_Menu_List.Items.Refresh();
        }
    }
}

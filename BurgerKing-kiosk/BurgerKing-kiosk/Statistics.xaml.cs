﻿using System;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;
using BurgerKing_kiosk.viewModel;

namespace BurgerKing_kiosk
{
    /// <summary>
    /// Statistics.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Statistics : Window
    {

        private SaleViewModel viewModel = new SaleViewModel();
        private String payment_method = null;

        public Statistics()
        {
            InitializeComponent();
            
        }

        private void SetSaleText() //db에서 할인율 불러와서 계산해야함
        {
            Console.WriteLine(payment_method);
            List<String> result = (viewModel.GetSale(payment_method));

            WholeSaleText.Text = result.ElementAt(0) + "원";
            PureSaleText.Text = result.ElementAt(1) + "원";
            DiscountText.Text = result.ElementAt(2) + "원";
        }

        private void All_Btn_Click(object sender, RoutedEventArgs e)
        {
            payment_method = null;
            SetSaleText();
        }

        private void Card_Btn_Click(object sender, RoutedEventArgs e)
        {
            payment_method = "where payment_method = \"credit\"";
            SetSaleText();
        }

        private void Cash_Btn_Click(object sender, RoutedEventArgs e)
        {
            payment_method = "where payment_method = \"cash\"";
            SetSaleText();
        }

        private void Discount_Apply_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        /* private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCategory.SelectedIndex == -1) return;

            Category category = (Category)lbCategory.SelectedIndex;
            List.ItemsSource = Food.Where(x => x.category == category).ToList();
            List.Items.Refresh();
        }*/
    }
}

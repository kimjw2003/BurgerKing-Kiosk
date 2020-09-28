﻿
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

namespace BurgerKing_kiosk
{
    /// <summary>
    /// OrderPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Burger_Click(object sender, RoutedEventArgs e)
        {
            Burger.Foreground = new SolidColorBrush(Color.FromRgb(241, 85, 90));
            Side.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Desert.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void Side_Click(object sender, RoutedEventArgs e)
        {
            Burger.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Side.Foreground = new SolidColorBrush(Color.FromRgb(241, 85, 90));
            Desert.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void Desert_Click(object sender, RoutedEventArgs e)
        {
            Burger.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Side.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Desert.Foreground = new SolidColorBrush(Color.FromRgb(241, 85, 90));
        }

        private void CancleBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

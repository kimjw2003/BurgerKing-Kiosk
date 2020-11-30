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

        public Statistics()
        {
            InitializeComponent();
            frame_content.Navigate(new Uri("view/Pages/Statistics/test.xaml", UriKind.Relative));
        }

    }

}
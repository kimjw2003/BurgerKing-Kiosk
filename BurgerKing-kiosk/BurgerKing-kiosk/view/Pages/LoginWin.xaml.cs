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

namespace BurgerKing_kiosk.view.Pages
{
    /// <summary>
    /// LoginWin.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWin : Window
    {
        public LoginWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //chris: 사용자 아이디와 패스워드가 틀린 경우, 아래 코드를 실행시키면 안됨
            this.DialogResult = true;
            this.Close();
        }
    }
}

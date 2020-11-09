using System.Threading;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace BurgerKing_kiosk
{
    /// <summary>
    /// FinishPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FinishPage : Page
    {
        public FinishPage()
        {
            InitializeComponent();
            Name.Text = App.userData.name;
            CardNum.Text = App.userData.barcode;
            OrderNum.Text = App.OrderNumber.ToString();
            totalPrice.Text = App.totalPrice.ToString();

        }
    }
}

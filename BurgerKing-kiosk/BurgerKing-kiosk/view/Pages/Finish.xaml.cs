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

            this.Dispatcher.Invoke((ThreadStart)(() => { }), DispatcherPriority.ApplicationIdle);
            Thread.Sleep(1000);
            while (NavigationService?.CanGoBack == true) { NavigationService?.RemoveBackEntry(); }
            NavigationService.Navigate(new HomePage());
        }
    }
}

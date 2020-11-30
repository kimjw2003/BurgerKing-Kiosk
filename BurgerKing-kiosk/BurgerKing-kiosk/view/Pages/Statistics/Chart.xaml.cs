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
using BurgerKing_kiosk.model;
using BurgerKing_kiosk.model.DB;
using BurgerKing_kiosk.viewModel;
using LiveCharts;
using LiveCharts.Wpf;

namespace BurgerKing_kiosk.view.Pages.Statistics
{
    /// <summary>
    /// Chart.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Chart : Page
    {

        StatisticsViewModel StatisticsVM = new StatisticsViewModel();
        public Chart()
        {
            InitializeComponent();

            //Func<ChartPoint, string> labelPoint = chartPoint =>
            // string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            List<String> Menus = new List<string>();
            ChartValues<double> MenuCount = new ChartValues<double>();
            ChartValues<double> MenuPrice = new ChartValues<double>();

            List<SaleModel> Orders = StatisticsVM.GetMenuSalePrice("0");

            foreach (SaleModel Order in Orders)
            {
                Menus.Add(Order.menu);
                MenuCount.Add(Order.count);
                MenuPrice.Add(Order.price);
            }


            CountSeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "판매수",
                    DataLabels = true,
                    Values = MenuCount,
                    LabelPoint = point => point.Y + "개"
                },
            };

            PriceSeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "판매 가격",
                    DataLabels = true,
                    Values = MenuPrice,
                    LabelPoint = point => point.Y + "원",                    
                },
            };

            Labels = Menus.ToArray();
            CountFormatter = value => value + "개";
            PriceFormatter = value => value.ToString("C");

            DataContext = this;
        }

        public string[] Labels { get; set; }
        public SeriesCollection CountSeriesCollection { get; set; }
        public SeriesCollection PriceSeriesCollection { get; set; }
        public Func<double, string> CountFormatter { get; set; }
        public Func<double, string> PriceFormatter { get; set; }

    }
}

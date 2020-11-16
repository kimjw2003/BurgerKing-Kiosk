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

            Func<ChartPoint, string> labelPoint = chartPoint =>
             string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            Console.WriteLine(StatisticsVM.GetWholeSaleAmount("2020-11-11"));

           /* for(int i = 1; i<= 9; i++)
            {
                Console.WriteLine("좌석번호: "+i+"카테고리: burger"+StatisticsVM.GetSeatCategorySaleCount("burger", i));
                Console.WriteLine("좌석번호: " + i + "카테고리: side" + StatisticsVM.GetSeatCategorySaleCount("side", i));
                Console.WriteLine("좌석번호: " + i + "카테고리: desert" + StatisticsVM.GetSeatCategorySaleCount("desert", i));
            }*/
            

            PieChart1.Series = new SeriesCollection
        {
            new PieSeries
            {
                Title = "Burger",
                Values = new ChartValues<double> {StatisticsVM.GetCategorySaleCount("burger")},
                PushOut = 15,
                DataLabels = true,
                LabelPoint = labelPoint
            },
            new PieSeries
            {
                Title = "Desert",
                Values = new ChartValues<double> {StatisticsVM.GetCategorySaleCount("desert")},
                DataLabels = true,
                LabelPoint = labelPoint
            },
            new PieSeries
            {
                Title = "Side",
                Values = new ChartValues<double> {StatisticsVM.GetCategorySaleCount("side")},
                DataLabels = true,
                LabelPoint = labelPoint
            }
        };

            PieChart2.Series = new SeriesCollection
        {
            new PieSeries
            {
                Title = "Burger",
                Values = new ChartValues<double> {StatisticsVM.GetCategorySalePrice("burger")},
                PushOut = 15,
                DataLabels = true,
                LabelPoint = labelPoint
            },
            new PieSeries
            {
                Title = "Desert",
                Values = new ChartValues<double> {StatisticsVM.GetCategorySalePrice("desert")},
                DataLabels = true,
                LabelPoint = labelPoint
            },
            new PieSeries
            {
                Title = "Side",
                Values = new ChartValues<double> {StatisticsVM.GetCategorySalePrice("side")},
                DataLabels = true,
                LabelPoint = labelPoint
            }
        };



        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

    }
}

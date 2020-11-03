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
using LiveCharts;
using LiveCharts.Wpf;

namespace BurgerKing_kiosk.view.Pages.Statistics
{
    /// <summary>
    /// Chart.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Chart : Page
    {
        public Chart()
        {
            InitializeComponent();

            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "판매 수",
                    Values = new ChartValues<int> { 10, 50, 39 }
                }
            };

            //adding series will update and animate the chart automatically
            /*SeriesCollection.Add(new ColumnSeries
            {
                Title = "총액",
                Values = new ChartValues<int> { 11000, 50006, 42000 }
            });

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "버거",
                Values = new ChartValues<int> { 11000, 50006, 42000 }
            }); */

            //also adding values updates and animates the chart automatically
            //SeriesCollection[1].Values.Add(48d);

            Labels = new[] { "Burger", "Side", "Desert" };
            Formatter = value => value.ToString("N");

            DataContext = this;


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

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<int, string> Formatter { get; set; }

    }
}

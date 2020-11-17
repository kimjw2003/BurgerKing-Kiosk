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
using BurgerKing_kiosk.viewModel;
using LiveCharts;
using LiveCharts.Wpf;

namespace BurgerKing_kiosk.view.Pages.Statistics
{
    /// <summary>
    /// Daily_Chart.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Daily_Chart : Page
    {

        StatisticsViewModel StatisticsVM = new StatisticsViewModel();

        List<String> timeLabel = new List<string>();
        ChartValues<double> Getvalues;

        public Daily_Chart()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "시간 별 매출액",
                    //Values = Getvalues,
                    //Values = new ChartValues<double> { 4, 6, 5, 2 ,4 },
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10
                },
            };

            SetLabelTime();
            Labels = timeLabel.ToArray();

            YFormatter = value => value.ToString("C");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private void Calendar_SelectedDatesChanged(object sender,
        SelectionChangedEventArgs e)
        {
            // ... Get reference.
            var calendar = sender as Calendar;

            // ... See if a date is selected.
            if (calendar.SelectedDate.HasValue)
            {
                // ... Display SelectedDate in Title.
                DateTime date = calendar.SelectedDate.Value;
                Console.WriteLine(date.ToShortDateString());

                GetPrice(date.ToShortDateString());
                ShowChart();
            }
        }

        private void ShowChart()
        {
            SeriesCollection[0].Values = Getvalues;
        }

        private void SetLabelTime()
        {
            for (int i = 0; i<= 24; i++)
            {
                timeLabel.Add( i<10 ? "0"+i : i.ToString());
            }
        }

        private void GetPrice(string date)
        {
            Getvalues = new ChartValues<double>();
            foreach (String time in timeLabel)
            {
                Getvalues.Add( StatisticsVM.GetWholeSaleAmount(date,time));
                Console.WriteLine(StatisticsVM.GetWholeSaleAmount(date, time));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
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
using BurgerKing_kiosk.viewModel;
using LiveCharts;
using LiveCharts.Wpf;

namespace BurgerKing_kiosk.view.Pages.Statistics
{
    /// <summary>
    /// Seat_Chart.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Seat_Chart : Page
    {
        StatisticsViewModel StatisticsVM = new StatisticsViewModel();
        public Seat_Chart()
        {
            InitializeComponent();

            this.Loaded += Seat_Chart_Loaded;
        }

        private void Seat_Chart_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox.SelectedIndex = 0;
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            // DataTable에 Column 추가
            
            dataTable.Columns.Add("NAME", typeof(string));
            dataTable.Columns.Add("VALUE", typeof(string));

            // DataTable에 데이터 추가
            for(int i = 1; i<= 9; i++)
            {
                dataTable.Rows.Add(new string[] { "Seat No."+i, i.ToString()});
            }

            comboBox.ItemsSource = dataTable.DefaultView;
            comboBox.DisplayMemberPath = "NAME";
            comboBox.SelectedValuePath = "VALUE";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in e.AddedItems)
            {
                string seat = row["VALUE"].ToString();
                AddSeatMenuChart(seat);
                CategoryCountDoughnutChart(seat);
              

                DataContext = null;
                DataContext = this;
            }
        }

        private void AddSeatMenuChart(string seat)
        {
            List<String> Menus = new List<string>();
            ChartValues<double> MenuCount = new ChartValues<double>();
            ChartValues<double> MenuPrice = new ChartValues<double>();

            List<SaleModel> Orders = StatisticsVM.GetMenuStatistics(seat);

            foreach (SaleModel Order in Orders)
            {
                Menus.Add(Order.menu);
                MenuCount.Add(Order.count);
                MenuPrice.Add(Order.price);
            }

            LineCategoryCountSeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "판매수",
                    DataLabels = true,
                    Values = MenuCount,
                },
            };

            LineCategoryPriceSeriesCollection = new SeriesCollection
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

        }

        private void CategoryCountDoughnutChart(string seat)
        {
            SaleModel BurgerSale = StatisticsVM.GetCategoryStatistics("burger", seat);
            SaleModel DesertSale = StatisticsVM.GetCategoryStatistics("desert", seat);
            SaleModel SideSale = StatisticsVM.GetCategoryStatistics("side", seat);

            BurgerCount = BurgerSale.count;
            BurgerPrice = BurgerSale.price;
            DesertCount = DesertSale.count;
            DesertPrice = DesertSale.price;
            SideCount = SideSale.count;
            SidePrice = SideSale.price;

            CategoryCountSeriesCollection = new SeriesCollection();

            if (BurgerCount != 0)
            {
                CategoryCountSeriesCollection.Add(new PieSeries
                {
                    Title = "Burger",
                    Values = new ChartValues<double> { BurgerCount },
                    DataLabels = true,
                    LabelPoint = point => point.Y + "개",
                    Fill = Brushes.MediumPurple
                });
            }

            if (DesertCount != 0)
            {
                CategoryCountSeriesCollection.Add(new PieSeries
                {
                    Title = "Desert",
                    Values = new ChartValues<double> { DesertCount },
                    DataLabels = true,
                    LabelPoint = point => point.Y + "개",
                    Fill = Brushes.IndianRed
                });
            }

            if (SideCount != 0)
            {
                CategoryCountSeriesCollection.Add(new PieSeries
                {
                    Title = "Side",
                    Values = new ChartValues<double> { SideCount },
                    DataLabels = true,
                    LabelPoint = point => point.Y + "개",
                    Fill = Brushes.RoyalBlue
                });
            }

            CategoryPriceSeriesCollection = new SeriesCollection();

            if (BurgerPrice != 0)
            {
                CategoryPriceSeriesCollection.Add(new PieSeries
                {
                    Title = "Burger",
                    Values = new ChartValues<double> { BurgerPrice },
                    DataLabels = true,
                    LabelPoint = point => point.Y + "원",
                    Fill = Brushes.MediumPurple
                });
            }

            if (DesertPrice != 0)
            {
                CategoryPriceSeriesCollection.Add(new PieSeries
                {
                    Title = "Price",
                    Values = new ChartValues<double> { DesertPrice },
                    DataLabels = true,
                    LabelPoint = point => point.Y + "원",
                    Fill = Brushes.IndianRed
                });
            }

            if (SidePrice != 0)
            {
                CategoryPriceSeriesCollection.Add(new PieSeries
                {
                    Title = "Side",
                    Values = new ChartValues<double> { SidePrice },
                    DataLabels = true,
                    LabelPoint = point => point.Y + "원",
                    Fill = Brushes.RoyalBlue
                });
            }

        }

        public SeriesCollection CategoryCountSeriesCollection { get; set; }
        public SeriesCollection CategoryPriceSeriesCollection { get; set; }
        public SeriesCollection LineCategoryCountSeriesCollection { get; set; }
        public SeriesCollection LineCategoryPriceSeriesCollection { get; set; }

        public int BurgerCount { get; set; }
        public int DesertCount { get; set; }
        public int SideCount { get; set; }
        public int BurgerPrice { get; set; }
        public int DesertPrice { get; set; }
        public int SidePrice { get; set; }

        public string[] Labels { get; set; }
        public Func<double, string> CountFormatter { get; set; }
        public Func<double, string> PriceFormatter { get; set; }
    }
}

using BurgerKing_kiosk.model;
using BurgerKing_kiosk.viewModel;
using LiveCharts;
using LiveCharts.Wpf;
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

namespace BurgerKing_kiosk.view.Pages.Statistics
{
    /// <summary>
    /// Category_Chart.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Category_Chart : Page
    {

        StatisticsViewModel StatisticsVM = new StatisticsViewModel();
        public Category_Chart()
        {
            InitializeComponent();

            SaleModel BurgerSale = StatisticsVM.GetCategoryStatistics("burger", "0");
            SaleModel DesertSale = StatisticsVM.GetCategoryStatistics("desert", "0");
            SaleModel SideSale = StatisticsVM.GetCategoryStatistics("side", "0");

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

            DataContext = this;
        }

        public SeriesCollection CategoryCountSeriesCollection { get; set; }
        public SeriesCollection CategoryPriceSeriesCollection { get; set; }

        public int BurgerCount { get; set; }
        public int DesertCount { get; set; }
        public int SideCount { get; set; }
        public int BurgerPrice { get; set; }
        public int DesertPrice { get; set; }
        public int SidePrice { get; set; }
    }
}

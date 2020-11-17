using BurgerKing_kiosk.viewModel;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BurgerKing_kiosk.view.Pages.Converter
{
    public class VisibleConverter : IValueConverter
    {
        TableViewModel viewModel = new TableViewModel();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime time = (DateTime)value;
            if (time.ToString() != default(DateTime).ToString())
            {
                return Visibility.Visible;
            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

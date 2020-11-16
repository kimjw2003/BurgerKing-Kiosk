using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BurgerKing_kiosk.view.Pages.Converter
{
    public class VisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime time = (DateTime)value;
            if (time.ToString() != "0001-01-01 오전 12:00:00")
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

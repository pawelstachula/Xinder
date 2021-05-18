using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xinder.Converters
{
    public class BoolToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return 0.001;
            else
                return 1;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return 0.001;
            else
                return 1;
        }
    }
}

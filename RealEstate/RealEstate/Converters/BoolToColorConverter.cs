using System;
using System.Globalization;
using Xamarin.Forms;

namespace RealEstate.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public BoolToColorConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Color.Green;
            return Color.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

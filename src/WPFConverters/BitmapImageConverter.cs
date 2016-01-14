using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WPFConverters
{
    public class BitmapImageConverter : BaseConverter
    {
        protected override object OnConvert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
                return new BitmapImage(new Uri((string)value, UriKind.RelativeOrAbsolute));

            if (value is Uri)
                return new BitmapImage((Uri)value);

            return DependencyProperty.UnsetValue;
        }
    }
}
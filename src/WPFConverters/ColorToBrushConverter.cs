using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace WPFConverters
{
    public class ColorToBrushConverter : BaseConverter
    {
        protected override object OnConvert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color)
                return new SolidColorBrush((Color)value);

            return DependencyProperty.UnsetValue;
        }
    }
}
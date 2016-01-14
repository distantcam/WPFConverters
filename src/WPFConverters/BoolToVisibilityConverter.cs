using System;
using System.Globalization;
using System.Windows;

namespace WPFConverters
{
    public class BoolToVisibilityConverter : BaseConverter
    {
        public bool Invert { get; set; }

        public bool IsHidden { get; set; }

        protected override object OnConvert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = false;
            if (value is bool)
            {
                flag = (bool)value;
            }
            return (flag ^ Invert) ? Visibility.Visible : (IsHidden ? Visibility.Hidden : Visibility.Collapsed);
        }

        protected override object OnConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = false;

            if (value is Visibility)
            {
                result = (Visibility)value == Visibility.Visible;
            }

            return result ^ Invert;
        }
    }
}
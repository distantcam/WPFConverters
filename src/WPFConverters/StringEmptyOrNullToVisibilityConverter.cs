using System;
using System.Globalization;
using System.Windows;

namespace WPFConverters
{
    public class StringEmptyOrNullToVisibilityConverter : BaseConverter
    {
        public bool Invert { get; set; }

        public bool IsHidden { get; set; }

        protected override object OnConvert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = value as string;
            return (string.IsNullOrEmpty(stringValue) ^ Invert) ? (IsHidden ? Visibility.Hidden : Visibility.Collapsed) : Visibility.Visible;
        }
    }
}
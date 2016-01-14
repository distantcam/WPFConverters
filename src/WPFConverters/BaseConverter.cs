using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPFConverters
{
    public abstract class BaseConverter : MarkupExtension, IValueConverter
    {
        protected abstract object OnConvert(object value, Type targetType, object parameter, CultureInfo culture);

        protected virtual object OnConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => OnConvert(value, targetType, parameter, culture);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => OnConvertBack(value, targetType, parameter, culture);

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
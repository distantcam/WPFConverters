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
                return LoadImage(new Uri((string)value, UriKind.RelativeOrAbsolute));

            if (value is Uri)
                return LoadImage((Uri)value);

            return DependencyProperty.UnsetValue;
        }

        private BitmapImage LoadImage(Uri uri)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = uri;
            image.EndInit();
            return image;
        }
    }
}
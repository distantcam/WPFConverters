using System;
using System.Globalization;
using System.Windows.Media;

namespace WPFConverters
{
    public class BoolToBrushConverter : BaseConverter
    {
        public BoolToBrushConverter()
        {
            FalseBrush = new SolidColorBrush(Colors.Black);
            TrueBrush = new SolidColorBrush(Colors.White);
        }

        public Brush FalseBrush { get; set; }

        public Brush TrueBrush { get; set; }

        protected override object OnConvert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = false;
            if (value is bool)
            {
                flag = (bool)value;
            }
            return flag ? TrueBrush : FalseBrush;
        }
    }
}
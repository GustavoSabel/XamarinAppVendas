using System;
using System.Globalization;
using Xamarin.Forms;

namespace AppVendas.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public string NullText { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return NullText;
            var data = (DateTime)value;
            return data.ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

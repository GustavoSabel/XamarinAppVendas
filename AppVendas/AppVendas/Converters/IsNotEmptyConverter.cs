using System;
using System.Globalization;
using Xamarin.Forms;

namespace AppVendas.Converters
{
    public class IsNotEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !IsEmpty(value);
        }

        private static bool IsEmpty(object value)
        {
            if (value == null)
                return true;
            if (value is decimal valueDecimal)
                return valueDecimal == 0;
            if (value is string valueString)
                return valueString == "";
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

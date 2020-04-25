namespace University_frontend.Extensions
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class NotNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value != null;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Convert(value, targetType, parameter, culture);
    }
}

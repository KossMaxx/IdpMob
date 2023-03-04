using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace idp.App.Converters
{
    public class DateConverter : IValueConverter
    {
        private DateTime date;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value!= null && DateTime.TryParse(value.ToString(), out date)) ? date.ToString("dd.MM.yyyy") : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

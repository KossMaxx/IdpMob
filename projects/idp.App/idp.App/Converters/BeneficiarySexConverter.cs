using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using idp.App.Infrastructure;
using idp.Dal.Models.Enums;
using Xamarin.Forms;

namespace idp.App.Converters
{
    public class BeneficiarySexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is Sex sex)
            {
                return sex.GetDisplayName();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

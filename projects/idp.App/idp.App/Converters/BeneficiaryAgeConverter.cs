using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using idp.Dal.Models.Dictionaries;
using Xamarin.Forms;

namespace idp.App.Converters
{
    public class BeneficiaryAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is DAgeCategory ageCategory)
            {
                return ageCategory.Name;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

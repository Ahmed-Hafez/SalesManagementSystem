using System;
using System.Globalization;
using System.Windows;

namespace SalesManagment
{
    /// <summary>
    /// Converter takes a boolean value and returns <see cref="Visibility"/>
    /// </summary>
    public class BooleanToVisibiltyValueConverter :
        BaseValueConverter<BooleanToVisibiltyValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Hidden : Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

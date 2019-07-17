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
        #region Value converter methods

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return (bool)value ? Visibility.Hidden : Visibility.Visible;
            else
                return (bool)value ? Visibility.Visible : Visibility.Hidden;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

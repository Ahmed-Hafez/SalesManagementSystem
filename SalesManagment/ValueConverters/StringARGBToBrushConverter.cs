using System;
using System.Globalization;
using System.Windows.Media;

namespace SalesManagment
{
    /// <summary>
    /// A converter that takes in an RGB string such as FFFF00FF and converts it to a WPF brush
    /// </summary>
    public class StringARGBToBrushConverter : BaseValueConverter<StringARGBToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{value}"));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

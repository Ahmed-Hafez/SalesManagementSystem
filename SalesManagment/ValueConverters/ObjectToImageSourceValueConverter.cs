using System;
using System.Globalization;

namespace SalesManagment
{
    public class ObjectToImageSourceValueConverter : BaseValueConverter<ObjectToImageSourceValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
                return value.ToString();

            return new ByteArrayToImageSourceValueConverter().Convert(value, targetType, parameter, culture);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

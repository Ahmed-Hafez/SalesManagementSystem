using System;
using System.Globalization;

namespace SalesManagment
{
    /// <summary>
    /// A converter that takes a string which is a path for image on the PC and converts it to Image source
    /// </summary>
    public class ImagePathToImageSourceValueConverter : BaseValueConverter<ImagePathToImageSourceValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO : Exception Handling for unexpected errors here

            if (value is string path)
            {
                var PathToByteArray = new ImagePathToImageByteArrayValueConverter();
                var ByteArrayToImageSource = new ByteArrayToImageSourceValueConverter();

                var binaryData = PathToByteArray.Convert(path, null, null, null);

                return ByteArrayToImageSource.Convert(binaryData, null, null, null);
            }

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

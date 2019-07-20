using System;
using System.Globalization;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SalesManagment
{
    /// <summary>
    /// A converter that takes a string which is a path for image on the PC and converts it to byte array
    /// </summary>
    public class ImageSourceToByteArrayValueConverter : BaseValueConverter<ImageSourceToByteArrayValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO : Exception Handling for unexpected errors here

            if (value is string)
            {
                FileStream fileStream = new FileStream((string)value, FileMode.Open);
                BinaryReader reader = new BinaryReader(fileStream);

                byte[] binaryData = reader.ReadBytes(System.Convert.ToInt32(reader.BaseStream.Length - 1));
                reader.Close();

                return binaryData;
            }

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

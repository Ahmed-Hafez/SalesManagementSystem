using System;
using System.Globalization;
using System.IO;

namespace SalesManagment
{
    /// <summary>
    /// A converter that takes a string which is a path for image on the PC and converts
    /// the image into it to byte array
    /// </summary>
    public class ImagePathToImageByteArrayValueConverter : BaseValueConverter<ImagePathToImageByteArrayValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO : Exception Handling for unexpected errors here

            if (value is string path)
            {
                FileStream fileStream = new FileStream(path, FileMode.Open);
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

using System;
using System.Globalization;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;

namespace SalesManagment
{
    /// <summary>
    /// A converter that takes a byte array and converts it to WPF ImageSource
    /// </summary>
    public class ByteArrayToImageSourceValueConverter : BaseValueConverter<ByteArrayToImageSourceValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO : Exception Handling for unexpected errors here

            if (value is byte[] binaryData)
            {   
                MemoryStream strm = new MemoryStream();
                strm.Write(binaryData, 0, binaryData.Length);
                strm.Position = 0;
                Image img = Image.FromStream(strm);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                ImageSource source = bitmapImage;

                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();

                return source;
            }

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SalesManagment
{
    public class ImageSourceToByteArrayValueConverter : BaseValueConverter<ImageSourceToByteArrayValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // parameter value should be string (The path of the image on the pc)

            // TODO : Exception Handling for unexpected errors here
            FileStream fileStream = new FileStream((string)value, FileMode.Open);
            BinaryReader reader = new BinaryReader(fileStream);

            byte[] binaryData = reader.ReadBytes(System.Convert.ToInt32(reader.BaseStream.Length - 1));
            reader.Close();

            return binaryData;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // parameter value should be byte[]

            if (!(value is byte[]))
                return null;

            byte[] binaryData = (byte[])value;

            MemoryStream strm = new MemoryStream();
            strm.Write(binaryData, 0, binaryData.Length);
            strm.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            ImageSource source = bitmapImage;

            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Seek(0, SeekOrigin.Begin);
            bitmapImage.StreamSource = ms;
            bitmapImage.EndInit();

            return source;
        }
    }
}

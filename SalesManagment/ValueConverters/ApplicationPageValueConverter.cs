using System;
using System.Diagnostics;
using System.Globalization;

namespace SalesManagment
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        #region Value converter methods

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ApplicationPage page)
                return ApplicationDirector.Instance.GetPage(page);

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
       
        #endregion
    }
}

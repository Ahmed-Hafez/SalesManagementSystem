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
            // Finding the targeted page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.None:
                    return null;
                case ApplicationPage.Login:
                    return new LoginPage();
                case ApplicationPage.Main:
                    return new MainPage();
                case ApplicationPage.AddingProducts:
                    return new AddingProductsPage();
                case ApplicationPage.ProductsManagement:
                    return new ProductManagementPage();
                default:
                    Debugger.Break(); // For debugging reasons
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
       
        #endregion
    }
}

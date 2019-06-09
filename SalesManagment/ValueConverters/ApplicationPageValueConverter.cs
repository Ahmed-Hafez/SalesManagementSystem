﻿using System;
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
                case ApplicationPage.Login:
                    return new LoginPage();
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

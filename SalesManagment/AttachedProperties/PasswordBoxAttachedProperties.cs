using System.Windows;
using System.Windows.Controls;

namespace SalesManagment
{
    /// <summary>
    /// The MonitorPassword attached property for a <see cref="PasswordBox"/>
    /// 
    /// 
    /// 
    /// <!--All implementation in the <see cref="BaseAttachedProperty{Parent, Property}"/>-->
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the caller
            var passwordBox = sender as PasswordBox;

            // Make sure it is a PasswordBox object
            if (passwordBox == null)
                return;

            // Remove any previous events
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            // If the caller set MonitorPassword to true...
            if ((bool)e.NewValue)
            {
                // Set default value
                HasTextProperty.SetValue(passwordBox);

                // Start listening out for password changes
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        /// <summary>
        /// Fires when the <see cref="PasswordBox"/> password value is changed
        /// </summary>
        /// <param name="sender">The caller</param>
        /// <param name="e">Th event attached arguments</param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    /// <summary>
    /// The HasText attached property for a <see cref="PasswordBox"/>
    /// <!--All implementation in the <see cref="BaseAttachedProperty{Parent, Property}"/>-->
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        /// <summary>
        /// Sets the HasText property based on if the caller <see cref="PasswordBox"/> has any text
        /// 
        /// 
        /// 
        /// <!--You don't need to this, it was added to simplify setting the value-->
        /// </summary>
        /// <param name="sender">Th caller</param>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}

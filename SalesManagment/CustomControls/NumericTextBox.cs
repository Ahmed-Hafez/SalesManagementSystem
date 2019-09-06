using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace SalesManagment
{
    /// <summary>
    /// Text box accepts only numeric data
    /// </summary>
    public class NumericTextBox : TextBox
    {
        /// <summary>
        /// Indicates whether decimal point is allowed or not
        /// </summary>
        public bool HasDecimalPoint { get; set; } = true;

        /// <summary>
        /// Initializes a new instance from <see cref="NumericTextBox"/> class
        /// </summary>
        public NumericTextBox()
        {
            this.PreviewTextInput += NumericTextBox_PreviewTextInput;
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Make sure that the number has only one decimal point at most
            bool HasDot = false;
            Regex regex = new Regex(@"\d*\.\d*");
            if (regex.IsMatch(((NumericTextBox)sender).Text))
                HasDot = true;

            if(HasDecimalPoint && !HasDot)
                regex = new Regex("[^0-9.]");
            else regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

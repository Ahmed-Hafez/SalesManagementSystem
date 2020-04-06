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
        /// The maximum number of characters to be written in the textbox
        /// </summary>
        public int MaxCharacters { get; set; } = int.MaxValue;

        /// <summary>
        /// Initializes a new instance from <see cref="NumericTextBox"/> class
        /// </summary>
        public NumericTextBox()
        {
            this.PreviewTextInput += NumericTextBox_PreviewTextInput;
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string writtenText = ((NumericTextBox)sender).Text;

            if ((writtenText + e.Text).Length > MaxCharacters)
            {
                e.Handled = true;
                return;
            }

            // Make sure that the number has only one decimal point at most
            bool HasDot = false;
            Regex regex = new Regex(@"\d*\.\d*");
            if (regex.IsMatch(writtenText))
                HasDot = true;

            if(HasDecimalPoint && !HasDot)
                regex = new Regex("[^0-9.]");
            else regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

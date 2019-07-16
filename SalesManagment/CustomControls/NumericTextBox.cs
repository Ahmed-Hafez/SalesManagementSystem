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
        public NumericTextBox()
        {
            this.PreviewTextInput += NumericTextBox_PreviewTextInput;
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

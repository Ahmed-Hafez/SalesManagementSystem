using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace SalesManagment
{
    /// <summary>
    /// Text box accepts only egyptian phone numbers
    /// </summary>
    public class PhoneTextBox : TextBox
    {
        /// <summary>
        /// Initializes a new instance from <see cref="PhoneTextBox"/> class
        /// </summary>
        public PhoneTextBox()
        {
            this.PreviewTextInput += PhoneTextBox_PreviewTextInput;
        }

        private void PhoneTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string txt = ((PhoneTextBox)sender).Text + e.Text;
            int caretIndex = ((PhoneTextBox)sender).CaretIndex;
            if ((caretIndex == 0 && e.Text != "0") || 
                (caretIndex == 1 && e.Text != "1") ||
                (caretIndex == 2 && e.Text != "0" && e.Text != "1" && e.Text != "2" && e.Text != "5") ||
                 txt.Length > 11)
            {
                e.Handled = true;
                return;
            }
            Regex regex = new Regex(@"01*\d{0,9}");
            bool ghghg = regex.IsMatch(txt);
            e.Handled = !(ghghg);
        }
    }
}

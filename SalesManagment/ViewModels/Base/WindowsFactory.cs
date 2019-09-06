using System.Windows;

namespace SalesManagment
{
    /// <summary>
    /// The factory pattern which creates the a specified dialog windows
    /// </summary>
    public interface WindowsFactory
    {
        /// <summary>
        /// The factory method
        /// </summary>
        /// <typeparam name="VMType">The type of the related view model of the dialog window</typeparam>
        Window GetWindow<VMType>()
            where VMType : BaseWindowViewModel<VMType>;
    }
}

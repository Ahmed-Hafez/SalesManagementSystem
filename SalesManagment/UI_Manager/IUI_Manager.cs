using System.Threading.Tasks;

namespace SalesManagment
{
    /// <summary>
    /// The UI manager that handles any UI interaction in the application
    /// </summary>
    public interface IUI_Manager
    {
        /// <summary>
        /// Displays a dialog window to the user
        /// </summary>
        /// <typeparam name="VMType">The type of the related view model of the dialog window</typeparam>
        /// <param name="viewModel"></param>
        void ShowDialog<VMType>(VMType viewModel)
            where VMType : BaseWindowViewModel<VMType>;
    }
}

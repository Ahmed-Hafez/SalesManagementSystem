using System.Threading.Tasks;

namespace SalesManagment
{
    /// <summary>
    /// The UI manager that handles any UI interaction in the application
    /// </summary>
    public interface IUI_Manager
    {
        /// <summary>
        /// Shows the realted dialog window with this view model
        /// </summary>
        /// <typeparam name="VMType">The view model type</typeparam>
        /// <param name="viewModel">The view model to associate with</param>
        void ShowDialog<VMType>(VMType viewModel)
            where VMType : BaseWindowViewModel<VMType>;
    }
}

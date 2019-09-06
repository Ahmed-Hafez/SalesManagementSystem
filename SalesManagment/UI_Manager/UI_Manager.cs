using System;
using System.Windows;

namespace SalesManagment
{
    /// <summary>
    /// The application implementation of the <see cref="IUI_Manager"/> interface
    /// </summary>
    public class UI_Manager : IUI_Manager, WindowsFactory
    {
        /// <summary>
        /// Shows the realted dialog window with this view model
        /// </summary>
        /// <typeparam name="VMType">The view model type</typeparam>
        /// <param name="viewModel">The view model to associate with</param>
        public void ShowDialog<VMType>(VMType viewModel)
            where VMType : BaseWindowViewModel<VMType>
        {
            Window window = GetWindow<VMType>();
            viewModel.SetRelatedWindow(window, viewModel);
            viewModel.RelatedWindow.ShowDialog();
        }



        public Window GetWindow<VMType>()
            where VMType : BaseWindowViewModel<VMType>
        {
            if (typeof(VMType).Equals(typeof(EditProductWindowViewModel)))
                return new EditProductWindow();

            return null;
        }
    }
}

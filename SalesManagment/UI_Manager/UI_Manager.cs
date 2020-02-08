using System;
using System.Windows;

namespace SalesManagment
{
    /// <summary>
    /// The application implementation of the <see cref="IUI_Manager"/> interface
    /// </summary>
    public class UI_Manager : IUI_Manager, WindowsFactory
    {
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
            if (typeof(VMType).Equals(typeof(ProductReportingWindowViewModel)))
                return new ProductReportingWindow();
            return null;
        }
    }
}

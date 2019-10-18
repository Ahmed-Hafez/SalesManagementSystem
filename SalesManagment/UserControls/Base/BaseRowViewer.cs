using System.Windows;
using System.Windows.Controls;

namespace SalesManagment
{
    public class BaseRowViewer : UserControl
    {
        /// <summary>
        /// Inititalizes a new instance from <see cref="BaseRowViewer"/> class
        /// </summary>
        public BaseRowViewer()
        {
            this.Loaded += ProductRowViewer_Loaded;
        }

        private async void ProductRowViewer_Loaded(object sender, RoutedEventArgs e)
        {
            await this.SlideAndFadeInFromLeft(400, keepMargin: false);
        }
    }
}

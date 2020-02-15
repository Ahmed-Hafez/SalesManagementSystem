using System.Windows;
using System.Windows.Controls;

namespace SalesManagment
{
    public class BaseRowViewer : UserControl
    {
        /// <summary>
        /// The duration of the row viewer loading animation
        /// </summary>
        protected int LoadAnimationDuration { get; set; } = 300;

        /// <summary>
        /// Inititalizes a new instance from <see cref="BaseRowViewer"/> class
        /// </summary>
        public BaseRowViewer()
        {
            this.Loaded += ProductRowViewer_Loaded;
        }

        private async void ProductRowViewer_Loaded(object sender, RoutedEventArgs e)
        {
            await this.SlideAndFadeInFromLeft(LoadAnimationDuration, keepMargin: false);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesManagment
{
    /// <summary>
    /// Interaction logic for PageAnimator.xaml
    /// </summary>
    public partial class PageAnimator : UserControl
    {
        #region Dependency Properties


        /// <summary>
        /// The current page in the page animator
        /// </summary>
        public BasePage CurrentPage
        {
            get { return (BasePage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageAnimator), new PropertyMetadata(CurrentPagePropertyChanged));


        #endregion


        public PageAnimator()
        {
            InitializeComponent();
            OldPage.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
            NewPage.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }

        #region Property Changed Events

        /// <summary>
        /// Called when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private async static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //// Get the frames
            var newPageFrame = (d as PageAnimator).NewPage;
            var oldPageFrame = (d as PageAnimator).OldPage;

            // Store the current page content as the old page
            var oldPage = newPageFrame.Content;

            // Remove current page from new page frame
            newPageFrame.Content = null;


            // Animate out the old page when the Loaded event fires
            // during moving frames
            if (oldPage is BasePage page)
            {
                page.ShouldAnimateOut = true;

                // Move the previous page into the old page frame
                oldPageFrame.Content = oldPage;

                if (oldPage != null)
                    // Wait the old page unload animation to finish
                    await Task.Delay(page.SlideAnimationDuration);
            }
            else
            {
                // Move the previous page into the old page frame
                oldPageFrame.Content = oldPage;
            }

            // Set the new page content
            newPageFrame.Content = e.NewValue;
        }

        #endregion
    }
}

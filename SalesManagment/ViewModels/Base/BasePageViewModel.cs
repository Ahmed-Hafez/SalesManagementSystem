using System.Windows;
using System.Windows.Controls;

namespace SalesManagment
{
    /// <summary>
    /// The base class for all view model associated with pages
    /// </summary>
    public class BasePageViewModel : BaseViewModel, IPageAnimation
    {
        #region Public Properties

        /// <summary>
        /// The page associated with this view model
        /// </summary>
        public Page page { get; set; }

        /// <summary>
        /// The page load animation
        /// </summary>
        public PageAnimation LoadAnimation { get; set; } = PageAnimation.None;

        /// <summary>
        /// The page unload animation
        /// </summary>
        public PageAnimation UnloadAnimation { get; set; } = PageAnimation.None;

        #endregion

        #region Methods

        /// <summary>
        /// Specify the associated page to this view model
        /// </summary>
        /// <param name="page">The associated page to this view model</param>
        public void SpecifyAssociatedPage(Page page)
        {
            this.page = page;
            this.page.Loaded += Page_Loaded;
        }

        /// <summary>
        /// Called when page loaded
        /// </summary>
        protected virtual void Page_Loaded(object sender, RoutedEventArgs e) { }
      
        #endregion
    }
}

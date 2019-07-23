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
        public PageAnimation LoadAnimation { get; set; } = PageAnimation.SlideInFromLeft;

        /// <summary>
        /// The page unload animation
        /// </summary>
        public PageAnimation UnloadAnimation { get; set; } = PageAnimation.SlideOutToRight;

        /// <summary>
        /// The duration of the animation in milliseconds
        /// </summary>
        public int SlideAnimationDuration { get; set; } = 300;

        #endregion
    }
}

namespace SalesManagment
{
    /// <summary>
    /// The base class for all view models associated with pages
    /// </summary>
    public class BasePageViewModel : BaseViewModel, IPageAnimation
    {
        #region Public Properties

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

        /// <summary>
        /// The width of the page
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// The Height of the page
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// The minimum width for the frame (Used by some pages except login page)
        /// </summary>
        public double MinFrameWidth { get { return Width - 100; } }
        #endregion
    }
}

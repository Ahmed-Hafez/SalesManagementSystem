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

        #endregion
    }
}

namespace SalesManagment
{
    /// <summary>
    /// Styles of page animations for appearing/disappearing
    /// </summary>
    public enum PageAnimation
    {
        /// <summary>
        /// No Animation Mode
        /// </summary>
        None,

        /// <summary>
        /// The page slides in and fades in from the right
        /// </summary>
        SlideInFromRight,

        /// <summary>
        /// The page slides in and fades in from the left
        /// </summary>
        SlideInFromLeft,

        /// <summary>
        /// The page slides in and fades in from the top
        /// </summary>
        SlideInFromTop,

        /// <summary>
        /// The page slides out and fades out to the left
        /// </summary>
        SlideOutToLeft,

        /// <summary>
        /// The page slides out and fades out to the right
        /// </summary>
        SlideOutToRight,

        /// <summary>
        /// The page slides out and fades out from the top
        /// </summary>
        SlideOutToTop,

        /// <summary>
        /// The page shrinks
        /// </summary>
        SlideShrinkage,

        /// <summary>
        /// The page opens
        /// </summary>
        SlideOpening,

        /// <summary>
        /// The page closes
        /// </summary>
        SlideClosing
    }
}

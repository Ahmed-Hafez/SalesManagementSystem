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
        None = 0,

        /// <summary>
        /// The page slides in and fades from the right
        /// </summary>
        SlideInFromRight = 1,

        /// <summary>
        /// The page slides in and fades from the left
        /// </summary>
        SlideInFromLeft = 2,

        /// <summary>
        /// The page slides out and fades to the left
        /// </summary>
        SlideOutToLeft = 3,

        /// <summary>
        /// The page slides out and fades to the right
        /// </summary>
        SlideOutToRight = 4,

        /// <summary>
        /// The page shrinks
        /// </summary>
        SlideShrinkage = 5,

        /// <summary>
        /// The page opens
        /// </summary>
        SlideOpening = 6,

        /// <summary>
        /// The page closes
        /// </summary>
        SlideClosing = 7,
    }
}

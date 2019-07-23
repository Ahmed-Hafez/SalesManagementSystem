namespace SalesManagment
{
    public interface IPageAnimation
    {
        /// <summary>
        /// The page load animation
        /// </summary>
        PageAnimation LoadAnimation { get; set; }

        /// <summary>
        /// The page unload animation
        /// </summary>
        PageAnimation UnloadAnimation { get; set; }

        /// <summary>
        /// The duration of the animation in milliseconds
        /// </summary>
        int SlideAnimationDuration { get; set; }
    }
}

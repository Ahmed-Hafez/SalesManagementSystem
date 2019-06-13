namespace SalesManagment
{
    public class BasePageViewModel : BaseViewModel, IPageAnimation
    {
        /// <summary>
        /// The page load animation
        /// </summary>
        public PageAnimation LoadAnimation { get; set; } = PageAnimation.None;

        /// <summary>
        /// The page unload animation
        /// </summary>
        public PageAnimation UnloadAnimation { get; set; } = PageAnimation.None;
    }
}

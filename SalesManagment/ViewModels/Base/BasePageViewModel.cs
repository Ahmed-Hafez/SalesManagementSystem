using System.Windows.Controls;

namespace SalesManagment
{
    public class BasePageViewModel : BaseViewModel, IPageAnimation
    {
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
    }
}

using System.Windows.Controls;

namespace SalesManagment
{
    /// <summary>
    /// The factory pattern which creates the a specified pages
    /// </summary>
    public interface PagesFactory
    {
        /// <summary>
        /// The factory method
        /// </summary>
        /// <param name="page">The page indicator</param>
        BasePage GetPage(ApplicationPage page);
    }
}

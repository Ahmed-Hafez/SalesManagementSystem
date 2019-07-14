using System.Windows;

namespace SalesManagment
{
    /// <summary>
    /// Interaction logic with the whole application
    /// </summary>
    public class ApplicationDirector
    {
        /// <summary>
        /// Getting the Shell view model of the application shell
        /// </summary>
        public static ShellViewModel ApplicationShell
        {
            get
            {
                return (ShellViewModel)((ShellView)Application.Current.MainWindow).DataContext;
            }
        }

        /// <summary>
        /// The current user of the application after login
        /// </summary>
        public static User CurrentUser { get; set; }
    }
}

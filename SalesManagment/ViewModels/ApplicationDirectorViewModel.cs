using System.Windows;

namespace SalesManagment
{
    /// <summary>
    /// Interaction logic with the whole application
    /// </summary>
    public class ApplicationDirectorViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// A singleton instance
        /// </summary>
        public static ApplicationDirectorViewModel Instance { get; private set; } = new ApplicationDirectorViewModel();

        /// <summary>
        /// Indicates whether the top menu is visible or not
        /// </summary>
        public bool IsMenuVisible { get; set; }

        /// <summary>
        /// Getting the Shell view model of the application shell
        /// </summary>
        public ShellViewModel ApplicationShell
        {
            get
            {
                return (ShellViewModel)((ShellView)Application.Current.MainWindow).DataContext;
            }
        }

        /// <summary>
        /// The current user of the application after login
        /// </summary>
        public User CurrentUser { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from <see cref="ApplicationDirectorViewModel"/> class
        /// </summary>
        private ApplicationDirectorViewModel() { }

        #endregion
    }
}

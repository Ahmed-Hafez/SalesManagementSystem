using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SalesManagment
{
    /// <summary>
    /// Interaction logic with the whole application
    /// </summary>
    public class ApplicationDirector : BaseViewModel, PagesFactory
    {
        #region Private Members

        /*
         * Note: Page are initialized here to increase performance
         *       and not making instance from them each time you wanna
         *       call them, This increases animation speed also because
         *       the database will not be called except when initializing
         *       them in the first time, and also when any thing changed in the database
         */
        private static Dictionary<ApplicationPage, Page> mApplicationPages;

        #endregion

        #region Public Properties

        /// <summary>
        /// A singleton instance
        /// </summary>
        public static ApplicationDirector Instance { get; private set; } = new ApplicationDirector();

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
        /// Initializes a new instance from <see cref="ApplicationDirector"/> class
        /// </summary>
        private ApplicationDirector()
        {
            InitializePages();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializing pages here to make them ready to use and they just need rendering only,
        /// Also making just one instance from all pages to get it every time and also update it
        /// with simplicity in use
        /// </summary>
        private void InitializePages()
        {
            mApplicationPages = new Dictionary<ApplicationPage, Page>(20);
            mApplicationPages[ApplicationPage.Login] = LoginPage.GetInstance;

            // Products
            var addingProductsPage = AddingProductsPage.GetInstance;
            var productManagementPage = ProductManagementPage.GetInstance;
            mApplicationPages[ApplicationPage.AddingProducts] = addingProductsPage;
            mApplicationPages[ApplicationPage.ProductsManagement] = productManagementPage;

            (addingProductsPage.ViewModel).RegisterObserver(
                (ProductRowViewerListViewModel)productManagementPage.ProductsList.DataContext);

        }

        /// <summary>
        /// The Factory Method
        /// </summary>
        /// <param name="page">The page to get</param>
        public Page GetPage(ApplicationPage page)
        {
            switch (page)
            {
                case ApplicationPage.Login:
                case ApplicationPage.AddingProducts:
                case ApplicationPage.ProductsManagement:
                case ApplicationPage.AddingCategory:
                case ApplicationPage.CategoriesManagement:
                case ApplicationPage.AddingClient:
                case ApplicationPage.ClientsManagement:
                case ApplicationPage.AddingSale:
                case ApplicationPage.SalesManagement:
                case ApplicationPage.AddingUser:
                case ApplicationPage.UsersManagement:
                case ApplicationPage.CreatingBackup:
                case ApplicationPage.RestoringSavedCopy:
                    return mApplicationPages[page];

                default:
                    return null;
            }
        }

        #endregion
    }
}
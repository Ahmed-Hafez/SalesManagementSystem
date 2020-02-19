using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

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
        private static Dictionary<ApplicationPage, BasePage> mApplicationPages;

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
        public static ShellViewModel ApplicationShell
        {
            get
            {
                return (ShellViewModel)((ShellView)Application.Current.MainWindow).DataContext;
            }
        }

        /// <summary>
        /// Returns the main thread
        /// </summary>
        public static Dispatcher MainThread
        {
            get
            {
                return Application.Current.Dispatcher;
            }
        }

        /// <summary>
        /// The current user of the application after login
        /// </summary>
        public static User CurrentUser { get; set; }

        /// <summary>
        /// The current page previewed in the shell
        /// </summary>
        public static BasePage CurrentPage { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from <see cref="ApplicationDirector"/> class
        /// </summary>
        private ApplicationDirector() { }

        #endregion

        #region Methods

        #region Static Methods

        /// <summary>
        /// Notfies all pages that use the category table that it is updated
        /// </summary>
        public static void UpdateCategories()
        {
            ((AddingProductPageViewModel)mApplicationPages[ApplicationPage.AddingProducts].DataContext).FillCategoriesCombobox();
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Initializing pages here to make them ready to use and they just need rendering only,
        /// Also making just one instance from all pages to get it every time and also update it
        /// with simplicity in use
        /// </summary>
        public void InitializePages()
        {
            mApplicationPages = new Dictionary<ApplicationPage, BasePage>(20);
            mApplicationPages[ApplicationPage.Login] = LoginPage.GetInstance;

            // Products
            var addingProductsPage = AddingProductsPage.GetInstance;
            var productManagementPage = ProductManagementPage.GetInstance;

            // Categories
            var categoriesManagementPage = CategoriesManagementPage.GetInstance;

            // Clients
            var addinClientPage = AddingClientPage.GetInstance;
            //var clientManagementPage = ClientManagementPage.GetInstance;

            // Filling the Dictionary
            mApplicationPages[ApplicationPage.AddingProducts] = addingProductsPage;
            mApplicationPages[ApplicationPage.ProductsManagement] = productManagementPage;
            mApplicationPages[ApplicationPage.CategoriesManagement] = categoriesManagementPage;
            mApplicationPages[ApplicationPage.AddingClient] = addinClientPage;

            addingProductsPage.ViewModel.RegisterObserver(
                (ProductRowViewerListViewModel)productManagementPage.ProductsList.DataContext);

            categoriesManagementPage.ViewModel.RegisterObserver(
                (CategoryRowViewerListViewModel)categoriesManagementPage.CategoriesList.DataContext);

        }

        /// <summary>
        /// The Factory Method
        /// </summary>
        /// <param name="page">The page to get</param>
        public BasePage GetPage(ApplicationPage page)
        {
            CurrentPage = mApplicationPages[page];
            return CurrentPage;
        }

        #endregion

        #endregion
    }
}
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SalesManagment
{
    public class MainPageViewModel : BasePageViewModel
    {
        #region Private Members

        /// <summary>
        /// The current page of the application
        /// </summary>
        private ApplicationPage mCurrentPage = ApplicationPage.None;

        #endregion

        #region Public Properties

        /// <summary>
        /// Items of the top menu
        /// </summary>
        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get { return mCurrentPage; }
            private set
            {
                mCurrentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize an instance from the <see cref="MainPageViewModel"/> class
        /// </summary>
        public MainPageViewModel()
        {
            InitializeComponent();

            this.LoadAnimation = PageAnimation.SlideInFromRight;
            this.UnloadAnimation = PageAnimation.SlideOutToRight;

        }

        #endregion

        #region Methods

        #region Overriden Methods

        /// <summary>
        /// Called when page loaded
        /// </summary>
        protected async sealed override void Page_Loaded
            (object sender, System.Windows.RoutedEventArgs e)
        {
            // Wait until The MainPage animation finishes if found
            await Task.Delay(100);

            // Setting the Frame page
            CurrentPage = ApplicationPage.ProductsManagement;
        }

        #endregion

        /// <summary>
        /// Initializes a the page component
        /// </summary>
        private void InitializeComponent()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel
                {
                    Header = "File" ,
                    ForgroundBrushARGB = "FFFFFFFF",
                    MenuItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel { Header="Create Backup" },
                        new MenuItemViewModel { Header="Restore Saved Copy" }
                    }
                },
                new MenuItemViewModel
                {
                    Header = "Products" ,
                    ForgroundBrushARGB = "FFFFFFFF",
                    MenuItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel
                        {
                            Header ="Add Product",
                            Command = new RelayParameterizedCommand((parameter) => AddRelatedPage(parameter)),
                            CommandParameter = ApplicationPage.AddingProducts
                        },
                        new MenuItemViewModel
                        {
                            Header ="Products Management",
                            Command = new RelayParameterizedCommand((parameter) => AddRelatedPage(parameter)),
                            CommandParameter = ApplicationPage.ProductsManagement
                        },
                        new MenuItemViewModel { Header="Add Category" },
                        new MenuItemViewModel { Header="Categories Management"}
                    }
                },
                new MenuItemViewModel
                {
                    Header = "Clients" ,
                    ForgroundBrushARGB = "FFFFFFFF",
                    MenuItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel { Header="Add Client" },
                        new MenuItemViewModel { Header="Clients Management"},
                        new MenuItemViewModel { Header="Add Sale" },
                        new MenuItemViewModel { Header="Sales Management"}
                    }
                },
                new MenuItemViewModel
                {
                    Header = "Users" ,
                    ForgroundBrushARGB = "FFFFFFFF",
                    MenuItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel { Header="Add User" },
                        new MenuItemViewModel { Header="Users Management"}
                    }
                }
            };
        }

        /// <summary>
        /// Adding the related page to the selected Menu Item
        /// </summary>
        private void AddRelatedPage(object page)
        {
            if(page is ApplicationPage)
                CurrentPage = (ApplicationPage)page;
            else
            {
                // TODO : Set Error Code
                throw new Exception("Invalid Parameters: The parameter should be Page Object");
            }
        }

        #endregion
    }
}

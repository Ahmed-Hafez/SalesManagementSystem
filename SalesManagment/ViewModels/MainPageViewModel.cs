using System.Collections.ObjectModel;
using System.Windows.Media;

namespace SalesManagment
{
    public class MainPageViewModel : BasePageViewModel
    {
        #region Private Members

        /// <summary>
        /// The current page of the application
        /// </summary>
        private ApplicationPage mCurrentPage = ApplicationPage.AddingProducts;

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
            this.LoadAnimation = PageAnimation.SlideInFromLeft;
            this.UnloadAnimation = PageAnimation.SlideOutToRight;
        }

        #endregion

        #region Methods

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
                    ForgroundBrush = Brushes.White,
                    MenuItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel { Header="Create Backup" },
                        new MenuItemViewModel { Header="Restore Saved Copy" }
                    }
                },
                new MenuItemViewModel
                {
                    Header = "Products" ,
                    ForgroundBrush = Brushes.White,
                    MenuItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel { Header="Add Product" },
                        new MenuItemViewModel { Header="Products Management"},
                        new MenuItemViewModel { Header="Add Category" },
                        new MenuItemViewModel { Header="Categories Management"}
                    }
                },
                new MenuItemViewModel
                {
                    Header = "Clients" ,
                    ForgroundBrush = Brushes.White,
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
                    ForgroundBrush = Brushes.White,
                    MenuItems = new ObservableCollection<MenuItemViewModel>
                    {
                        new MenuItemViewModel { Header="Add User" },
                        new MenuItemViewModel { Header="Users Management"}
                    }
                }
            };
        }

        #endregion
    }
}

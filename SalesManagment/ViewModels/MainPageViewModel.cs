using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SalesManagment
{
    public class MainPageViewModel : BasePageViewModel
    {
        #region Private Members

        /// <summary>
        /// The current page of the application
        /// </summary>
        private ApplicationPage mCurrentPage = ApplicationPage.None;

        /// <summary>
        /// The (Add Product) page
        /// </summary>
        private AddingProductsPage mAddingProductsPage;

        /// <summary>
        /// The page related to the selected MenuItem
        /// </summary>
        private Page mRelatedPage;

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

        /// <summary>
        /// The command related to add page related to menu item
        /// </summary>
        public ICommand AddPageCommand { get; set; }

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

            AddPageCommand = new RelayParameterizedCommand((parameter) => AddRelatedPage(parameter));
        }

        #endregion

        #region Inner Classes

        /// <summary>
        /// Simple Factory class to find a certain page
        /// </summary>
        private class PageFactory : IFactory
        {
            /// <summary>
            /// The factory method
            /// </summary>
            /// <param name="page">The related <see cref="Page"/> object</param>
            public object GetInstances(object page)
            {
                if (page is AddingProductsPage)
                    return ApplicationPage.AddingProducts;

                return ApplicationPage.None;
            }
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
                        new MenuItemViewModel
                        {
                            Header ="Add Product",
                            Command = new RelayParameterizedCommand(new Action<object>(AddRelatedPage)),
                            CommandParameter = new AddingProductsPage()
                        },
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

        /// <summary>
        /// Adding the related page to the selected Menu Item
        /// </summary>
        private void AddRelatedPage(object page)
        {
            if(page is Page)
            {
                // Factory Design Pattern was used here
                IFactory finder = new PageFactory();
                finder.GetInstances(page);
            }
            else
            {
                // TODO : Set Error Code
                throw new Exception("Invalid Parameters: The parameter should be Page Object");
            }
        }

        #endregion
    }
}

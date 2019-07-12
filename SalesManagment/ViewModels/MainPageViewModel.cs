using System.Collections.ObjectModel;
using System.Windows.Media;

namespace SalesManagment
{
    public class MainPageViewModel : BasePageViewModel
    {
        #region Public Properties

        /// <summary>
        /// Items of the top menu
        /// </summary>
        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize an instance from the <see cref="MainPageViewModel"/> class
        /// </summary>
        public MainPageViewModel()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

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
                        new MenuItemViewModel { Header="Add Class" },
                        new MenuItemViewModel { Header="Classes Management"}
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

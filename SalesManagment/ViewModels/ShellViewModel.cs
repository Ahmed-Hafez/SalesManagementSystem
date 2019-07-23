using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SalesManagment
{
    /// <summary>
    /// The view model that controls the shell view
    /// 
    /// 
    /// 
    /// <!--Note : This view model is the only one which have a WPF components
    ///     and this is exception for the main widow of the program-->
    /// </summary>
    public class ShellViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The window which this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private double mOuterMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private double mWindowRadius = 15;

        /// <summary>
        /// The height of the title bar
        /// </summary>
        private double mTitleHeight = 45;

        #endregion

        #region Public Properties

        /// <summary>
        /// The smallest width for the window
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 800;

        /// <summary>
        /// The smallest height for the window
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 500;

        /// <summary>
        /// The size of ResizeBorder property on WindowChrome
        /// </summary>
        public double ResizeBorder { get; set; } = 5;

        /// <summary>
        /// The size of ResizeBorder property on WindowChrome
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder); } }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public double OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set { mOuterMarginSize = value; }
        }

        /// <summary>
        /// The margin around the window to allow a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public double WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set { mWindowRadius = value; }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// Corener radius of the title bar
        /// </summary>
        public CornerRadius TitleBarCornerRadius { get { return new CornerRadius(WindowRadius, WindowRadius, 0, 0); } }

        /// <summary>
        /// Corener radius of the shell content bottom border
        /// </summary>
        public CornerRadius ShellContentCornerRadius { get { return new CornerRadius(0, 0, WindowRadius, WindowRadius); } }

        /// <summary>
        /// Corner radius of the 'Close' button
        /// </summary>
        public CornerRadius CloseButtonCornerRadius { get { return new CornerRadius(0, WindowRadius - 2, 0, 0); } }

        /// <summary>
        /// Frame corner radius
        /// </summary>
        public CornerRadius FrameCornerRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? new CornerRadius(0) : new CornerRadius(0);
            }
        }

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public double TitleHeight
        {
            get { return mTitleHeight; }
        }

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public GridLength TitleHeightGridLength
        {
            get
            {
                return new GridLength(TitleHeight);
            }
        }

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        /// <summary>
        /// Items of the top menu
        /// </summary>
        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the shell
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the shell
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the shell
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the menu of the shell
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of <see cref="ShellViewModel"/>
        /// </summary>
        /// <param name="window">The window to control, i.e the shell view</param>
        public ShellViewModel(Window window)
        {
            this.mWindow = window;

            mWindow.StateChanged += (sender, e) =>
            {
                // Editting properties when window state changed
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(WindowCornerRadius));
                OnPropertyChanged(nameof(FrameCornerRadius));
            };

            // Initailize commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            InitializeComponent();

            // Fixing window maximizing issue (hiding the bottom content)
            var resizer = new WindowResizer(mWindow);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the Menu component
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
            if (page is ApplicationPage)
                CurrentPage = (ApplicationPage)page;
            else
            {
                // TODO : Set Error Code
                throw new Exception("Invalid Parameters: The parameter should be Page Object");
            }
        }

        #endregion

        #region Private helpers

        /// <summary>
        /// Get the mouse position on the shell
        /// </summary>
        private Point GetMousePosition()
        {
            Point position = Mouse.GetPosition(mWindow);
            if (mWindow.WindowState == WindowState.Normal)
                return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
            else
                return new Point(position.X, position.Y);
        }

        #endregion
    }
}

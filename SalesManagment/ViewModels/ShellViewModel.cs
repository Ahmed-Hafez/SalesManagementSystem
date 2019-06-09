using System.Windows;
using System.Windows.Input;

namespace SalesManagment
{
    /// <summary>
    /// The view model that controls the shell view
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
        private double mWindowRadius = 10;

        private double mTitleHeight = 46;

        #endregion

        #region Public Properties

        /// <summary>
        /// The smallest width for the window
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// The smallest height for the window
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// The size of ResizeBorder property on WindowChrome
        /// </summary>
        public double ResizeBorder { get; set; } = 12;

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
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// TODO Remove this because it is not used
        /// </summary>
        public Thickness InnerContentPadding { get { return new Thickness(20); } }

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
        public CornerRadius CloseButtonCornerRadius { get { return new CornerRadius(0, WindowRadius-2, 0, 0); } }

        /// <summary>
        /// Frame corner radius
        /// </summary>
        public CornerRadius FrameCornerRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? new CornerRadius(0) : new CornerRadius(0, 0, 29, 29);
            }
        }

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public double TitleHeight
        {
            get { return mTitleHeight; }
            set { mTitleHeight = value + mOuterMarginSize; }
        }

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public GridLength TitleHeightGridLength
        {
            get
            {
                return new GridLength(mTitleHeight - mOuterMarginSize + ResizeBorder);
            }
        }

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

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
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
                OnPropertyChanged(nameof(TitleBarCornerRadius));
                OnPropertyChanged(nameof(ShellContentCornerRadius));
                OnPropertyChanged(nameof(CloseButtonCornerRadius));
                OnPropertyChanged(nameof(FrameCornerRadius));
            };

            // Initailize commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            // Fixing window maximizing issue (hiding the bottom content)
            var resizer = new WindowResizer(mWindow);
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

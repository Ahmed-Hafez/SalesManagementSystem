using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesManagment
{
    class ShellViewModel : BaseViewModel
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

        private double mTitleHeight = 40;

        #endregion

        #region Public Properties

        /// <summary>
        /// The size of ResizeBorder property on WindowChrome
        /// </summary>
        public double ResizeBorder { get; set; } = 6;

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
                return mWindow.WindowState == WindowState.Maximized ? 5 : mOuterMarginSize;
            }
            set { mOuterMarginSize = value; }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
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

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance to control ShellView
        /// </summary>
        /// <param name="window"></param>
        public ShellViewModel(Window window)
        {
            this.mWindow = window;

            mWindow.StateChanged += (sender, e) => 
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };
        }

        #endregion
    }
}

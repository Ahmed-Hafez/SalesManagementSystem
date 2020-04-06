using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SalesManagment
{
    public class CartPageViewModel : BasePageViewModel
    {
        #region Public Properties

        #region Design

        /// <summary>
        /// The margin of the title of the page
        /// </summary>
        public Thickness PageTitleMargin { get { return new Thickness(0, 30, 0, 0); } }

        #region BorderFrame

        /// <summary>
        /// The margin of the frame which contains the content of the page
        /// </summary>
        public Thickness BorderFrameMargin { get { return new Thickness(0, 0, 0, 20); } }

        /// <summary>
        /// The padding of the frame which contains the content of the page
        /// </summary>
        public Thickness BorderFramePadding { get { return new Thickness(0); } }

        #endregion

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize an instance from the <see cref="CartPageViewModel"/> class
        /// </summary>
        public CartPageViewModel()
        {
            this.LoadAnimation = PageAnimation.SlideInFromRight;
            this.UnloadAnimation = PageAnimation.SlideOutToLeft;
        }

        #endregion
    }
}

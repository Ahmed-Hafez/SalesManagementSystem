using System.Windows;

namespace SalesManagment
{
    public class ClientManagementPageViewModel : BasePageViewModel
    {
        #region Public Properties

        /// <summary>
        /// The margin of the title of the page
        /// </summary>
        public Thickness PageTitleMargin { get { return new Thickness(0, 30, 0, 0); } }

        #region BorderFrame

        /// <summary>
        /// The margin of the frame which contains the content of the page
        /// </summary>
        public Thickness BorderFrameMargin { get { return new Thickness(0, 0, 0, 10); } }

        /// <summary>
        /// The padding of the frame which contains the content of the page
        /// </summary>
        public Thickness BorderFramePadding { get { return new Thickness(5); } }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize an instance from the <see cref="ProductManagementPageViewModel"/> class
        /// </summary>
        public ClientManagementPageViewModel()
        {
            this.LoadAnimation = PageAnimation.SlideInFromLeft;
            this.UnloadAnimation = PageAnimation.SlideOutToLeft;
        }

        #endregion
    }
}

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SalesManagment
{
    /// <summary>
    /// A base page for all pages to gain base functionality
    /// </summary>
    public class BasePage : Page
    {
        #region Public Properties

        /// <summary>
        /// The animation to play when the page is loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; }

        /// <summary>
        /// The animation to play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; }

        /// <summary>
        /// The duration of the slide animation in milliseconds
        /// </summary>
        public int SlideAnimationDuration { get; set; } = 300;

        /// <summary>
        /// A flag used to indicate that page should animate out during loading
        /// 
        /// <!--Used in changing the container frame in PageAnimator-->
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize a new instance from the <see cref="BasePage"/> class
        /// </summary>
        public BasePage()
        {
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            // Listen out for the page laoding
            this.Loaded += BasePage_Loaded;
        }

        #endregion

        #region Animation load/unload

        /// <summary>
        /// Performing animations when the page is loaded
        /// </summary>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            // If we are setup to animate out on load
            if (ShouldAnimateOut)
                // Animate out the page
                await AnimateOut();
            // Otherwise...
            else
                // Animate the page in
                await AnimateIn();
        }

        /// <summary>
        /// Animates the page while loading
        /// </summary>
        public async Task AnimateIn()
        {
            // Make sure that we have something to do
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            // Resolves the load animation type
            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideInFromRight:
                    await this.SlideAndFadeInFromRight(this.SlideAnimationDuration);
                    break;
                case PageAnimation.SlideInFromLeft:
                    await this.SlideAndFadeInFromLeft(this.SlideAnimationDuration);
                    break;
                case PageAnimation.SlideInFromTop:
                    await this.SlideAndFadeInFromTop(this.SlideAnimationDuration);
                    break;
                case PageAnimation.SlideShrinkage:
                    await this.SlideShrinkage(this.SlideAnimationDuration);
                    break;
                case PageAnimation.SlideOpening:
                    await this.SlideOpening(this.SlideAnimationDuration);
                    break;
                case PageAnimation.SlideClosing:
                    await this.SlideClosing(this.SlideAnimationDuration);
                    break;
                default:
                    await Task.Delay(this.SlideAnimationDuration);
                    break;
            }
        }

        /// <summary>
        /// Animate the page out
        /// </summary>
        public async Task AnimateOut()
        {
            // Resolves the unload animation type
            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideOutToLeft:
                    await this.SlideAndFadeOutToLeft(this.SlideAnimationDuration);
                    break;
                case PageAnimation.SlideOutToRight:
                    await this.SlideAndFadeOutToRight(this.SlideAnimationDuration);
                    break;
                case PageAnimation.SlideOutToTop:
                    await this.SlideAndFadeOutToTop(this.SlideAnimationDuration);
                    break;
                case PageAnimation.SlideClosing:
                    await this.SlideClosing(this.SlideAnimationDuration);
                    break;
                default:
                    break;
            }

            this.Visibility = Visibility.Collapsed;
        }

        #endregion
    }



    /// <summary>
    /// A base page for all pages to gain base functionality 
    /// with added a view model support
    /// </summary>
    /// <typeparam name="VM">The type of view model associated with this page</typeparam>
    public class BasePage<VM> : BasePage
        where VM : BasePageViewModel, new()
    {
        #region Private members

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        private VM mViewModel;

        #endregion

        #region Public properties

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get { return mViewModel; }
            set
            {
                // If nothing has changed, return....
                if (mViewModel == value)
                    return;

                mViewModel = value;

                this.DataContext = mViewModel;
            }
        }

        #endregion
        
        #region Constructor

        /// <summary>
        /// Initialize a new instance from the <see cref="BasePage"/> class
        /// with added a view model support
        /// </summary>
        public BasePage() : base()
        {
            this.ViewModel = new VM();
            PageLoadAnimation = this.ViewModel.LoadAnimation;
            PageUnloadAnimation = this.ViewModel.UnloadAnimation;
            SlideAnimationDuration = this.ViewModel.SlideAnimationDuration;
        }

        #endregion
    }
}

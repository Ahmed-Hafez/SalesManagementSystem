using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SalesManagment
{
    /// <summary>
    /// A base page for all pages to gain base functionality
    /// </summary>
    public class BasePage : Page
    {
        #region Public properties

        /// <summary>
        /// The animation to play when the page is loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideOpening;

        /// <summary>
        /// The animation to play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideClosing;

        /// <summary>
        /// The duration of the slide animation in milliseconds
        /// </summary>
        public int SlideAnimationDuration { get; set; } = 800;

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
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
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

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideInFromRight:
                    await this.SlideAndFadeInFromRight(this.SlideAnimationDuration);
                    break;
                case PageAnimation.SlideInFromLeft:
                    await this.SlideAndFadeInFromLeft(this.SlideAnimationDuration);
                    break;
                case PageAnimation.Slideshrinkage:
                    await this.SlideShrinkage(this.SlideAnimationDuration);
                    break;
                case PageAnimation.SlideOpening:
                    await this.SlideOpening(this.SlideAnimationDuration);
                    break;
                case PageAnimation.SlideClosing:
                    await this.SlideClosing(350);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Animate the page out
        /// </summary>
        public async Task AnimateOut()
        {
            // Make sure that we have something to do
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;
            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideOutToLeft:
                    await this.SlideAndFadeOutToLeft(this.SlideAnimationDuration);
                    break;
                case PageAnimation.SlideOutToRight:
                    await this.SlideAndFadeOutToRight(this.SlideAnimationDuration);
                    break;
                case PageAnimation.SlideClosing:
                    await this.SlideClosing(this.SlideAnimationDuration);
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}

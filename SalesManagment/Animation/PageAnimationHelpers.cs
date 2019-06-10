using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SalesManagment
{
    /// <summary>
    /// Animation Helpers for the pages animations
    /// </summary>
    public static class PageAnimationHelpers
    {
        /// <summary>
        /// performing slide from right and fade in animations to the page
        /// </summary>
        /// <param name="page">The target page</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page, int milliseconds)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.AddSlideFromRight(milliseconds, page.WindowWidth, 0.9f);
            sb.AddFadeIn(milliseconds);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }

        /// <summary>
        /// performing slide to right and fade out animations to the page
        /// </summary>
        /// <param name="page">The target page</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRight(this Page page, int milliseconds)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.RemoveSlideToRight(milliseconds, page.WindowWidth, 0.9f);
            sb.AddFadeOut(milliseconds);

            sb.Begin(page);

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }



        /// <summary>
        /// performing slide from left and fade in animations to the page
        /// </summary>
        /// <param name="page">The target page</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeft(this Page page, int milliseconds)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.AddSlideFromLeft(milliseconds, page.WindowWidth, 0.9f);
            sb.AddFadeIn(milliseconds);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }

        /// <summary>
        /// performing slide to left and fade out animations to the page
        /// </summary>
        /// <param name="page">The target page</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, int milliseconds)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.RemoveSlideToLeft(milliseconds, page.WindowWidth, 0.9f);
            sb.AddFadeOut(milliseconds);

            sb.Begin(page);

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }

        

        /// <summary>
        /// performing slide opening animation to the page
        /// </summary>
        /// <param name="page">The target page</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <returns></returns>
        public static async Task SlideOpening(this Page page, int milliseconds)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.AddSlideWithOpening(milliseconds, page.WindowWidth, 0.9f);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }
        
        /// <summary>
        /// performing slide from right and fade in animations to the page
        /// </summary>
        /// <param name="page">The target page</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <returns></returns>
        public static async Task SlideClosing(this Page page, int milliseconds)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.AddSlideWithClosing(milliseconds, page.WindowHeight, 0.9f);

            sb.Begin(page);
            
            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }



        /// <summary>
        /// performing slide shrinkage animation to the page
        /// </summary>
        /// <param name="page">The target page</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <returns></returns>
        public static async Task SlideShrinkage(this Page page, int milliseconds)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.AddSlideWithShrinkage(milliseconds, page.WindowWidth, 0.9f);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }
    }
}

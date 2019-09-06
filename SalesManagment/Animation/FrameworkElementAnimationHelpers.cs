using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SalesManagment
{
    /// <summary>
    /// Animation Helpers for the framework elements animations
    /// </summary>
    public static class FrameworkElementAnimationHelpers
    {
        #region Right Animations

        /// <summary>
        /// performing slide from right and fade in animations to the element
        /// </summary>
        /// <param name="element">The target element</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static async Task SlideAndFadeInFromRight(this FrameworkElement element, int milliseconds = 300, float decelerationRatio = 0.8f, bool keepMargin = true)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.AddSlideFromRight(milliseconds, (element is Page page) ? page.WindowWidth : element.ActualWidth, decelerationRatio, keepMargin);
            sb.AddFadeIn(milliseconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            // Wait to finish the animation
            await Task.Delay(milliseconds);

        }

        /// <summary>
        /// performing slide to right and fade out animations to the element
        /// </summary>
        /// <param name="element">The target element</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static async Task SlideAndFadeOutToRight(this FrameworkElement element, int milliseconds = 300, float decelerationRatio = 0.8f, bool keepMargin = true)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.RemoveSlideToRight(milliseconds, (element is Page page) ? page.WindowWidth : element.ActualWidth, decelerationRatio, keepMargin);
            sb.AddFadeOut(milliseconds);

            sb.Begin(element);

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }

        #endregion

        #region Left Animations

        /// <summary>
        /// performing slide from left and fade in animations to the element
        /// </summary>
        /// <param name="element">The target element</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static async Task SlideAndFadeInFromLeft(this FrameworkElement element, int milliseconds = 300, float decelerationRatio = 0.8f, bool keepMargin = true)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.AddSlideFromLeft(milliseconds, (element is Page page) ? page.WindowWidth : element.ActualWidth, decelerationRatio, keepMargin);
            sb.AddFadeIn(milliseconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }

        /// <summary>
        /// performing slide to left and fade out animations to the element
        /// </summary>
        /// <param name="element">The target element</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static async Task SlideAndFadeOutToLeft(this FrameworkElement element, int milliseconds = 300, float decelerationRatio = 0.8f, bool keepMargin = true)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.RemoveSlideToLeft(milliseconds, (element is Page page) ? page.WindowWidth : element.ActualWidth, decelerationRatio, keepMargin);
            sb.AddFadeOut(milliseconds);

            sb.Begin(element);

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }

        #endregion

        #region Top Animations

        /// <summary>
        /// performing slide from left and fade in animations to the element
        /// </summary>
        /// <param name="element">The target element</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static async Task SlideAndFadeInFromTop(this FrameworkElement element, int milliseconds = 300, float decelerationRatio = 0.8f, bool keepMargin = true)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.AddSlideFromTop(milliseconds, (element is Page page) ? page.WindowHeight : element.ActualHeight, decelerationRatio, keepMargin);
            sb.AddFadeIn(milliseconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }

        /// <summary>
        /// performing slide to left and fade out animations to the element
        /// </summary>
        /// <param name="element">The target element</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static async Task SlideAndFadeOutToTop(this FrameworkElement element, int milliseconds = 300, float decelerationRatio = 0.8f, bool keepMargin = true)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.RemoveSlideToTop(milliseconds, (element is Page page) ? page.WindowHeight : element.ActualHeight, decelerationRatio, keepMargin);
            sb.AddFadeOut(milliseconds);

            sb.Begin(element);

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }

        #endregion

        #region Opening-Closing Animations

        /// <summary>
        /// performing slide opening animation to the element
        /// </summary>
        /// <param name="element">The target element</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static async Task SlideOpening(this FrameworkElement element, int milliseconds = 300, float decelerationRatio = 0.8f, bool keepMargin = true)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.AddSlideWithOpening(milliseconds, (element is Page page) ? page.WindowWidth * 2: element.ActualWidth, decelerationRatio);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }

        /// <summary>
        /// performing slide from right and fade in animations to the element
        /// </summary>
        /// <param name="element">The target element</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static async Task SlideClosing(this FrameworkElement element, int milliseconds = 300, float decelerationRatio = 0.8f, bool keepMargin = true)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.RemoveSlideWithClosing(milliseconds, (element is Page page) ? page.WindowWidth : element.ActualWidth, decelerationRatio);

            sb.Begin(element);

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }

        #endregion

        #region Shrinkage Animation

        /// <summary>
        /// performing slide shrinkage animation to the element
        /// </summary>
        /// <param name="element">The target element</param>
        /// <param name="milliseconds">The duration of the animation</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static async Task SlideShrinkage(this FrameworkElement element, int milliseconds, float decelerationRatio = 0.8f, bool keepMargin = true)
        {
            Storyboard sb = new Storyboard();

            // Adding animations to the storyboard
            sb.AddSlideWithShrinkage(milliseconds, (element is Page page) ? page.WindowWidth : element.ActualWidth, decelerationRatio);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            // Wait to finish the animation
            await Task.Delay(milliseconds);
        }

        #endregion
    }
}

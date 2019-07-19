using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace SalesManagment
{
    /// <summary>
    /// Animation helpers for <see cref="Storyboard"/>
    /// </summary>
    public static class StoryboardHelpers
    {
        /// <summary>
        /// Adds a slide from right animation to the storyboard
        /// </summary>
        /// <param name="sb">The storyboard to add animation to</param>
        /// <param name="milliseconds">Duration of the animation</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of the deceleration</param>
        public static void AddSlideFromRight(this Storyboard sb, int milliseconds, double offset, float decelerationRatio = 0.0f)
        {
            ThicknessAnimation Animation = new ThicknessAnimation
            {
                Duration = TimeSpan.FromMilliseconds(milliseconds),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Setting the value of the (TargetProperty) attached property on the storyboard
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));

            // Adding the animation to the storyboard
            sb.Children.Add(Animation);
        }

        /// <summary>
        /// Adds a slide from left animation to the storyboard
        /// </summary>
        /// <param name="sb">The storyboard to add animation to</param>
        /// <param name="milliseconds">Duration of the animation</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of the deceleration</param>
        public static void AddSlideFromLeft(this Storyboard sb, int milliseconds, double offset, float decelerationRatio = 0.0f)
        {
            ThicknessAnimation Animation = new ThicknessAnimation
            {
                Duration = TimeSpan.FromMilliseconds(milliseconds),
                From = new Thickness(-offset, 0, offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Setting the value of the (TargetProperty) attached property on the storyboard
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));

            // Adding the animation to the storyboard
            sb.Children.Add(Animation);
        }

        /// <summary>
        /// Removes a slide to right animation to the storyboard
        /// </summary>
        /// <param name="sb">The storyboard to add animation to</param>
        /// <param name="milliseconds">Duration of the animation</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of the deceleration</param>
        public static void RemoveSlideToRight(this Storyboard sb, int milliseconds, double offset, float decelerationRatio = 0.0f)
        {
            ThicknessAnimation Animation = new ThicknessAnimation
            {
                Duration = TimeSpan.FromMilliseconds(milliseconds),
                From = new Thickness(0),
                To = new Thickness(offset, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };

            // Setting the value of the (TargetProperty) attached property on the storyboard
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));

            // Adding the animation to the storyboard
            sb.Children.Add(Animation);
        }

        /// <summary>
        /// Removes a slide to left animation to the storyboard
        /// </summary>
        /// <param name="sb">The storyboard to add animation to</param>
        /// <param name="milliseconds">Duration of the animation</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of the deceleration</param>
        public static void RemoveSlideToLeft(this Storyboard sb, int milliseconds, double offset, float decelerationRatio = 0.0f)
        {
            ThicknessAnimation Animation = new ThicknessAnimation
            {
                Duration = TimeSpan.FromMilliseconds(milliseconds),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };

            // Setting the value of the (TargetProperty) attached property on the storyboard
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));

            // Adding the animation to the storyboard
            sb.Children.Add(Animation);
        }

        /// <summary>
        /// Adds a fade in animation to the storyboard
        /// </summary>
        /// <param name="sb">The storyboard to add animation to</param>
        /// <param name="milliseconds">Duration of the animation</param>
        public static void AddFadeIn(this Storyboard sb, int milliseconds)
        {
            DoubleAnimation Animation = new DoubleAnimation
            {
                Duration = TimeSpan.FromMilliseconds(milliseconds),
                From = 0,
                To = 1
            };

            // Setting the value of the (TargetProperty) attached property on the storyboard
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Opacity"));

            // Adding the animation to the storyboard
            sb.Children.Add(Animation);
        }

        /// <summary>
        /// Adds a fade out animation to the storyboard
        /// </summary>
        /// <param name="sb">The storyboard to add animation to</param>
        /// <param name="milliseconds">Duration of the animation</param>
        public static void AddFadeOut(this Storyboard sb, int milliseconds)
        {
            DoubleAnimation Animation = new DoubleAnimation
            {
                Duration = TimeSpan.FromMilliseconds(milliseconds),
                From = 1,
                To = 0
            };

            // Setting the value of the (TargetProperty) attached property on the storyboard
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Opacity"));

            // Adding the animation to the storyboard
            sb.Children.Add(Animation);
        }

        /// <summary>
        /// Adds a slide opening animation to the storyboard
        /// </summary>
        /// <param name="sb">The storyboard to add animation to</param>
        /// <param name="milliseconds">Duration of the animation</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of the deceleration</param>
        public static void AddSlideWithOpening(this Storyboard sb, int milliseconds, double offset, float decelerationRatio = 0.0f)
        {
            ThicknessAnimation Animation = new ThicknessAnimation
            {
                Duration = TimeSpan.FromMilliseconds(milliseconds),
                From = new Thickness(offset, 0, offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Setting the value of the (TargetProperty) attached property on the storyboard
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));

            // Adding the animation to the storyboard
            sb.Children.Add(Animation);
        }

        /// <summary>
        /// Adds a slide closing animation to the storyboard
        /// </summary>
        /// <param name="sb">The storyboard to add animation to</param>
        /// <param name="milliseconds">Duration of the animation</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of the deceleration</param>
        public static void AddSlideWithClosing(this Storyboard sb, int milliseconds, double offset, float decelerationRatio = 0.0f)
        {
            ThicknessAnimation Animation = new ThicknessAnimation
            {
                Duration = TimeSpan.FromMilliseconds(milliseconds),
                From = new Thickness(0),
                To = new Thickness(offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };

            // Setting the value of the (TargetProperty) attached property on the storyboard
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));

            // Adding the animation to the storyboard
            sb.Children.Add(Animation);
        }

        /// <summary>
        /// Adds a slide shrinkage animation to the storyboard
        /// </summary>
        /// <param name="sb">The storyboard to add animation to</param>
        /// <param name="milliseconds">Duration of the animation</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of the deceleration</param>
        public static void AddSlideWithShrinkage(this Storyboard sb, int milliseconds, double offset, float decelerationRatio = 0.0f)
        {
            ThicknessAnimation Animation = new ThicknessAnimation
            {
                Duration = TimeSpan.FromMilliseconds(milliseconds),
                From = new Thickness(-offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Setting the value of the (TargetProperty) attached property on the storyboard
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));

            // Adding the animation to the storyboard
            sb.Children.Add(Animation);
        }
    }
}

using System.Windows;

namespace SalesManagment
{
    /// <summary>
    /// A base class to run any animation method when a boolean is set to true
    /// and a reverse animation when set to false
    /// </summary>
    /// <typeparam name="Parent">The owner type</typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        #region Public Properties

        /// <summary>
        /// A flag indicating if this is the first time this property has been loaded
        /// </summary>
        public bool FirstLoad { get; set; } = true;

        #endregion

        #region Methods

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // Get the framework element
            if (!(sender is FrameworkElement element))
                return;

            // Don't fire if the value doesn't changed
            if (sender.GetValue(ValueProperty).Equals(value) && !FirstLoad)
                return;

            // On first load
            if (FirstLoad)
            {
                /*
                 * Creates a single self-unhookable event 
                 * for the elements Loaded event
                 * **/
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    // Unhook
                    element.Loaded -= onLoaded;

                    // Do desired animation
                    DoAnimation(element, (bool)value);

                    // Indicate that, No longer in the first load
                    FirstLoad = false;
                };

                // Hook into Loaded event of the element
                element.Loaded += onLoaded;
            }
            else
                // Do desired animation
                DoAnimation(element, (bool)value);
        }

        /// <summary>
        /// The animation method that is fired when the value changes
        /// </summary>
        /// <param name="e">The element to do animation for it</param>
        /// <param name="value">The new value</param>
        protected virtual void DoAnimation(FrameworkElement e, bool value) { }

        #endregion
    }

    /// <summary>
    /// Animates a framework element sliding it in from left on show
    /// and sliding it out to left on hide
    /// </summary>
    public class AnimateFrom_ToTopProperty : AnimateBaseProperty<AnimateFrom_ToTopProperty>
    {
        protected async override void DoAnimation(FrameworkElement e, bool value)
        {
            if (value)
                // Animate in
                await e.SlideAndFadeInFromTop(FirstLoad ? 0 : 700, keepMargin: false);
            else
                // Animate out
                await e.SlideAndFadeOutToTop(FirstLoad ? 0 : 700, keepMargin: false);
        }
    }
}

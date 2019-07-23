using System;
using System.Windows;

namespace SalesManagment
{
    /// <summary>
    /// A base attached property to replace the vanilla of WPF attched property
    /// </summary>
    /// <typeparam name="Parent">The parent class to be attched property</typeparam>
    /// <typeparam name="Property">The type of this attched property</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()
    {
        #region Public events

        /// <summary>
        /// Fires when the value is changed
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        /// <summary>
        /// Fires when the value is changed, even when the value is still the same
        /// </summary>
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        #endregion

        #region Public properties

        #region Singleton

        /// <summary>
        /// A singleton instance from <see cref="Parent"/> class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #endregion

        #region Attached property definitions

        /// <summary>
        /// The attached property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached(
                "Value",
                typeof(Property),
                typeof(BaseAttachedProperty<Parent, Property>),
                new UIPropertyMetadata
                (
                    default(Property),
                    new PropertyChangedCallback(OnValuePropertyChanged),

                    /*
                     * Note : CoerceValueCallback delegate is called when 
                     * value of the attached property being set even if the new value
                     * is the same as the old value
                     * **/
                    new CoerceValueCallback(OnValuePropertyUpdated)
                )
            );

        /// <summary>
        /// The callback event when The <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">The UI element that had it's property changed</param>
        /// <param name="e">The arguments for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Call the parent function
            Instance.OnValueChanged(d, e);

            // Call the event listeners
            Instance.ValueChanged(d, e);
        }

        /// <summary>
        /// The callback event when The <see cref="ValueProperty"/> is changed, even if it is the same value
        /// </summary>
        /// <param name="d">The UI element that had it's property changed</param>
        /// <param name="value">The new value</param>
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            // Call the parent function
            Instance.OnValueUpdated(d, value);

            // Call the event listeners
            Instance.ValueUpdated(d, value);

            // Return the new value
            return value;
        }

        /// <summary>
        /// Gets the attahced property
        /// </summary>
        /// <param name="d">The element to get the property from</param>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// Sets the attahced property
        /// </summary>
        /// <param name="d">The element to get the property from</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Event methods

        /// <summary>
        /// The method that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="sender">The UI element that this property was changed for</param>
        /// <param name="e">The arguments for this event</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }


        /// <summary>
        /// The method that is called when any attached property of this type is changed,
        /// even when the value is still the same
        /// </summary>
        /// <param name="sender">The UI element that this property was changed for</param>
        /// <param name="value">The new value</param>
        public virtual void OnValueUpdated(DependencyObject sender, object value) { }

        #endregion
    }
}

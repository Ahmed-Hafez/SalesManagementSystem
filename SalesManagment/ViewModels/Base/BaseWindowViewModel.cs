using System;
using System.Windows;

namespace SalesManagment
{
    /// <summary>
    /// The base class for all view models associated with windows
    /// </summary>
    public abstract class BaseWindowViewModel<VM> : BaseViewModel
        where VM : BaseWindowViewModel<VM>
    {
        #region Private Members

        /// <summary>
        /// The related window associated with this view model
        /// </summary>
        private Window mRelatedWindow;

        #endregion

        #region Public Properties

        /// <summary>
        /// The related window associated with this view model
        /// </summary>
        public Window RelatedWindow
        {
            get
            {
                if (mRelatedWindow == null)
                    throw new Exception("The related window wasn't associated till now");
                return mRelatedWindow;
            }
            private set
            {
                mRelatedWindow = value;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Set the related window and associate it with the provided view model
        /// </summary>
        /// <param name="relatedWindow">The related window</param>
        /// <param name="viewModel">The view model to associate the window with it</param>
        public void SetRelatedWindow(Window relatedWindow, BaseWindowViewModel<VM> viewModel)
        {
            if (typeof(VM).Equals(GetViewModelType()))
            {
                this.mRelatedWindow = relatedWindow;
                RelatedWindow.DataContext = viewModel;
            }
            else
            {
                throw new Exception("This view model can't be associated with this window");
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns the type of this view model
        /// </summary>
        private Type GetViewModelType()
        {
            return typeof(VM);
        }

        #endregion

        #endregion
    }
}

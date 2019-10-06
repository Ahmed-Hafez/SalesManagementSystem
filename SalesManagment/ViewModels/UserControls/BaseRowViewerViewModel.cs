using System;
using System.Windows;
using System.Windows.Input;

namespace SalesManagment
{
    public abstract class BaseRowViewerViewModel : BaseViewModel 
    {
        #region Public Properties

        #region Design

        /// <summary>
        /// The width of the control
        /// </summary>
        /// 
        /// Get the monitor width to make the width adaptive to it
        public double ViewerWidth { get; } = SystemParameters.PrimaryScreenWidth - 150;

        #endregion

        #region Commands

        /// <summary>
        /// The command used to delete product from the database
        /// </summary>
        public abstract ICommand DeleteCommand { get; set; }

        /// <summary>
        /// The command used to edit product data in the database
        /// </summary>
        public abstract ICommand EditCommand { get; set; }

        #endregion

        #endregion

        #region Public Events

        /// <summary>
        /// Fires when a product is deleted from the database
        /// </summary>
        public event Action<BaseRowViewerViewModel> Deleted;

        /// <summary>
        /// Fires when a product data is edited
        /// </summary>
        public event Action<BaseRowViewerViewModel> Edited;

        #endregion

        #region Constructor

        public BaseRowViewerViewModel()
        {
            DeleteCommand = new RelayCommand(() => Delete());
            EditCommand = new RelayCommand(() => Edit());
        }

        #endregion

        #region Methods

        /// <summary>
        /// Notifing the list which containing this item to delete it
        /// </summary>
        public void Delete()
        {
            // Notify all lists which contains this item to delete it
            Deleted?.Invoke(this);
        }

        /// <summary>
        /// Notifing the list which containing this item to edit it
        /// </summary>
        private void Edit()
        {
            // Notify all lists which contains this item to delete it
            Edited?.Invoke(this);
        }

        #endregion
    }
}
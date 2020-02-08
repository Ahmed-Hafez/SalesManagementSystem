using System;
using System.Windows;
using System.Windows.Input;

namespace SalesManagment
{
    public abstract class BaseRowViewerViewModel : BaseViewModel 
    {
        #region Public Properties

        #region Commands

        /// <summary>
        /// The command used to delete product from the database
        /// </summary>
        public abstract ICommand DeleteCommand { get; set; }

        /// <summary>
        /// The command used to edit product data in the database
        /// </summary>
        public abstract ICommand EditCommand { get; set; }

        /// <summary>
        /// The command used to print product data in the database
        /// </summary>
        public abstract ICommand PrintCommand { get; set; }

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

        /// <summary>
        /// Fires when a product data is requested to be printed
        /// </summary>
        public event Action<BaseRowViewerViewModel> Printed;

        #endregion

        #region Constructor

        public BaseRowViewerViewModel()
        {
            DeleteCommand = new RelayCommand(() => Delete());
            EditCommand = new RelayCommand(() => Edit());
            PrintCommand = new RelayCommand(() => Print());
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
            // Notify all lists which contains this item to edit it
            Edited?.Invoke(this);
        }

        /// <summary>
        /// Printing the item
        /// </summary>
        private void Print()
        {
            Printed?.Invoke(this);
        }

        #endregion
    }
}
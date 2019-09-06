using System;
using System.Windows;
using System.Windows.Input;

namespace SalesManagment
{
    public class ProductRowViewerViewModel : BaseViewModel
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

        #region Product Data

        /// <summary>
        /// The ID of the product
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Quantity of the product in the stock
        /// </summary>
        public double StoredQuantity { get; set; }

        /// <summary>
        /// The Price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The formated price of the product
        /// </summary>
        public string FormatedPrice { get { return Price.ToString() + " L.E"; } }

        /// <summary>
        /// The CategoryName of the product
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// The Description of the product
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Picture of the product
        /// </summary>
        public byte[] Picture { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command used to delete product from the database
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// The command used to edit product data in the database
        /// </summary>
        public ICommand EditCommand { get; set; }

        #endregion

        #endregion

        #region Public Events

        /// <summary>
        /// Fires when a product is deleted from the database
        /// </summary>
        public event Action<ProductRowViewerViewModel> Deleted;

        /// <summary>
        /// Fires when a product data is edited
        /// </summary>
        public event Action<ProductRowViewerViewModel> Edited;

        #endregion

        #region Constructor

        public ProductRowViewerViewModel()
        {
            DeleteCommand = new RelayCommand(() => Delete());
            EditCommand = new RelayCommand(() => Edit());
        }

        #endregion

        #region Methods

        /// <summary>
        /// Notifing the list which containing this item to delete it
        /// </summary>
        private void Delete()
        {
            // Notify all lists which contains this item to delete it
            Deleted?.Invoke(this);
        }


        private void Edit()
        {
            // Notify all lists which contains this item to delete it
            Edited?.Invoke(this);
        }

        #endregion
    }
}

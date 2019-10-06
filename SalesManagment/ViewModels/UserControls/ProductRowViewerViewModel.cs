using System;
using System.Windows;
using System.Windows.Input;

namespace SalesManagment
{
    public class ProductRowViewerViewModel : BaseRowViewerViewModel
    {
        #region Public Properties

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

        #region Public Commands

        public override ICommand DeleteCommand { get; set; }
        public override ICommand EditCommand { get; set;}

        #endregion

        #endregion

        //#region Public Events

        //public override event Action<BaseRowViewerViewModel> Deleted;
        //public override event Action<BaseRowViewerViewModel> Edited;

        //#endregion

        //#region Methods

        ///// <summary>
        ///// Notifing the list which containing this item to delete it
        ///// </summary>
        //private void Delete()
        //{
        //    // Notify all lists which contains this item to delete it
        //    Deleted?.Invoke(this);
        //}


        //private void Edit()
        //{
        //    // Notify all lists which contains this item to delete it
        //    Edited?.Invoke(this);
        //}

        //#endregion
    }
}

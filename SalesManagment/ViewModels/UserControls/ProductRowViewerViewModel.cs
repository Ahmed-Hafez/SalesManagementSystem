using System.Windows;

namespace SalesManagment
{
    public class ProductRowViewerViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The width of the control
        /// </summary>
        /// 
        /// Get the monitor width to make the width adaptive to it
        public double ViewerWidth { get; } = SystemParameters.PrimaryScreenWidth - 150;

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
        public double Price { get; set; }

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
        public string Picture { get; set; }

        #endregion

        #endregion
    }
}

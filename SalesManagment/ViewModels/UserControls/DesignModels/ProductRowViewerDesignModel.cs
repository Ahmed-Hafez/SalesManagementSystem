using System.Windows.Media;

namespace SalesManagment
{
    public class ProductRowViewerDesignModel : ProductRowViewerViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ProductRowViewerDesignModel Instance { get { return new ProductRowViewerDesignModel(); } }

        #endregion

        #region Contructor

        /// <summary>
        /// Initializes a new instance from <see cref="ProductRowViewerDesignModel"/> class
        /// </summary>
        public ProductRowViewerDesignModel()
        {
            ID = 25156;
            Name = "Samsung Galaxy A10";
            StoredQuantity = 13;
            Price = 2000;
            Category = new Category(312, "Phones");
            Picture = @"E:\samsunga10.jpg";
        }

        #endregion
    }
}

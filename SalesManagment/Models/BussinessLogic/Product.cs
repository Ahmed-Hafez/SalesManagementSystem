using System.Data;
using System.Data.SqlClient;

namespace SalesManagment
{
    public class Product
    {
        #region Public Properties

        /// <summary>
        /// Product ID
        /// </summary>
        public long ProductID { get; private set; }

        /// <summary>
        /// Product Label
        /// </summary>
        public string ProductLabel { get; set; }

        /// <summary>
        /// The quantity of this product in the stock
        /// </summary>
        public double QuantityInStock { get; set; }

        /// <summary>
        /// Product Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Product Image
        /// </summary>
        public byte ProductImage { get; set; }

        /// <summary>
        /// The category ID of this product category
        /// </summary>
        public long CategoryID { get; private set; }

        #endregion

        #region Methods

        #region Static Methods

        /// <summary>
        /// Getting all product categories from database
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllCategories()
        {
            var categories = DataConnection.SelectData("Get_All_Categories_Procedure", null);

            // If categories found, return it
            if (categories.Rows.Count > 0)
                return categories;

            // Otherwise
            return null;
        }

        #endregion

        #region Instance Methods

        public void AddProduct
            (long productID, string productLabel,
            double quantityInStock, decimal price, 
            byte ProductImage, long categoryID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@Product_ID", SqlDbType.VarChar);
            sqlParameters[0].Value = productID;
            sqlParameters[1] = new SqlParameter("@Product_Label", SqlDbType.VarChar);
            sqlParameters[1].Value = productLabel;
            sqlParameters[2] = new SqlParameter("@Quantity_in_Stock", SqlDbType.Int);
            sqlParameters[2].Value = quantityInStock;
            sqlParameters[3] = new SqlParameter("@Price", SqlDbType.VarChar);
            sqlParameters[3].Value = price;
            sqlParameters[4] = new SqlParameter("@Product_Image", SqlDbType.Image);
            sqlParameters[4].Value = ProductImage;
            sqlParameters[5] = new SqlParameter("@Category_ID", SqlDbType.Int);
            sqlParameters[5].Value = categoryID;

            DataConnection.ExcuteCommand("Add_Product_Procedure", sqlParameters);
        }

        #endregion

        #endregion
    }
}

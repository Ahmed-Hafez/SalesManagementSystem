using System;
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
        public long ID { get; private set; }

        /// <summary>
        /// Product Label
        /// </summary>
        public string Name { get; set; }

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
        public byte[] Image { get; set; }

        /// <summary>
        /// The category ID of this product category
        /// </summary>
        public long CategoryID { get; private set; }

        #endregion

        #region Constructor

        public Product(
            long productID, string productName,
            double quantityInStock, decimal price,
            byte[] productImage, long categoryID)
        {
            if (productID == 0L || string.IsNullOrEmpty(productName)
                || string.IsNullOrWhiteSpace(productName)
                || quantityInStock == 0
                || price == 0 || productImage == null
                || categoryID == 0)
            {
                throw new Exception("Invalid Data");
            }

            this.ID = productID;
            this.Name = productName;
            this.QuantityInStock = quantityInStock;
            this.Price = price;
            this.Image = productImage;
            this.CategoryID = categoryID;
        }

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

        public static bool Find(long productID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Product_ID", SqlDbType.VarChar);
            sqlParameters[0].Value = productID;

            var dt = DataConnection.SelectData("Find_Product_Procedure", sqlParameters);

            if (dt.Rows.Count > 0)
                return true;

            return false;
        }

        #endregion

        #region Instance Methods

        public bool Add()

        {
            // Check if there is already product with this ID in the database
            if (Find(ID))
                return false;

            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@Product_ID", SqlDbType.VarChar);
            sqlParameters[0].Value = ID;
            sqlParameters[1] = new SqlParameter("@Product_Label", SqlDbType.VarChar);
            sqlParameters[1].Value = Name;
            sqlParameters[2] = new SqlParameter("@Quantity_in_Stock", SqlDbType.Int);
            sqlParameters[2].Value = QuantityInStock;
            sqlParameters[3] = new SqlParameter("@Price", SqlDbType.VarChar);
            sqlParameters[3].Value = Price;
            sqlParameters[4] = new SqlParameter("@Product_Image", SqlDbType.Image);
            sqlParameters[4].Value = Image;
            sqlParameters[5] = new SqlParameter("@Category_ID", SqlDbType.Int);
            sqlParameters[5].Value = CategoryID;

            DataConnection.ExcuteCommand("Add_Product_Procedure", sqlParameters);

            return true;
        }

        #endregion

        #endregion
    }
}

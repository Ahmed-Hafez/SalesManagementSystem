using System;
using System.Collections.Generic;
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
        /// Description about the product
        /// </summary>
        public string Description { get; set; }

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
        public Category Category { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from <see cref="Product"/> class
        /// </summary>
        /// <param name="id">ID of the product</param>
        /// <param name="name">Name of the product</param>
        /// <param name="description">Description of the product</param>
        /// <param name="quantityInStock">Quantity from the product in the stock</param>
        /// <param name="price">Price of the product</param>
        /// <param name="image">Image of the product</param>
        /// <param name="categoryID">Category ID of this product</param>
        public Product(
            long id, string name,
            string description,
            double quantityInStock, decimal price,
            byte[] image, long categoryID)
        {
            if (id == 0L || string.IsNullOrEmpty(name)
                || string.IsNullOrWhiteSpace(name)
                || quantityInStock == 0
                || price == 0 || image == null
                || categoryID == 0)
            {
                throw new Exception("Invalid Data");
            }

            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.QuantityInStock = quantityInStock;
            this.Price = price;
            this.Image = image;
            this.Category = Category.GetCategory(categoryID);
        }

        #endregion

        #region Methods

        #region Static Methods

        /// <summary>
        /// Getting all product categories from database
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetAllProducts()
        {
            var products = DataConnection.SelectData("Get_All_Products_Procedure", null);
            var productsList = new List<Product>();

            // If categories found, return it
            if (products.Rows.Count > 0)
            {
                for (int i = 0; i < products.Rows.Count; i++)
                {
                    long productID = Convert.ToInt64(products.Rows[i].Field<string>("Product_ID"));
                    productsList.Add(GetProduct(productID));
                }
                return productsList;
            }

            // Otherwise
            return null;
        }

        /// <summary>
        /// Returns true if there is a product with this ID in the database
        /// </summary>
        /// <param name="productID">The ID of the product to search for</param>
        public static bool IsFound(long productID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Product_ID", SqlDbType.VarChar);
            sqlParameters[0].Value = productID;

            var dt = DataConnection.SelectData("Find_Product_Procedure", sqlParameters);

            if (dt.Rows.Count > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Returns a product with the specified id if found
        /// </summary>
        /// <param name="productID">ID of the product</param>
        public static Product GetProduct(long productID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Product_ID", SqlDbType.VarChar);
            sqlParameters[0].Value = productID;

            var dt = DataConnection.SelectData("Find_Product_Procedure", sqlParameters);

            if (dt.Rows.Count > 0)
                return GetProduct(dt.Rows[0]);
            else
                throw new Exception($"Product with the ID = {productID} is not found");
        }

        /// <summary>
        /// Returns a product with the specified id if found
        /// </summary>
        /// <param name="product">The data row in the database 
        /// which hold the product</param>
        private static Product GetProduct(DataRow product)
        {
            long id = Convert.ToInt64(product.Field<string>("Product_ID"));
            string name = product.Field<string>("Product_Label");
            string description = product.Field<string>("Product_Description");
            double quantity = product.Field<int>("Quantity_in_Stock");
            decimal price = Convert.ToDecimal(product.Field<string>("Price"));
            byte[] image = product.Field<byte[]>("Product_Image");
            long categoryId = product.Field<int>("Category_ID");

            return new Product(id, name, description, quantity, price, image, categoryId);
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Adds a new product to the database,
        /// Returns True if the product was added otherwise false
        /// </summary>
        public bool Add()

        {
            // Check if there is already product with this ID in the database
            if (IsFound(ID))
                return false;

            SqlParameter[] sqlParameters = new SqlParameter[7];
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
            sqlParameters[5].Value = this.Category.ID;
            sqlParameters[6] = new SqlParameter("@Product_Description", SqlDbType.VarChar);
            sqlParameters[6].Value = Description;

            DataConnection.ExcuteCommand("Add_Product_Procedure", sqlParameters);

            return true;
        }

        /// <summary>
        /// Returns the category name
        /// </summary>
        public override string ToString()
        {
            return Name;
        }

        #endregion

        #endregion
    }
}

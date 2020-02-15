using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SalesManagment
{
    /// <summary>
    /// The categories of product
    /// </summary>
    public struct Category
    {
        #region Public properties

        /// <summary>
        /// Category ID
        /// </summary>
        public long ID { get; private set; }

        /// <summary>
        /// Category Name
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from <see cref="Category"/> class
        /// </summary>
        /// <param name="id">Category ID</param>
        /// <param name="name">Category Name</param>
        public Category(long id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        #endregion

        #region Methods

        #region Static Methods

        /// <summary>
        /// Getting all product categories from database
        /// </summary>
        /// <returns></returns>
        public static List<Category> GetAllCategories()
        {
            var categories = DataConnection.SelectData("Get_All_Categories_Procedure", null);
            var categoriesList = new List<Category>();

            // If categories found, return it
            if (categories.Rows.Count > 0)
            {
                for (int i = 0; i < categories.Rows.Count; i++)
                {
                    long categoryID = categories.Rows[i].Field<int>("Category_ID");
                    string categoryName = categories.Rows[i].Field<string>("Description");
                    categoriesList.Add(new Category(categoryID, categoryName));
                }
                return categoriesList;
            }

            // Otherwise
            return null;
        }

        /// <summary>
        /// Returns true if there is a category with this ID in the database
        /// </summary>
        /// <param name="categoryID">The ID of the category to search for</param>
        public static bool IsFound(long categoryID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Category_ID", SqlDbType.Int);
            sqlParameters[0].Value = categoryID;

            var dt = DataConnection.SelectData("Find_Category_Procedure", sqlParameters);

            if (dt.Rows.Count > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Returns a category with the specified id if found
        /// </summary>
        /// <param name="categoryID">ID of the category</param>
        public static Category GetCategory(long categoryID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Category_ID", SqlDbType.Int);
            sqlParameters[0].Value = categoryID;

            var dt = DataConnection.SelectData("Find_Category_Procedure", sqlParameters);

            if (dt.Rows.Count > 0)
            {
                long id = dt.Rows[0].Field<int>("Category_ID");
                string name = dt.Rows[0].Field<string>("Description");
                return new Category(id, name);
            }
            else
                throw new Exception($"Category with the ID = {categoryID} is not found");
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Edits the category data in the database
        /// </summary>
        public void Edit()
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Category_ID", SqlDbType.Int);
            sqlParameters[0].Value = ID;
            sqlParameters[1] = new SqlParameter("@Description", SqlDbType.VarChar);
            sqlParameters[1].Value = Name.ToString();

            DataConnection.ExcuteCommand("Edit_Category_Procedure", sqlParameters);
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

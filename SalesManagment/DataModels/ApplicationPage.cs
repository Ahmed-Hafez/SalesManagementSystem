namespace SalesManagment
{
    /// <summary>
    /// A page of the application
    /// </summary>
    public enum ApplicationPage
    {
        /// <summary>
        /// Display no pages
        /// </summary>
        None = 0,

        /// <summary>
        /// The initial login page
        /// </summary>
        Login = 1,

        /// <summary>
        /// The main page of the program
        /// </summary>
        Main = 2,

        /// <summary>
        /// The page used to add a new product
        /// </summary>
        AddingProducts = 3,

        /// <summary>
        /// The page used to manage products
        /// </summary>
        ProductsManagement = 4,

        /// <summary>
        /// The page used to add a new class
        /// </summary>
        AddingCategory = 5,

        /// <summary>
        /// The page used to manage classes
        /// </summary>
        CategoriesManagement = 6,

        /// <summary>
        /// The page used to add a new client
        /// </summary>
        AddingClient = 7,

        /// <summary>
        /// The page used to manage clients
        /// </summary>
        ClientsManagement = 8,

        /// <summary>
        /// The page used to add a new sale
        /// </summary>
        AddingSale = 9,

        /// <summary>
        /// The page used to manage products
        /// </summary>
        SalesManagement = 10,

        /// <summary>
        /// The page used to add a new user
        /// </summary>
        AddingUser = 11,

        /// <summary>
        /// The page used to manage users
        /// </summary>
        UsersManagement = 12,

        /// <summary>
        /// The page used to creat backup
        /// </summary>
        CreatingBackup = 13,

        /// <summary>
        /// The page used to restore saved copy
        /// </summary>
        RestoringSavedCopy = 14
    }
}

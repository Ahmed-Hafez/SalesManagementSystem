﻿namespace SalesManagment
{
    /// <summary>
    /// A page of the application
    /// </summary>
    public enum ApplicationPage
    {
        /// <summary>
        /// Display no pages
        /// </summary>
        None,

        /// <summary>
        /// The initial login page
        /// </summary>
        Login,

        /// <summary>
        /// The page used to add a new product
        /// </summary>
        AddingProducts,

        /// <summary>
        /// The page used to manage products
        /// </summary>
        ProductsManagement,

        /// <summary>
        /// The page used to manage categories of products
        /// </summary>
        CategoriesManagement,

        /// <summary>
        /// The page used to add a new client
        /// </summary>
        AddingClient,

        /// <summary>
        /// The page used to manage clients
        /// </summary>
        ClientsManagement,

        /// <summary>
        /// The page used to represent the cart
        /// </summary>
        Cart,

        /// <summary>
        /// The page used to add a new user
        /// </summary>
        AddingUser,

        /// <summary>
        /// The page used to manage users
        /// </summary>
        UsersManagement,

        /// <summary>
        /// The page used to creat backup
        /// </summary>
        CreatingBackup,

        /// <summary>
        /// The page used to restore saved copy
        /// </summary>
        RestoringSavedCopy
    }
}

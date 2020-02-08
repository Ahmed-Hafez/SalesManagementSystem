using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace SalesManagment
{
    /// <summary>
    /// The view model of the <see cref="EditProductWindow"/> dialog window
    /// </summary>
    public class EditProductWindowViewModel : BaseWindowViewModel<EditProductWindowViewModel>
    {
        #region Private Members

        /// <summary>
        /// The binary representation of the product image
        /// </summary>
        private byte[] mProductImage;

        #endregion

        #region Public Properties

        /// <summary>
        /// The new data of the product
        /// </summary>
        public Product NewProductData { get; private set; }

        #region Categories

        /// <summary>
        /// Categories of the products
        /// </summary>
        public List<Category> CategoryItems { get; set; }

        #endregion

        #region Product Data

        /// <summary>
        /// ID of the product
        /// </summary>
        public long ProductID { get; set; }

        /// <summary>
        /// The category of the product
        /// </summary>
        public Category ProductCategory { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Description of the product
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// Stored quantity from this product
        /// </summary>
        public double? ProductStoredQuantity { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        public decimal? ProductPrice { get; set; }

        /// <summary>
        /// The path of the image on the PC
        /// </summary>
        public object ProductImage { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command related to select product photos to show
        /// </summary>
        public ICommand SelectPhotoCommand { get; set; }

        /// <summary>
        /// The command related to the Edit button
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// The command related to the Cancel button
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #endregion

        #endregion

        #region Contructor

        /// <summary>
        /// Initialize an instance from the <see cref="EditProductWindowViewModel"/> class
        /// </summary>
        /// <param name="product">The product to edit</param>
        public EditProductWindowViewModel(Product product)
        {
            NewProductData = product;

            ProductID = product.ID;

            ProductCategory = product.Category;

            ProductName = product.Name;

            ProductDescription = product.Description;

            ProductStoredQuantity = product.QuantityInStock;

            ProductPrice = product.Price;

            ProductImage = product.Image;

            mProductImage = product.Image;

            CategoryItems = Category.GetAllCategories();

            SelectPhotoCommand = new RelayCommand(SelectPhoto);
            EditCommand = new RelayCommand(EditProduct);
            CancelCommand = new RelayCommand(CancelEditting);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adding photo from the pc into the image frame
        /// </summary>
        private void SelectPhoto()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = " |*.JPG; *.PNG; *.JPEG";
            if (openFileDialog.ShowDialog() == true)
            {
                var path = openFileDialog.FileName;
                // Storing the image for use
                mProductImage =
                    (byte[])new ImagePathToImageByteArrayValueConverter().Convert(path, null, null, null);

                ProductImage = path;
            }
        }

        /// <summary>
        /// Editting the product data
        /// </summary>
        private void EditProduct()
        {
            Product product = new Product(
                    ProductID,
                    ProductName,
                    ProductDescription,
                    ProductStoredQuantity.Value,
                    ProductPrice.Value,
                    mProductImage,
                    ProductCategory.ID
                );
            product.Edit();
            NewProductData = product;
            RelatedWindow.Close();
        }

        /// <summary>
        /// Cancel the editing action
        /// </summary>
        private void CancelEditting()
        {
            RelatedWindow.Close();
        }

        public override object WindowLoaded(params object[] parameters)
        {
            return null;
        }

        #endregion
    }
}

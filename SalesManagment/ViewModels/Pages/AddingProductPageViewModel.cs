using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace SalesManagment
{
    /// <summary>
    /// The view model that controls the  AddingProductPage View
    /// </summary>
    public class AddingProductPageViewModel : BasePageViewModel
    {
        #region Private Members

        private byte[] mProductImage;

        #endregion

        #region Public Properties

        #region Design

        /// <summary>
        /// The margin of the title of the page
        /// </summary>
        public Thickness PageTitleMargin { get { return new Thickness(0, 30, 0, 0); } }

        #region BorderFrame

        /// <summary>
        /// The margin of the frame which contains the content of the page
        /// </summary>
        public Thickness BorderFrameMargin { get { return new Thickness(0, 0, 0, 80); } }

        /// <summary>
        /// The padding of the frame which contains the content of the page
        /// </summary>
        public Thickness BorderFramePadding { get { return new Thickness(20, 50, 20, 15); } }

        #endregion

        /// <summary>
        /// The padding between the frame and the content in the left
        /// </summary>
        public Thickness LeftContentPadding { get { return new Thickness(0, 5, 0, 0); } }

        #region Product Image

        #region Product Image Frame

        /// <summary>
        /// The thickness of the image frame
        /// </summary>
        public Thickness ProductImageFrameThickness { get; set; } = new Thickness(2);

        /// <summary>
        /// The height of the image frame
        /// </summary>
        public double ProductImageFrameHeight { get; set; } = 250;

        /// <summary>
        /// The width of the image frame
        /// </summary>
        public double ProductImageFrameWidth { get; set; } = 200;

        #endregion

        #endregion

        #endregion

        #region Categories

        /// <summary>
        /// Checks if the category items combo box has items on it
        /// </summary>
        public bool IsCategoryItemsComboBoxEnabled { get; private set; } = false;

        /// <summary>
        /// Category of the 
        /// </summary>
        public List<Category> CategoryItems { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command related to select product photos to show
        /// </summary>
        public ICommand SelectPhotoCommand { get; set; }

        /// <summary>
        /// The command related to add a new product to the database
        /// </summary>
        public ICommand AddProductCommand { get; set; }

        #endregion

        #region Product Data

        /// <summary>
        /// ID of the product
        /// </summary>
        public long? ProductID { get; set; }

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
        public double? StoredQuantity { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// The path of the image on the PC
        /// </summary>
        public string ImagePath { get; set; }

        #endregion

        #endregion

        #region Contructor

        /// <summary>
        /// Initialize an instance from the <see cref="AddingProductPageViewModel"/> class
        /// </summary>
        public AddingProductPageViewModel()
        {
            CategoryItems = Category.GetAllCategories();
            if (CategoryItems != null)
                IsCategoryItemsComboBoxEnabled = true;

            SelectPhotoCommand = new RelayCommand(SelectPhoto);
            AddProductCommand = new RelayCommand(AddProduct);
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
                ImagePath = openFileDialog.FileName;

                // Storing the image for use
                mProductImage = ConvertImageToByteArray();
            }
        }

        /// <summary>
        /// Attempts to add a new product to the database
        /// </summary>
        private void AddProduct()
        {
            // Validate data
            if (ProductID == 0L || ProductID == null)
            {
                MessageBox.Show("Product ID shouldn't be zero", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ProductCategory == null)
            {
                MessageBox.Show("Category must be selected", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(ProductName) || string.IsNullOrWhiteSpace(ProductName))
            {
                MessageBox.Show("Product must have a name", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (StoredQuantity == 0)
            {
                MessageBox.Show("Stored quantity should be at least 1", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Price == null)
            {
                MessageBox.Show("Set the price of the product correctly", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ImagePath == null)
            {
                MessageBox.Show("Product should have an image", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ProductDescription == null) ProductDescription = "";

            Product product = new Product(ProductID.Value, ProductName,
                ProductDescription, 
                StoredQuantity.Value, 
                Price.Value,
                mProductImage,
                ProductCategory.ID);

            if (product.Add())
            {
                MessageBox.Show("Product was added", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                ProductID = null;
                ProductName = null;
                ProductDescription = null;
                StoredQuantity = null;
                Price = null;
                ImagePath = null;
            }
            else
                MessageBox.Show("There is already a product with the same ID", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Converts the image in the specified image path to a byte array to store in the database
        /// </summary>
        private byte[] ConvertImageToByteArray()
        {
            // Get the image from the specified path
            FileStream fileStream = new FileStream(ImagePath, FileMode.Open);
            BinaryReader reader = new BinaryReader(fileStream);

            byte[] binaryData = reader.ReadBytes(Convert.ToInt32(reader.BaseStream.Length - 1));
            reader.Close();
            return binaryData;
        }

        #endregion
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SalesManagment
{
    /// <summary>
    /// The view model that controls the  AddingProductPage View
    /// </summary>
    public class AddingProductPageViewModel : BasePageViewModel
    {
        #region PrivateMember

        /// <summary>
        /// The product image
        /// </summary>
        private ImageSource mProductImageSource;

        #endregion

        #region Public Properties

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

        #region ProductImage    

        #region ProductImageFrame

        /// <summary>
        /// The thickness of the image frame
        /// </summary>
        public Thickness ProductImageFrameThickness { get; set; } = new Thickness(2);

        /// <summary>
        /// The height of the image frame
        /// </summary>
        public double ProductImageFrameHeight { get; set; } = 170;

        /// <summary>
        /// The width of the image frame
        /// </summary>
        public double ProductImageFrameWidth { get; set; } = 300;

        #endregion

        /// <summary>
        /// The product image
        /// </summary>
        public ImageSource ProductImageSource
        {
            get { return mProductImageSource; }
            set
            {
                mProductImageSource = value;
                OnPropertyChanged(nameof(ProductImageSource));
            }
        }

        #endregion

        #region Categories

        /// <summary>
        /// Checks if the category items combo box has items on it
        /// </summary>
        public bool IsCategoryItemsComboBoxEnabled { get; private set; } = false;

        /// <summary>
        /// Category of the 
        /// </summary>
        public DataTable CategoryItems { get; set; }

        #endregion

        /// <summary>
        /// The command related to select product photos to show
        /// </summary>
        public ICommand SelectPhotoCommand { get; set; }

        #endregion

        #region Contructor

        /// <summary>
        /// Initialize an instance from the <see cref="AddingProductPageViewModel"/> class
        /// </summary>
        public AddingProductPageViewModel()
        {
            this.LoadAnimation = PageAnimation.SlideInFromLeft;
            CategoryItems = Product.GetAllCategories();
            if (CategoryItems != null)
                IsCategoryItemsComboBoxEnabled = true;

            SelectPhotoCommand = new RelayCommand(SelectPhoto);
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
                ProductImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
        }

        #endregion
    }
}

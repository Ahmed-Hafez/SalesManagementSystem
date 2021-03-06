﻿using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace SalesManagment
{
    public class ProductRowViewerListViewModel : BaseRowViewerListViewModel
    {
        #region Private Members

        /// <summary>
        /// The type of search on the products list
        /// </summary>
        private ProductSearchType mProductSearchType = ProductSearchType.Name;

        #endregion

        #region Public Properties 

        /// <summary>
        /// The type of search on the products list
        /// </summary>
        public ProductSearchType ProductSearchType
        {
            get { return mProductSearchType; }
            set
            {
                mProductSearchType = value;
                if (SearchText == "")
                    SearchTag = "Write the product " + mProductSearchType.ToString();
                else
                    searchHandler.Invoke();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the <see cref="ProductRowViewerViewModel"/> class
        /// </summary>
        public ProductRowViewerListViewModel()
        {
            this.ProductSearchType = ProductSearchType.ID;

            var list = Product.GetAllProducts()?.ConvertAll(
                    (product) => ConvertToProductRowViewer(product));

            if (list != null)
                AllItems = new ObservableCollection<BaseRowViewerViewModel>(list);
            else
                AllItems = new ObservableCollection<BaseRowViewerViewModel>();

            Items = new ObservableCollection<BaseRowViewerViewModel>();

            Fill_List();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Searches in the products list
        /// </summary>
        /// <param name="type">The search type</param>
        /// <param name="searchText">The text to search about it</param>
        protected override ObservableCollection<BaseRowViewerViewModel> Search()
        {
            var foundedItems = new ObservableCollection<BaseRowViewerViewModel>();
            for (int i = 0; i < AllItems.Count; i++)
            {
                switch (ProductSearchType)
                {
                    case ProductSearchType.ID:
                        if (((ProductRowViewerViewModel)AllItems[i]).ID.ToString().ToLower().StartsWith(SearchText.ToLower()))
                            foundedItems.Add(AllItems[i]);
                        break;
                    case ProductSearchType.Name:
                        if (((ProductRowViewerViewModel)AllItems[i]).Name.ToString().ToLower().StartsWith(SearchText.ToLower()))
                            foundedItems.Add(AllItems[i]);
                        break;
                    case ProductSearchType.Category:
                        if (((ProductRowViewerViewModel)AllItems[i]).Category.Name.ToString().ToLower().StartsWith(SearchText.ToLower()))
                            foundedItems.Add(AllItems[i]);
                        break;
                    default:
                        break;
                }
            }
            return foundedItems;
        }

        /// <summary>
        /// Matches the passed view model with the text in the searchBox depending on
        /// the type of search
        /// </summary>
        /// <param name="viewModel">The view model to match with</param>
        protected override bool IsMatch(BaseRowViewerViewModel viewModel)
        {
            switch (ProductSearchType)
            {
                case ProductSearchType.ID:
                    if (((ProductRowViewerViewModel)viewModel).ID.ToString().ToLower().StartsWith(SearchText))
                        return true;
                    break;
                case ProductSearchType.Name:
                    if (((ProductRowViewerViewModel)viewModel).Name.ToString().ToLower().StartsWith(SearchText))
                        return true;
                    break;
                case ProductSearchType.Category:
                    if (((ProductRowViewerViewModel)viewModel).Category.Name.ToString().ToLower().StartsWith(SearchText))
                        return true;
                    break;
                default:
                    break;
            }
            return false;
        }

        /// <summary>
        /// Deletes the specified item from the list
        /// </summary>
        /// <param name="viewModel">The view model of the item to delete</param>
        protected override void DeleteItem(BaseRowViewerViewModel viewModel)
        {
            // Delete from the items list
            Items.Remove(viewModel);

            // Delete from the database
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Product_ID", SqlDbType.VarChar);
            sqlParameters[0].Value = ((ProductRowViewerViewModel)viewModel).ID.ToString();

            DataConnection.ExcuteCommand("DeleteProduct", sqlParameters);

            OrderRowViewerListViewModel.Instance.RemoveFromCart((ProductRowViewerViewModel)viewModel);
        }

        /// <summary>
        /// Edits the specified item in the list
        /// </summary>
        /// <param name="productRowViewerViewmodel">The view model of the item to edit</param>
        protected override void EditItem(BaseRowViewerViewModel viewModel)
        {
            var productRowViewerViewModel = viewModel as ProductRowViewerViewModel;

            Product product = new Product(
                productRowViewerViewModel.ID,
                productRowViewerViewModel.Name,
                productRowViewerViewModel.Description,
                productRowViewerViewModel.StoredQuantity,
                productRowViewerViewModel.Price,
                productRowViewerViewModel.Picture,
                productRowViewerViewModel.Category.ID);

            EditProductWindowViewModel editProductWindowViewModel
                = new EditProductWindowViewModel(product);
            UI_Manager ui_Manager = new UI_Manager();
            ui_Manager.ShowDialog(editProductWindowViewModel);

            productRowViewerViewModel.ID = editProductWindowViewModel.NewProductData.ID;
            productRowViewerViewModel.Name = editProductWindowViewModel.NewProductData.Name;
            productRowViewerViewModel.Description = editProductWindowViewModel.NewProductData.Description;
            productRowViewerViewModel.StoredQuantity = editProductWindowViewModel.NewProductData.QuantityInStock;
            productRowViewerViewModel.Price = editProductWindowViewModel.NewProductData.Price;
            productRowViewerViewModel.Picture = editProductWindowViewModel.NewProductData.Image;
            productRowViewerViewModel.Category = editProductWindowViewModel.NewProductData.Category;
            productRowViewerViewModel.Update();
        }

        /// <summary>
        /// Prints the specified item from the list
        /// </summary>
        /// <param name="viewModel">The view model of the item to print</param>
        protected override void PrintItem(BaseRowViewerViewModel viewModel)
        {
            var productRowViewerViewmodel = viewModel as ProductRowViewerViewModel;

            ProductReportingWindowViewModel productReportingWindowViewModel 
                = new ProductReportingWindowViewModel(productRowViewerViewmodel.ID);
            UI_Manager ui_Manager = new UI_Manager();
            ui_Manager.ShowDialog(productReportingWindowViewModel);
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Converting the <see cref="Product"/> object 
        /// to <see cref="ProductRowViewer"/> object using ProductRowViewerViewModel
        /// </summary>
        /// <param name="product">The product to convert</param>
        private ProductRowViewerViewModel ConvertToProductRowViewer(Product product)
        {
            var viewModel = new ProductRowViewerViewModel
            {
                ID = product.ID,
                Name = product.Name,
                Category = product.Category,
                StoredQuantity = product.QuantityInStock,
                Price = product.Price,
                Description = product.Description,
                Picture = product.Image
            };

            viewModel.Deleted += DeleteItem;
            viewModel.Edited += EditItem;
            viewModel.Printed += PrintItem;

            return viewModel;
        }

        #endregion
    }
}

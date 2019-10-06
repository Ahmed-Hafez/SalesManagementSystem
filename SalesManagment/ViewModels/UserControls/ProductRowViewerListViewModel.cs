using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace SalesManagment
{
    public class ProductRowViewerListViewModel : BaseRowViewerListViewModel
    {
        //
        // TODO: There is a lot of work here for searching, Searching is so slow because of rendering
        //

        /// <summary>
        /// The type of search on the products in the list
        /// </summary>
        private ProductSearchType mProductSearchType = ProductSearchType.Name;

        #region Public Properties 

        /// <summary>
        /// The container of the product row viewer items to show
        /// </summary>
        public override ObservableCollection<BaseRowViewerViewModel> Items { get; set; }

        /// <summary>
        /// The container of all product row viewer items for all products
        /// </summary>
        public override ObservableCollection<BaseRowViewerViewModel> AllProducts { get; set; }

        /// <summary>
        /// The type of search on the products in the list
        /// </summary>
        public override ProductSearchType ProductSearchType
        {
            get { return mProductSearchType; }
            set
            {
                mProductSearchType = value;
                if (SearchText == "")
                    SearchTag = "Write the product " + mProductSearchType.ToString();
                else
                    Search(this.ProductSearchType, mSearchText);
            }
        }

        /// <summary>
        /// The search tag of the search box
        /// </summary>
        public override string SearchTag { get; set; }

        /// <summary>
        /// The text in the search box
        /// </summary>
        public override string SearchText
        {
            get
            {
                if (mSearchText == "")
                    Items = AllProducts;
                return mSearchText;
            }
            set
            {
                mSearchText = value;
                if (mSearchText != "")
                {
                    Search(this.ProductSearchType, mSearchText);
                }
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

            //SearchList = new ObservableCollection<ProductRowViewerViewModel>();

            var list = Product.GetAllProducts()?.ConvertAll(
                    (product) => ConvertToProductRowViewer(product));

            if (list != null)
                AllProducts = new ObservableCollection<BaseRowViewerViewModel>(list);
            else
                AllProducts = new ObservableCollection<BaseRowViewerViewModel>();

            Items = new ObservableCollection<BaseRowViewerViewModel>();

            while (Items.Count != AllProducts.Count)
                Items.Add(AllProducts[Items.Count]);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Searches in the products list
        /// </summary>
        /// <param name="type">The search type</param>
        /// <param name="searchText">The text to search about it</param>
        protected override void Search(ProductSearchType type, string searchText)
        {
            Items = new ObservableCollection<BaseRowViewerViewModel>();
            for (int i = 0; i < AllProducts.Count; i++)
            {
                switch (type)
                {
                    case ProductSearchType.ID:
                        if (((ProductRowViewerViewModel)AllProducts[i]).ID.ToString().ToLower().StartsWith(searchText.ToLower()))
                            Items.Add(AllProducts[i]);
                        break;
                    case ProductSearchType.Name:
                        if (((ProductRowViewerViewModel)AllProducts[i]).Name.ToString().ToLower().StartsWith(searchText.ToLower()))
                            Items.Add(AllProducts[i]);
                        break;
                    case ProductSearchType.Category:
                        if (((ProductRowViewerViewModel)AllProducts[i]).Category.Name.ToString().ToLower().StartsWith(searchText.ToLower()))
                            Items.Add(AllProducts[i]);
                        break;
                    default:
                        break;
                }
            }
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
        }

        /// <summary>
        /// Edits the specified item in the list
        /// </summary>
        /// <param name="productRowViewerViewmodel">The view model of the item to edit</param>
        protected override void EditItem(BaseRowViewerViewModel viewmodel)
        {
            var productRowViewerViewmodel = viewmodel as ProductRowViewerViewModel;

            Product product = new Product(
                productRowViewerViewmodel.ID,
                productRowViewerViewmodel.Name,
                productRowViewerViewmodel.Description,
                productRowViewerViewmodel.StoredQuantity,
                productRowViewerViewmodel.Price,
                productRowViewerViewmodel.Picture,
                productRowViewerViewmodel.Category.ID);

            EditProductWindowViewModel editProductWindowViewModel
                = new EditProductWindowViewModel(product);
            UI_Manager ui_Manager = new UI_Manager();
            ui_Manager.ShowDialog(editProductWindowViewModel);

            productRowViewerViewmodel.ID = editProductWindowViewModel.NewProductData.ID;
            productRowViewerViewmodel.Name = editProductWindowViewModel.NewProductData.Name;
            productRowViewerViewmodel.Description = editProductWindowViewModel.NewProductData.Description;
            productRowViewerViewmodel.StoredQuantity = editProductWindowViewModel.NewProductData.QuantityInStock;
            productRowViewerViewmodel.Price = editProductWindowViewModel.NewProductData.Price;
            productRowViewerViewmodel.Picture = editProductWindowViewModel.NewProductData.Image;
            productRowViewerViewmodel.Category = editProductWindowViewModel.NewProductData.Category;
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Converting the <see cref="Product"/> object 
        /// to <see cref="ProductRowViewer"/> object
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

            return viewModel;
        }

        #endregion
    }
}

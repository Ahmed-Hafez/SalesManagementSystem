using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace SalesManagment
{
    public class ProductRowViewerListViewModel : BaseViewModel, Observer
    {
        //
        // TODO: There is a lot of work here for searching, Searching is so slow because of rendering
        //

        /// <summary>
        /// The type of search on the products in the list
        /// </summary>
        private ProductSearchType mProductSearchType = ProductSearchType.Name;

        /// <summary>
        /// The text in the search box
        /// </summary>
        private string mSearchText = "";

        #region Public Properties 

        /// <summary>
        /// The container of the product row viewer items to show
        /// </summary>
        public ObservableCollection<ProductRowViewerViewModel> Items { get; set; }

        /// <summary>
        /// The container of all product row viewer items for all products
        /// </summary>
        public ObservableCollection<ProductRowViewerViewModel> AllProducts { get; set; }

        /// <summary>
        /// The container of the product row viewer items which the user searches about
        /// </summary>
        public ObservableCollection<ProductRowViewerViewModel> SearchList { get; set; }

        /// <summary>
        /// The type of search on the products in the list
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
                    Task.Run(() => context.Post((obj) => Search(this.ProductSearchType, mSearchText), null));
            }
        }

        /// <summary>
        /// The search tag of the search box
        /// </summary>
        public string SearchTag { get; set; }

        /// <summary>
        /// The text in the search box
        /// </summary>
        public string SearchText
        {
            get
            {
                if (mSearchText == "")
                    Task.Run(() => Items = AllProducts);
                return mSearchText;
            }
            set
            {
                mSearchText = value;
                if (mSearchText != "")
                    Task.Run(() => context.Post((obj) => Search(this.ProductSearchType, mSearchText), null));
            }
        }

        #endregion

        #region Constructor

        SynchronizationContext context;

        /// <summary>
        /// Initializes a new instance from the <see cref="ProductRowViewerViewModel"/> class
        /// </summary>
        public ProductRowViewerListViewModel()
        {
            context = SynchronizationContext.Current;

            this.ProductSearchType = ProductSearchType.ID;

            SearchList = new ObservableCollection<ProductRowViewerViewModel>();

            var list = Product.GetAllProducts()?.ConvertAll(
                    (product) => ConvertToProductRowViewer(product));

            if (list != null)
                AllProducts = new ObservableCollection<ProductRowViewerViewModel>(list);
            else
                AllProducts = new ObservableCollection<ProductRowViewerViewModel>();

            Items = AllProducts;
        }

        #endregion

        #region Methods
        private bool NewSearch = false;
        readonly object hh = new object();
        /// <summary>
        /// Searches in the products list
        /// </summary>
        /// <param name="type">The search type</param>
        /// <param name="searchText">The text to search about it</param>
        private void Search(ProductSearchType type, string searchText)
        {
            lock (hh)
            {
                SearchList.Clear();
                for (int i = 0; i < AllProducts.Count && !NewSearch; i++)
                {
                    switch (type)
                    {
                        case ProductSearchType.ID:
                            if (AllProducts[i].ID.ToString().ToLower().StartsWith(searchText.ToLower()))
                                SearchList.Add(AllProducts[i]);
                            break;
                        case ProductSearchType.Name:
                            if (AllProducts[i].Name.ToString().ToLower().StartsWith(searchText.ToLower()))
                                SearchList.Add(AllProducts[i]);
                            break;
                        case ProductSearchType.Category:
                            if (AllProducts[i].Category.Name.ToString().ToLower().StartsWith(searchText.ToLower()))
                                SearchList.Add(AllProducts[i]);
                            break;
                        default:
                            break;
                    }

                }
            }
            Items = SearchList;
        }

        /// <summary>
        /// Deletes the specified item from the list
        /// </summary>
        /// <param name="viewModel">The view model of the item to delete</param>
        private void DeleteItem(ProductRowViewerViewModel viewModel)
        {
            // Delete from the items list
            Items.Remove(viewModel);

            // Delete from the database
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Product_ID", SqlDbType.VarChar);
            sqlParameters[0].Value = viewModel.ID.ToString();

            DataConnection.ExcuteCommand("DeleteProduct", sqlParameters);
        }

        /// <summary>
        /// Edits the specified item in the list
        /// </summary>
        /// <param name="viewModel">The view model of the item to edit</param>
        private void EditItem(ProductRowViewerViewModel viewModel)
        {
            Product product = new Product(
                viewModel.ID,
                viewModel.Name,
                viewModel.Description,
                viewModel.StoredQuantity,
                viewModel.Price,
                viewModel.Picture,
                viewModel.Category.ID);

            EditProductWindowViewModel editProductWindowViewModel
                = new EditProductWindowViewModel(product);
            UI_Manager ui_Manager = new UI_Manager();
            ui_Manager.ShowDialog(editProductWindowViewModel);

            viewModel.ID = editProductWindowViewModel.NewProductData.ID;
            viewModel.Name = editProductWindowViewModel.NewProductData.Name;
            viewModel.Description = editProductWindowViewModel.NewProductData.Description;
            viewModel.StoredQuantity = editProductWindowViewModel.NewProductData.QuantityInStock;
            viewModel.Price = editProductWindowViewModel.NewProductData.Price;
            viewModel.Picture = editProductWindowViewModel.NewProductData.Image;
            viewModel.Category = editProductWindowViewModel.NewProductData.Category;
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

        #region Observer Pattern

        public void Update(params object[] parameters)
        {
            var viewModel = (ProductRowViewerViewModel)parameters[0];
            viewModel.Deleted += DeleteItem;
            viewModel.Edited += EditItem;
            Items.Add(viewModel);
        }

        #endregion
    }
}

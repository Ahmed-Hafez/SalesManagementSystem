using System.Collections.ObjectModel;

namespace SalesManagment
{
    public abstract class BaseRowViewerListViewModel : BaseViewModel, Observer
    {
        #region Private Members

        /// <summary>
        /// The text in the search box
        /// </summary>
        protected string mSearchText = "";

        #endregion

        #region Public Properties

        /// <summary>
        /// The container of the product row viewer items to show
        /// </summary>
        public abstract ObservableCollection<BaseRowViewerViewModel> Items { get; set; }

        /// <summary>
        /// The container of all product row viewer items for all products
        /// </summary>
        public abstract ObservableCollection<BaseRowViewerViewModel> AllProducts { get; set; }

        /// <summary>
        /// The type of search on the products in the list
        /// </summary>
        public abstract ProductSearchType ProductSearchType { get; set; }

        /// <summary>
        /// The search tag of the search box
        /// </summary>
        public abstract string SearchTag { get; set; }

        /// <summary>
        /// The text in the search box
        /// </summary>
        public abstract string SearchText { get; set; }


        #endregion

        /// <summary>
        /// Searches in the products list
        /// </summary>
        /// <param name="type">The search type</param>
        /// <param name="searchText">The text to search about it</param>
        protected abstract void Search(ProductSearchType type, string searchText);

        /// <summary>
        /// Edits the specified item in the list
        /// </summary>
        /// <param name="viewModel">The view model of the item to edit</param>
        protected abstract void EditItem(BaseRowViewerViewModel viewModel);

        /// <summary>
        /// Deletes the specified item from the list
        /// </summary>
        /// <param name="viewModel">The view model of the item to delete</param>
        protected abstract void DeleteItem(BaseRowViewerViewModel viewModel);

        public void Update<T>(params object[] parameters) 
            where T : BaseRowViewerViewModel
        {
            var viewModel = (T)parameters[0];
            viewModel.Deleted += DeleteItem;
            viewModel.Edited += EditItem;
            Items.Add(viewModel);
        }
    }
}

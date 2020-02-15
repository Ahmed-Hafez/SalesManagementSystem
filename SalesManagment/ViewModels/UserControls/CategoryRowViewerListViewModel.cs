using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SalesManagment
{
    public class CategoryRowViewerListViewModel : BaseRowViewerListViewModel
    {
        #region Private Members

        /// <summary>
        /// The type of search on the categories list
        /// </summary>
        private CategorySearchType mCategorySearchType = CategorySearchType.Name;

        #endregion

        #region Public Properties 

        /// <summary>
        /// The type of search on the categories list
        /// </summary>
        public CategorySearchType CategorySearchType
        {
            get { return mCategorySearchType; }
            set
            {
                mCategorySearchType = value;
                if (SearchText == "")
                    SearchTag = "Write the category " + mCategorySearchType.ToString();
                else
                    searchHandler.Invoke();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the <see cref="CategoryRowViewerListViewModel"/> class
        /// </summary>
        public CategoryRowViewerListViewModel()
        {
            this.CategorySearchType = CategorySearchType.ID;

            var list = Category.GetAllCategories()?.ConvertAll(
                    (category) => ConvertToCategoryRowViewer(category));

            if (list != null)
                AllItems = new ObservableCollection<BaseRowViewerViewModel>(list);
            else
                AllItems = new ObservableCollection<BaseRowViewerViewModel>();

            Items = new ObservableCollection<BaseRowViewerViewModel>();

            LoadAnimationDuration = 50;

            Fill_List();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Searches in the categories list
        /// </summary>
        /// <param name="type">The search type</param>
        /// <param name="searchText">The text to search about it</param>
        protected override ObservableCollection<BaseRowViewerViewModel> Search()
        {
            var foundedItems = new ObservableCollection<BaseRowViewerViewModel>();
            for (int i = 0; i < AllItems.Count; i++)
            {
                switch (CategorySearchType)
                {
                    case CategorySearchType.ID:
                        if (((CategoryRowViewerViewModel)AllItems[i]).ID.ToString().ToLower().StartsWith(SearchText.ToLower()))
                            foundedItems.Add(AllItems[i]);
                        break;
                    case CategorySearchType.Name:
                        if (((CategoryRowViewerViewModel)AllItems[i]).Name.ToString().ToLower().StartsWith(SearchText.ToLower()))
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
            switch (CategorySearchType)
            {
                case CategorySearchType.ID:
                    if (((CategoryRowViewerViewModel)viewModel).ID.ToString().ToLower().StartsWith(SearchText))
                        return true;
                    break;
                case CategorySearchType.Name:
                    if (((CategoryRowViewerViewModel)viewModel).Name.ToString().ToLower().StartsWith(SearchText))
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
            sqlParameters[0] = new SqlParameter("@Category_ID", SqlDbType.Int);
            sqlParameters[0].Value = ((CategoryRowViewerViewModel)viewModel).ID;

            DataConnection.ExcuteCommand("Delete_Category_Procedure", sqlParameters);

            ApplicationDirector.UpdateCategories();
        }

        protected override void EditItem(BaseRowViewerViewModel viewModel)
        {
            var categoryRowViewerViewModel = viewModel as CategoryRowViewerViewModel;

            if (categoryRowViewerViewModel.IsEditable)
            {
                // Validate
                if(string.IsNullOrEmpty(categoryRowViewerViewModel.EditedName) ||
                   string.IsNullOrWhiteSpace(categoryRowViewerViewModel.EditedName))
                {
                    MessageBox.Show("Category must have a name", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Edit
                categoryRowViewerViewModel.Name = categoryRowViewerViewModel.EditedName;
                Category category = new Category(categoryRowViewerViewModel.ID, categoryRowViewerViewModel.Name);
                categoryRowViewerViewModel.IsEditable = false;
                category.Edit();

                ApplicationDirector.UpdateCategories();
            }
            else
            {
                categoryRowViewerViewModel.IsEditable = true;
            }
        }

        protected override void PrintItem(BaseRowViewerViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        protected void CancelEditing(BaseRowViewerViewModel viewModel)
        {
            var categoryRowViewerViewModel = viewModel as CategoryRowViewerViewModel;

            categoryRowViewerViewModel.IsEditable = false;
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Converting the <see cref="Category"/> object 
        /// to <see cref="CategoryRowViewer"/> object using <see cref="CategoryRowViewerViewModel"/>
        /// </summary>
        /// <param name="category">The category to convert</param>
        private CategoryRowViewerViewModel ConvertToCategoryRowViewer(Category category)
        {
            var viewModel = new CategoryRowViewerViewModel
            {
                ID = category.ID,
                Name = category.Name
            };

            viewModel.Deleted += DeleteItem;
            viewModel.Edited += EditItem;
            viewModel.Cancel += CancelEditing;

            return viewModel;
        }

        #endregion

        #region Observer Pattern Methods

        public new void Update<T>(params object[] parameters)
            where T : CategoryRowViewerViewModel
        {
            var viewModel = parameters[0] as T;
            viewModel.Deleted += DeleteItem;
            viewModel.Edited += EditItem;
            viewModel.Cancel += CancelEditing;

            Items.Add(viewModel);
            AllItems.Add(viewModel);
        }

        #endregion

    }
}

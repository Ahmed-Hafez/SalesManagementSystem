using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace SalesManagment
{
    public abstract class BaseRowViewerListViewModel : BaseViewModel, IObserver<BaseRowViewerViewModel>
    {
        #region Delegates

        /// <summary>
        /// Handles the search operation
        /// </summary>
        protected SearchHandler searchHandler;

        #endregion

        #region Private Members

        /// <summary>
        /// The text in the search box
        /// </summary>
        protected string mSearchText = "";

        /// <summary>
        /// The used thread for searching
        /// </summary>
        protected Thread SearcherThread;

        /// <summary>
        /// This list was used for coping the items of the (Items) list in the time in
        /// which filling the (Items) list, This was made to enumerate the (Items) list
        /// without making any exception when removing items from it
        /// </summary>
        private ObservableCollection<BaseRowViewerViewModel> mCopiedList;

        #endregion

        #region Public Properties

        /// <summary>
        /// The container of the row viewer items to show
        /// </summary>
        public virtual ObservableCollection<BaseRowViewerViewModel> Items { get; set; }

        /// <summary>
        /// The container of all row viewer items for all products
        /// </summary>
        public virtual ObservableCollection<BaseRowViewerViewModel> AllItems { get; set; }

        /// <summary>
        /// The search tag of the search box
        /// </summary>
        public virtual string SearchTag { get; set; }

        /// <summary>
        /// The text in the search box
        /// </summary>
        public virtual string SearchText
        {
            get => mSearchText;
            set
            {
                if (string.IsNullOrEmpty(mSearchText) || string.IsNullOrEmpty(value) || value.StartsWith(mSearchText))
                {
                    mSearchText = value;
                    SearchForward();
                }
                else if (value.StartsWith(mSearchText) || mSearchText.StartsWith(value))
                {
                    mSearchText = value;
                    SearchBack();
                }
                else
                {
                    // TODO: Set error code
                    throw new Exception("Unhandled error. Code: BRVLVM77");
                }
            }
        }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The duration of the row viewer loading animation
        /// </summary>
        protected int LoadAnimationDuration { get; set; } = 300;

        #region Protected Events

        /// <summary>
        /// Fire when searching is finished
        /// </summary>
        protected event Action SearchFinished;

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize a new instance from the <see cref="BaseRowViewerListViewModel"/> class.
        /// </summary>
        public BaseRowViewerListViewModel()
        {
            SearcherThread = new Thread(() => { });
            searchHandler = new SearchHandler(SearchForward);
            mCopiedList = new ObservableCollection<BaseRowViewerViewModel>();
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Finalize the life of the <see cref="BaseRowViewerListViewModel"/> object.
        /// </summary>
        ~BaseRowViewerListViewModel()
        {
            // Killing the thread if it's still alive
            if (SearcherThread.IsAlive)
            {
                SearcherThread.IsBackground = true;
                SearcherThread.Abort();
            }
        }

        #endregion

        #region Methods

        #region Abstract Methods

        /// <summary>
        /// Searches in the products list
        /// </summary>
        protected abstract ObservableCollection<BaseRowViewerViewModel> Search();

        /// <summary>
        /// Matches the passed view model with the text in the searchBox depending on
        /// the type of search
        /// </summary>
        /// <param name="viewModel">The view model to match with</param>
        protected abstract bool IsMatch(BaseRowViewerViewModel viewModel);

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

        /// <summary>
        /// Prints the specified item in the list
        /// </summary>
        /// <param name="viewModel">The view model of the item to print</param>
        protected abstract void PrintItem(BaseRowViewerViewModel viewModel);

        #endregion

        #region Protected Virtual Methods

        /// <summary>
        /// Invoking 
        /// </summary>
        protected virtual void Fill_List()
        {
            Action AddingAction = new Action(() =>
            {
                // TODO: Comment this section
                try
                {
                    Items.Add(AllItems[Items.Count]);

                }
                catch (Exception)
                {

                }
            });

            SearcherThread = new Thread(() =>
            {
                while (Items.Count != AllItems.Count)
                {
                    ApplicationDirector.MainThread.BeginInvoke(AddingAction);
                    Thread.Sleep(LoadAnimationDuration);
                }
            });
            SearcherThread.Start();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Searches in the row viewers list when writing the string to search for
        /// </summary>
        private void SearchForward()
        {
            // If the searching process is working, kill it and start a new search
            if (SearcherThread.IsAlive) SearcherThread.Abort();

            // Initializes the collections to use them
            Action initailizerAction = new Action(() =>
            {
                Items = new ObservableCollection<BaseRowViewerViewModel>();
                mCopiedList = new ObservableCollection<BaseRowViewerViewModel>();
            });

            // Adding the matched items to the list
            Action<BaseRowViewerViewModel> addingAction = new Action<BaseRowViewerViewModel>((item) =>
            {
                Items.Add(item);
                mCopiedList.Add(item);
            });

            // Start searching in another thread
            SearcherThread = new Thread(() =>
            {
                // The used Method to add an item to the list
                Action<BaseRowViewerViewModel> addingMethod =
                delegate (BaseRowViewerViewModel item)
                {
                    ApplicationDirector.MainThread.BeginInvoke(addingAction, item);
                    Thread.Sleep(LoadAnimationDuration);
                };

                // Initializing the containers (Items and mCopiedList)
                ApplicationDirector.MainThread.BeginInvoke(initailizerAction);

                // Adding the items to the containers
                if (SearchText != "" || AllItems == null)
                    foreach (var item in Search())
                        addingMethod(item);
                else if (AllItems.Count != 0)
                    foreach (var item in AllItems)
                        addingMethod(item);

                SearchFinished?.Invoke();
            });
            SearcherThread.Start();
        }

        /// <summary>
        /// Searches in the row viewers list when removing character from the search text
        /// </summary>
        private void SearchBack()
        {
            // If the searching process is working, kill it and start a new search
            if (SearcherThread.IsAlive) SearcherThread.Abort();

            // Adding the matched items to the list
            Action<BaseRowViewerViewModel> AddingAction = new Action<BaseRowViewerViewModel>((item) =>
            {
                if (!Items.Contains(item))
                {
                    Items.Add(item);
                    mCopiedList.Add(item);
                }
            });

            // Removes the items that don't match the search text
            Action<BaseRowViewerViewModel> RemovingAction = new Action<BaseRowViewerViewModel>((item) =>
            {
                if (!IsMatch(item))
                    Items.Remove(item);
            });

            // Start searching in another thread
            SearcherThread = new Thread(() =>
            {
                // Removing items
                foreach (var item in mCopiedList)
                    ApplicationDirector.MainThread.BeginInvoke(RemovingAction, item);

                // Adding items
                foreach (var item in Search())
                {
                    ApplicationDirector.MainThread.BeginInvoke(AddingAction, item);
                    Thread.Sleep(LoadAnimationDuration);
                };
                SearchFinished?.Invoke();
            });
            SearcherThread.Start();
        }

        #endregion

        #region Observer Pattern Methods

        public void Update<T>(params object[] parameters)
            where T : BaseRowViewerViewModel
        {
            var viewModel = parameters[0] as T;
            viewModel.Deleted += DeleteItem;
            viewModel.Edited += EditItem;
            viewModel.Printed += PrintItem;
            Items.Add(viewModel);
            AllItems.Add(viewModel);
        }

        #endregion

        #endregion
    }
}

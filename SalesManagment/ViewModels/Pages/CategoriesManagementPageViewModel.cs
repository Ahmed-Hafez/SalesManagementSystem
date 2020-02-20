using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace SalesManagment
{
    public class CategoriesManagementPageViewModel : BasePageViewModel, ISubject
    {
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
        public Thickness BorderFrameMargin { get { return new Thickness(0, 0, 0, 20); } }

        /// <summary>
        /// The padding of the frame which contains the content of the page
        /// </summary>
        public Thickness BorderFramePadding { get { return new Thickness(0); } }

        #endregion

        #endregion

        #region Commands

        /// <summary>
        /// The command related to add a new category to the database
        /// </summary>
        public ICommand AddCategoryCommand { get; set; }

        /// <summary>
        /// The command related to cancel adding categories to the database
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #endregion

        #region Category Data

        /// <summary>
        /// The ID of the new category
        /// </summary>
        public long? Category_ID { get; set; }

        /// <summary>
        /// The name of the new category
        /// </summary>
        public string CategoryName { get; set; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize an instance from the <see cref="CategoriesManagementPageViewModel"/> class
        /// </summary>
        public CategoriesManagementPageViewModel()
        {
            this.LoadAnimation = PageAnimation.SlideInFromRight;
            this.UnloadAnimation = PageAnimation.SlideOutToLeft;

            AddCategoryCommand = new RelayCommand(AddCategory);
            CancelCommand = new RelayCommand(CancelAddition);

            // Initializing the observers list
            Observers = new List<IObserver>();
        }

        /// <summary>
        /// Attempts to add a new category to the database
        /// </summary>
        private void AddCategory()
        {
            // Validate data
            if (Category_ID == 0L || Category_ID == null)
            {
                MessageBox.Show("Category ID shouldn't be zero", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(CategoryName) || string.IsNullOrWhiteSpace(CategoryName))
            {
                MessageBox.Show("Category must have a name", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Category category = new Category(Category_ID.Value, CategoryName);

            if (category.Add())
            {
                MessageBox.Show("Category was added", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                NotifyObservers();
                Category_ID = null;
                CategoryName = null;
            }
            else
                MessageBox.Show("There is already a category with the same ID", "Information", MessageBoxButton.OK, MessageBoxImage.Error);

            ApplicationDirector.UpdateCategories();
        }

        /// <summary>
        /// Cancel the category addition operation
        /// </summary>
        private void CancelAddition()
        {
            Category_ID = null;
            CategoryName = null;
        }

        #endregion

        #region Observer Pattern

        /// <summary>
        /// Observers which this subject provide data to them
        /// </summary>
        private List<IObserver> Observers;

        public void RegisterObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            if (Observers.Contains(observer))
                Observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            Observers.ForEach((observer) => observer.Update<CategoryRowViewerViewModel>(
                new CategoryRowViewerViewModel
                {
                    ID = Category_ID.GetValueOrDefault(),
                    Name = CategoryName
                })
            );
        }

        #endregion
    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace SalesManagment
{
    public class ProductRowViewerListDesignModel : ProductRowViewerListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ProductRowViewerListDesignModel Instance { get { return new ProductRowViewerListDesignModel(); } }

        #endregion

        #region Contructor

        /// <summary>
        /// Initializes a new instance from <see cref="ProductRowViewerListDesignModel"/> class
        /// </summary>
        public ProductRowViewerListDesignModel()
        {
            Items = new ObservableCollection<BaseRowViewerViewModel>
            {
                new ProductRowViewerViewModel
                {
                    ID = 4444,
                    Name = "Samsung Galaxy A10",
                    StoredQuantity = 15,
                    Price = 2000,
                    Category = new Category(231, "Phones"),
                    Description = "This is an awesome android mobile \nIt have a 16GB RAM",
                    Picture = 
                    (byte[])new ImagePathToImageByteArrayValueConverter().Convert(
                        @"F:\GitHubProjects\SalesManagementSystem\SalesManagment\SalesManagementSystem\SalesManagment\Images\samsunga10.jpg",
                        null, null, null)
                },
                new ProductRowViewerViewModel
                {
                    ID = 3659,
                    Name = "GC-B22FTLPL",
                    StoredQuantity = 6,
                    Price = 12000,
                    Category = new Category(231, "Fridges"),
                    Description = "Slim Width for a Slim fit\nFit your French door fridge without renovating your fridge alcove." +
                    " The new 830mm wide Slim French door fridge is designed to fit alcoves 850mm in width. Provide that seamless" +
                    " premium look to your kitchen with the new Slim French door fridge, while allowing 10mm on either side for venting.",
                    Picture = 
                    (byte[])new ImagePathToImageByteArrayValueConverter().Convert(
                        @"F:\GitHubProjects\SalesManagementSystem\SalesManagment\SalesManagementSystem\SalesManagment\Images\Fridge.jpg",
                        null, null, null)
                },
                new ProductRowViewerViewModel
                {
                    ID = 8888,
                    Name = "Apple PC",
                    StoredQuantity = 10,
                    Price = 150000,
                    Category = new Category(231, "Computers"),
                    Description = "This is an awesome PC \nIt have an amazing features",
                    Picture =
                    (byte[])new ImagePathToImageByteArrayValueConverter().Convert(
                        @"F:\GitHubProjects\SalesManagementSystem\SalesManagment\SalesManagementSystem\SalesManagment\Images\Computer.jpg",
                        null, null, null)
                },
                new ProductRowViewerViewModel
                {
                    ID = 1423899,
                    Name = "Modern Graphics programming primer",
                    StoredQuantity = 78,
                    Price = 137.16m,
                    Category = new Category(231, "Books"),
                    Description = "Very wonderful book",
                    Picture = 
                    (byte[])new ImagePathToImageByteArrayValueConverter().Convert(
                        @"F:\GitHubProjects\SalesManagementSystem\SalesManagment\SalesManagementSystem\SalesManagment\Images\Book.jpg",
                        null, null, null)
                }
            };
        }

        #endregion
    }
}

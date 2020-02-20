using System.Collections.ObjectModel;

namespace SalesManagment
{
    public class ClientRowViewerListDesignModel : ClientRowViewerListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ClientRowViewerListDesignModel Instance { get { return new ClientRowViewerListDesignModel(); } }

        #endregion

        #region Contructor

        /// <summary>
        /// Initializes a new instance from <see cref="ClientRowViewerListDesignModel"/> class
        /// </summary>
        public ClientRowViewerListDesignModel()
        {
            Items = new ObservableCollection<BaseRowViewerViewModel>
            {
                new ClientRowViewerDesignModel
                {
                    ID = 4444,
                    FirstName = "Ahmed",
                    SecondName = "Hafez",
                    Gender = GenderType.Male,
                    Phone = "01152119357",
                    Email = "Ahmed4190@gmail.com",
                    Image = 
                    (byte[])new ImagePathToImageByteArrayValueConverter().Convert(
                        @"F:\GitHub Projects\SalesManagementSystem\SalesManagment\Images\Male.png",
                        null, null, null)
                }
            };
        }

        #endregion
    }
}

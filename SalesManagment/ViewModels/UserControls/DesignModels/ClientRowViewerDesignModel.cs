namespace SalesManagment
{
    public class ClientRowViewerDesignModel : ClientRowViewerViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ClientRowViewerDesignModel Instance { get { return new ClientRowViewerDesignModel(); } }

        #endregion

        #region Contructor

        /// <summary>
        /// Initializes a new instance from <see cref="ClientRowViewerDesignModel"/> class
        /// </summary>
        public ClientRowViewerDesignModel()
        {
            ID = 25156;
            FirstName = "Ahmed";
            SecondName = "Hafez";
            Gender = GenderType.Male;
            Phone = "01152119357";
            Email = "Ahmedhafez4190@gmail.com";
            Image =(byte[])new ImagePathToImageByteArrayValueConverter().Convert(
                    @"F:\GitHub Projects\SalesManagementSystem\SalesManagment\Images\Male.png", null, null, null);
        }

        #endregion
    }
}

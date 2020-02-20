using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows.Input;

namespace SalesManagment
{
    /// <summary>
    /// The view model of the <see cref="EditClientWindowViewModel"/> dialog window
    /// </summary>
    public class EditClientWindowViewModel : BaseWindowViewModel<EditClientWindowViewModel>
    {
        #region Private Members

        /// <summary>
        /// The binary representation of the client image
        /// </summary>
        private byte[] mClientImage;

        #endregion

        #region Public Properties

        /// <summary>
        /// The new data of the client
        /// </summary>
        public Client NewClientData { get; private set; }

        #region Client Data

        /// <summary>
        /// Client ID
        /// </summary>
        public int ClientID { get; set; }

        /// <summary>
        /// Client first name
        /// </summary>
        public string ClientFirstName { get; set; }

        /// <summary>
        /// Client second name
        /// </summary>
        public string ClientSecondName { get; set; }

        /// <summary>
        /// Client gender
        /// </summary>
        public GenderType ClientGender { get; set; }

        /// <summary>
        /// Client phone number
        /// </summary>
        public string ClientPhone { get; set; }

        /// <summary>
        /// Client email
        /// </summary>
        public string ClientEmail { get; set; }

        /// <summary>
        /// Client image
        /// </summary>
        public object ClientImage { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command related to select product photos to show
        /// </summary>
        public ICommand SelectPhotoCommand { get; set; }

        /// <summary>
        /// The command related to the Edit button
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// The command related to the Cancel button
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #endregion

        #endregion

        #region Contructor

        /// <summary>
        /// Initialize an instance from the <see cref="EditClientWindowViewModel"/> class
        /// </summary>
        /// <param name="client">The product to edit</param>
        public EditClientWindowViewModel(Client client)
        {
            NewClientData = client;

            ClientID = client.ID;
            ClientFirstName = client.FirstName;
            ClientSecondName = client.SecondName;
            ClientGender = client.Gender;
            ClientPhone = client.Phone;
            ClientEmail = client.Email;
            ClientImage = client.Image;
            mClientImage = client.Image;

            SelectPhotoCommand = new RelayCommand(SelectPhoto);
            EditCommand = new RelayCommand(EditClient);
            CancelCommand = new RelayCommand(CancelEditting);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adding photo from the pc into the image frame
        /// </summary>
        private void SelectPhoto()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = " |*.JPG; *.PNG; *.JPEG";
            if (openFileDialog.ShowDialog() == true)
            {
                var path = openFileDialog.FileName;
                // Storing the image for use
                mClientImage =
                    (byte[])new ImagePathToImageByteArrayValueConverter().Convert(path, null, null, null);

                ClientImage = path;
            }
        }

        /// <summary>
        /// Editting the client data
        /// </summary>
        private void EditClient()
        {
            Client client = new Client
                (
                ClientID,
                ClientFirstName.Trim(),
                ClientSecondName.Trim(),
                ClientGender,
                ClientPhone,
                ClientEmail,
                mClientImage
                );
            client.Edit();
            NewClientData = client;
            RelatedWindow.Close();
        }

        /// <summary>
        /// Cancel the editing action
        /// </summary>
        private void CancelEditting()
        {
            RelatedWindow.Close();
        }

        public override object WindowLoaded(params object[] parameters)
        {
            return null;
        }

        #endregion
    }
}

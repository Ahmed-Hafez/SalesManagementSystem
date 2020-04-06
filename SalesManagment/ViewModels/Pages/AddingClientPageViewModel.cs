using Microsoft.Win32;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace SalesManagment
{
    public class AddingClientPageViewModel : BasePageViewModel, ISubject<BaseRowViewerViewModel>
    {
        #region Private Members

        /// <summary>
        /// The binary representation of the client image
        /// </summary>
        private byte[] mClientImage;

        /// <summary>
        /// The binary representation of the client image
        /// </summary>
        private byte[] defaultClientImage;

        /// <summary>
        /// Default image path for male client
        /// </summary>
        private string defaultImagePath;

        /// <summary>
        /// Gender of the client
        /// </summary>
        private GenderType mClientGender;

        /// <summary>
        /// Determine if the user is already selected an image for the client or not
        /// </summary>
        private bool mIsImageUploaded = false;

        #endregion

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
        public Thickness BorderFrameMargin { get { return new Thickness(0, 0, 0, 80); } }

        /// <summary>
        /// The padding of the frame which contains the content of the page
        /// </summary>
        public Thickness BorderFramePadding { get { return new Thickness(20, 50, 20, 15); } }

        #endregion

        /// <summary>
        /// The padding between the frame and the content in the left
        /// </summary>
        public Thickness LeftContentPadding { get { return new Thickness(0, 5, 0, 0); } }

        #region Product Image

        #region Product Image Frame

        /// <summary>
        /// The thickness of the image frame
        /// </summary>
        public Thickness ProductImageFrameThickness { get; set; } = new Thickness(2);

        /// <summary>
        /// The height of the image frame
        /// </summary>
        public double ProductImageFrameHeight { get; set; } = 250;

        /// <summary>
        /// The width of the image frame
        /// </summary>
        public double ProductImageFrameWidth { get; set; } = 200;

        #endregion

        #endregion

        #endregion

        #region Commands

        /// <summary>
        /// The command related to select Client photos to show
        /// </summary>
        public ICommand SelectPhotoCommand { get; set; }

        /// <summary>
        /// The command related to add a new client to the database
        /// </summary>
        public ICommand AddClientCommand { get; set; }

        #endregion

        #region Client Data

        /// <summary>
        /// First name of the client
        /// </summary>
        public string ClientFirstName { get; set; }

        /// <summary>
        /// Second name of the client
        /// </summary>
        public string ClientSecondName { get; set; }

        /// <summary>
        /// Full name of the client
        /// </summary>
        public string ClientFullName { get => ClientFirstName + " " + ClientSecondName; }

        /// <summary>
        /// Gender of the client
        /// </summary>
        public GenderType ClientGender
        {
            get => mClientGender;
            set
            {
                mClientGender = value;
                if (!mIsImageUploaded)
                {
                    if (ClientGender == GenderType.Male)
                        ClientImagePath = @"..\..\Images\Male.png";
                    else
                        ClientImagePath = @"..\..\Images\Female.png";
                }
            }
        }

        /// <summary>
        /// Email of the client
        /// </summary>
        public string ClientEmail { get; set; }

        /// <summary>
        /// Phone of the client
        /// </summary>
        public string ClientPhone { get; set; }

        /// <summary>
        /// The path of the image on the PC
        /// </summary>
        public string ClientImagePath { get; set; }

        #endregion

        #endregion

        #region Contructor

        /// <summary>
        /// Initialize an instance from the <see cref="AddingClientPageViewModel"/> class
        /// </summary>
        public AddingClientPageViewModel()
        {
            defaultImagePath = @"..\..\Images\Male.png";
            ClientImagePath = defaultImagePath;
            ClientGender = GenderType.Male;
            SelectPhotoCommand = new RelayCommand(SelectPhoto);
            AddClientCommand = new RelayCommand(AddClient);

            // Storing the image for use
            defaultClientImage =
                (byte[])new ImagePathToImageByteArrayValueConverter().Convert(ClientImagePath, null, null, null);

            mClientImage = defaultClientImage;

            // Initializing the observers list
            Observers = new List<IObserver<BaseRowViewerViewModel>>();
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

                ClientImagePath = path;
                mIsImageUploaded = true;
            }
        }

        /// <summary>
        /// Attempts to add a new product to the database
        /// </summary>
        private void AddClient()
        {
            if (string.IsNullOrEmpty(ClientFirstName) || string.IsNullOrWhiteSpace(ClientFirstName))
            {
                MessageBox.Show("First name cann't be empty", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(ClientSecondName) || string.IsNullOrWhiteSpace(ClientSecondName))
            {
                MessageBox.Show("Second name cann't be empty", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ClientPhone == null || ClientPhone.Length < 11)
            {
                MessageBox.Show("Phone number must be 11 digits", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            #region Email Validation

            if (string.IsNullOrEmpty(ClientEmail) || string.IsNullOrWhiteSpace(ClientEmail))
            {
                MessageBox.Show("Email can't be empty", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                MailAddress address = new MailAddress(ClientEmail);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Email format isn't valid", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            #endregion

            Client client = new Client
                (
                ClientFirstName.Trim(),
                ClientSecondName.Trim(),
                ClientGender,
                ClientPhone,
                ClientEmail,
                mClientImage
                );
            if (client.Add())
            {
                MessageBox.Show("Client was added", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                NotifyObservers();
                ClientFirstName = null;
                ClientSecondName = null;
                ClientGender = GenderType.Male;
                ClientPhone = null;
                ClientEmail = null;
                ClientImagePath = defaultImagePath;
                mIsImageUploaded = false;
            }
            else
                MessageBox.Show("There is already a client with the same phone number or email", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region Observer Pattern

        /// <summary>
        /// Observers which this subject provide data to them
        /// </summary>
        private List<IObserver<BaseRowViewerViewModel>> Observers;

        public void RegisterObserver(IObserver<BaseRowViewerViewModel> observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver<BaseRowViewerViewModel> observer)
        {
            if (Observers.Contains(observer))
                Observers.Remove(observer);
        }

        public void NotifyObservers()
        {

            Observers.ForEach((observer) => observer.Update<ClientRowViewerViewModel>(
                new ClientRowViewerViewModel
                {
                    FirstName = ClientFirstName,
                    SecondName = ClientSecondName,
                    Gender = ClientGender,
                    Phone = ClientPhone,
                    Email = ClientEmail,
                    Image = mClientImage
                })
            );
        }

        #endregion
    }
}

using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace SalesManagment
{
    public class ClientRowViewerListViewModel : BaseRowViewerListViewModel
    {
        #region Private Members

        /// <summary>
        /// The type of search on the clients list
        /// </summary>
        private ClientSearchType mClientSearchType = ClientSearchType.Phone;

        #endregion

        #region Public Properties 

        /// <summary>
        /// The type of search on the clients list
        /// </summary>
        public ClientSearchType ClientSearchType
        {
            get { return mClientSearchType; }
            set
            {
                mClientSearchType = value;
                if (SearchText == "")
                    SearchTag = "Write the client " + mClientSearchType.ToString();
                else
                    searchHandler.Invoke();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the <see cref="ProductRowViewerViewModel"/> class
        /// </summary>
        public ClientRowViewerListViewModel()
        {
            this.ClientSearchType = ClientSearchType.Name;

            var list = Client.GetAllClients()?.ConvertAll(
                    (client) => ConvertToClientRowViewer(client));

            if (list != null)
                AllItems = new ObservableCollection<BaseRowViewerViewModel>(list);
            else
                AllItems = new ObservableCollection<BaseRowViewerViewModel>();

            Items = new ObservableCollection<BaseRowViewerViewModel>();

            Fill_List();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Searches in the clients list
        /// </summary>
        protected override ObservableCollection<BaseRowViewerViewModel> Search()
        {
            var foundedItems = new ObservableCollection<BaseRowViewerViewModel>();
            for (int i = 0; i < AllItems.Count; i++)
            {
                switch (ClientSearchType)
                {
                    case ClientSearchType.Name:
                        if (((ClientRowViewerViewModel)AllItems[i]).FullName.ToString().ToLower().StartsWith(SearchText.ToLower()))
                            foundedItems.Add(AllItems[i]);
                        break;
                    case ClientSearchType.gender:
                        if (((ClientRowViewerViewModel)AllItems[i]).Gender.ToString().ToLower().StartsWith(SearchText.ToLower()))
                            foundedItems.Add(AllItems[i]);
                        break;
                    case ClientSearchType.Phone:
                        if (((ClientRowViewerViewModel)AllItems[i]).Phone.ToString().ToLower().StartsWith(SearchText.ToLower()))
                            foundedItems.Add(AllItems[i]);
                        break;
                    case ClientSearchType.Email:
                        if (((ClientRowViewerViewModel)AllItems[i]).Email.ToString().ToLower().StartsWith(SearchText.ToLower()))
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
            switch (ClientSearchType)
            {
                case ClientSearchType.Name:
                    if (((ClientRowViewerViewModel)viewModel).FullName.ToString().ToLower().StartsWith(SearchText.ToLower()))
                        return true;
                    break;
                case ClientSearchType.gender:
                    if (((ClientRowViewerViewModel)viewModel).Gender.ToString().ToLower().StartsWith(SearchText.ToLower()))
                        return true;
                    break;
                case ClientSearchType.Phone:
                    if (((ClientRowViewerViewModel)viewModel).Phone.ToString().ToLower().StartsWith(SearchText.ToLower()))
                        return true;
                    break;
                case ClientSearchType.Email:
                    if (((ClientRowViewerViewModel)viewModel).Email.ToString().ToLower().StartsWith(SearchText.ToLower()))
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
            sqlParameters[0] = new SqlParameter("@Customer_ID", SqlDbType.VarChar);
            sqlParameters[0].Value = ((ClientRowViewerViewModel)viewModel).ID;

            DataConnection.ExcuteCommand("Delete_Client_Procedure", sqlParameters);
        }

        /// <summary>
        /// Edits the specified item in the list
        /// </summary>
        /// <param name="viewModel">The view model of the item to edit</param>
        protected override void EditItem(BaseRowViewerViewModel viewModel)
        {
            var clientRowViewerViewModel = viewModel as ClientRowViewerViewModel;

            Client client = new Client(
                clientRowViewerViewModel.ID,
                clientRowViewerViewModel.FirstName,
                clientRowViewerViewModel.SecondName,
                clientRowViewerViewModel.Gender,
                clientRowViewerViewModel.Phone,
                clientRowViewerViewModel.Email,
                clientRowViewerViewModel.Image);

            EditClientWindowViewModel editClientWindowViewModel
                = new EditClientWindowViewModel(client);
            UI_Manager ui_Manager = new UI_Manager();
            ui_Manager.ShowDialog(editClientWindowViewModel);

            clientRowViewerViewModel.ID = editClientWindowViewModel.NewClientData.ID;
            clientRowViewerViewModel.FirstName = editClientWindowViewModel.NewClientData.FirstName;
            clientRowViewerViewModel.SecondName = editClientWindowViewModel.NewClientData.SecondName;
            clientRowViewerViewModel.Gender = editClientWindowViewModel.NewClientData.Gender;
            clientRowViewerViewModel.Phone = editClientWindowViewModel.NewClientData.Phone;
            clientRowViewerViewModel.Email = editClientWindowViewModel.NewClientData.Email;
            clientRowViewerViewModel.Image = editClientWindowViewModel.NewClientData.Image;
        }

        /// <summary>
        /// Prints the specified item from the list
        /// </summary>
        /// <param name="viewModel">The view model of the item to print</param>
        protected override void PrintItem(BaseRowViewerViewModel viewModel)
        {
            // TODO: Implement print client method
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Converting the <see cref="Client"/> object 
        /// to <see cref="ClientRowViewer"/> object using ClientRowViewerViewModel
        /// </summary>
        /// <param name="client">The client to convert</param>
        private ClientRowViewerViewModel ConvertToClientRowViewer(Client client)
        {
            var viewModel = new ClientRowViewerViewModel
            {
                ID = client.ID,
                FirstName = client.FirstName,
                SecondName = client.SecondName,
                Gender = client.Gender,
                Phone = client.Phone,
                Email = client.Email,
                Image = client.Image
            };

            viewModel.Deleted += DeleteItem;
            viewModel.Edited += EditItem;
            viewModel.Printed += PrintItem;

            return viewModel;
        }

        #endregion

        #region Observer Pattern Methods

        public new void Update<T>(params object[] parameters)
            where T : BaseRowViewerViewModel
        {
            var viewModel = parameters[0] as ClientRowViewerViewModel;
            viewModel.Deleted += DeleteItem;
            viewModel.Edited += EditItem;
            viewModel.Printed += PrintItem;
            viewModel.ID = Client.GetClientByPhone(viewModel.Phone).ID;
            Items.Add(viewModel);
            AllItems.Add(viewModel);
        }

        #endregion
    }
}

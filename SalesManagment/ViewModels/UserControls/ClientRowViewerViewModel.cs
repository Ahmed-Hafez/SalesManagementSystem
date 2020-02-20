using System.Windows.Input;

namespace SalesManagment
{
    public class ClientRowViewerViewModel : BaseRowViewerViewModel
    {
        #region Public Properties

        #region Product Data

        /// <summary>
        /// Client ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Client First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Client Second name
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Client Full Name
        /// </summary>
        public string FullName { get => FirstName + " " + SecondName; }

        /// <summary>
        /// Client Gender
        /// </summary>
        public GenderType Gender{ get; set; }

        /// <summary>
        /// Client Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Client Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Client Image
        /// </summary>
        public byte[] Image { get; set; }

        #endregion

        #region Public Commands

        public override ICommand DeleteCommand { get; set; }
        public override ICommand EditCommand { get; set;}
        public override ICommand PrintCommand { get; set;}

        #endregion

        #endregion
    }
}

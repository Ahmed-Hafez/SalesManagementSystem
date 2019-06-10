using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security;
using System.Windows;

namespace SalesManagment
{
    /// <summary>
    /// The view model that controls the login page
    /// </summary>
    public class LoginPageViewModel : BaseViewModel
    {
        #region Private members
        
        /// <summary>
        /// The user types
        /// </summary>
        private readonly List<string> types;

        /// <summary>
        /// The accepted username of the user
        /// </summary>
        private string username;

        /// <summary>
        /// The accepted password of the user
        /// </summary>
        private string password;

        /// <summary>
        /// The accepted type of the user
        /// </summary>
        private string userType;

        #endregion

        #region Public properties
        
        /// <summary>
        /// The provided username from the textbox
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// The provided password from the textbox
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The provided type from the textbox
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// The user types
        /// </summary>
        public List<string> Types { get { return types; } }
        

        /// <summary>
        /// The used command for sign in button
        /// </summary>
        public RelayParameterizedCommand SignInCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize an instance from the <see cref="LoginPageViewModel"/> class
        /// </summary>
        /// <param name="page">The page to control</param>
        public LoginPageViewModel()
        {

            types = new List<string>() { "Manager", "Employee" };
            UserType = types[1];

            SignInCommand = new RelayParameterizedCommand((parameter) => signInButtonClick(parameter));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Attempts to sign the user in
        /// </summary>
        /// <param name="parameter">
        /// The <see cref="SecureString"/> passed in from the view
        /// for the user password
        /// </param>
        public void signInButtonClick(object parameter)
        {
            try
            {
                Password = (parameter as IHavePassword).SecurePassword.Unsecure();

                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@ID", SqlDbType.VarChar);
                sqlParameters[0].Value = Username;
                sqlParameters[1] = new SqlParameter("@Password", SqlDbType.VarChar);
                sqlParameters[1].Value = Password;
                sqlParameters[2] = new SqlParameter("@UserType", SqlDbType.VarChar);
                sqlParameters[2].Value = UserType;

                if (DataConnection.SelectData("Login_Procedure", sqlParameters).Rows.Count > 0)
                {
                    username = Username;
                    password = Password;
                    userType = UserType;

                    MessageBox.Show($"username = {username}, password = {password}, userType = {userType}, login sucess");
                }
                else MessageBox.Show("failed");
            }
            catch
            {
                MessageBox.Show("Unexpected error : login120");
            }
        }

        #endregion
    }
}

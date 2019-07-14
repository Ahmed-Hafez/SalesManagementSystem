using System.Security;
using System.Windows;

namespace SalesManagment
{
    /// <summary>
    /// The view model that controls the login page
    /// </summary>
    public class LoginPageViewModel : BasePageViewModel
    {
        #region Private members

        /// <summary>
        /// The accpeted user
        /// </summary>
        private User user;

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
        public UserType UserType { get; set; }

        /// <summary>
        /// The used command for sign in button
        /// </summary>
        public RelayParameterizedCommand SignInCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize an instance from the <see cref="LoginPageViewModel"/> class
        /// </summary>
        public LoginPageViewModel()
        {
            this.LoadAnimation = PageAnimation.SlideOpening;
            this.UnloadAnimation = PageAnimation.SlideClosing;

            user = new User();

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

                if (string.IsNullOrEmpty(Username)
                    || string.IsNullOrWhiteSpace(Username))
                {
                    MessageBox.Show("Username is required.",
                        "Signing in failed");
                    return;
                }
                else if (string.IsNullOrEmpty(Password))
                {
                    MessageBox.Show("Password is required.",
                       "Signing in failed");
                    return;
                }

                
                if (user.Login(Username, Password, this.UserType))
                {
                    // Change the current page
                    ApplicationDirector.ApplicationShell.ChangeCurrentPage(ApplicationPage.Main, page);

                    // Setting the current user of the app
                    ApplicationDirector.CurrentUser = user;
                }
                else MessageBox.Show("Username, password or user type is incorrect.",
                    "Signing in failed");
            }
            catch
            {
                // TODO Check the error code
                MessageBox.Show("Unexpected error : login105");
            }
        }

        #endregion
    }
}

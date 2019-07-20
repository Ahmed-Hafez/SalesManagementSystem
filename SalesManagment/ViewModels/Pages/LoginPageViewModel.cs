﻿using System;
using System.Security;
using System.Threading.Tasks;
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

        /// <summary>
        /// A flag indicating that the login command is running
        /// </summary>
        private bool loginIsRunning = false;

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
        /// A flag indicating that the login command is running
        /// </summary>
        public bool LoginIsRunning
        {
            get { return loginIsRunning; }
            set
            {
                loginIsRunning = value;
                OnPropertyChanged(nameof(LoginIsRunning));
            }
        }

        #region Commands

        /// <summary>
        /// The used command for sign in button
        /// </summary>
        public RelayParameterizedCommand SignInCommand { get; set; }

        #endregion

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

            SignInCommand = new RelayParameterizedCommand(async (parameter) => await SignIn(parameter));
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
        public async Task SignIn(object parameter)
        {
            try
            {
                await RunCommand(() => this.LoginIsRunning, async () =>
                {
                    Password = (parameter as IHavePassword).SecurePassword.Unsecure();

                    if (string.IsNullOrEmpty(Username)
                        || string.IsNullOrWhiteSpace(Username))
                    {
                        MessageBox.Show("Username is required.",
                            "Signing in failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else if (string.IsNullOrEmpty(Password))
                    {
                        MessageBox.Show("Password is required.",
                           "Signing in failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    bool loginSuccesseded = await Task.Run(() => user.Login(Username, Password, this.UserType));

                    if (loginSuccesseded)
                    {
                        // Change the current page
                        ApplicationDirector.ApplicationShell.ChangeCurrentPage(ApplicationPage.Main, page);

                        // Setting the current user of the app
                        ApplicationDirector.CurrentUser = user;
                    }
                    else MessageBox.Show("Username, password or user type is incorrect.",
                        "Signing in failed");
                });
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
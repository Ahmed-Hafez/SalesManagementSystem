using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesManagment
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginPageViewModel>, IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// The password of the user
        /// 
        /// 
        /// <!-- Note that : here is an violating to the MVVM roles,
        ///      But this is an exception because this {PasswordBox} hasn't
        ///      any dependancy property to bind to -->
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;
        
    }
}

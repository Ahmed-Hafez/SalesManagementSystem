using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesManagment
{
    class MainWindowViewModel : BaseViewModel
    {
        public string Text { get; set; } = "Hello from main window ";
        public string user { get; set; } = "khalid";
        public string pass { get; set; } = "123";


        public RelayCommand ButtonCommand { get; set; }

        public MainWindowViewModel()
        {
            ButtonCommand = new RelayCommand(() => MainButtonClick());
        }

        private void MainButtonClick()
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@ID", SqlDbType.VarChar);
            sqlParameters[0].Value = user;
            sqlParameters[1] = new SqlParameter("@Password", SqlDbType.VarChar);
            sqlParameters[1].Value = pass;
            if (DataConnection.SelectData("Login_Procedure", sqlParameters).Rows.Count > 0)
                MessageBox.Show($"username = {user}, password = {pass}, login sucess");
            else MessageBox.Show("failed");
        }
    }
}

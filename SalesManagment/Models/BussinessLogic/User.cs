using System.Data;
using System.Data.SqlClient;

namespace SalesManagment
{
    /// <summary>
    /// The user type of the application
    /// </summary>
    public enum UserType
    {
        Manager,
        Employee
    }

    /// <summary>
    /// The logic of the user of the application
    /// </summary>
    public class User
    {
        #region Public Properties

        /// <summary>
        /// The username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password of the user
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The type of the user
        /// </summary>
        public UserType UserType { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Login the user
        /// </summary>
        /// <param name="username">username of the user</param>
        /// <param name="password">password of the user</param>
        /// <param name="userType">userType of the user</param>
        /// <returns></returns>
        public bool Login(string username, string password, UserType userType)
        {
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@ID", SqlDbType.VarChar);
            sqlParameters[0].Value = username;
            sqlParameters[1] = new SqlParameter("@Password", SqlDbType.VarChar);
            sqlParameters[1].Value = password;
            sqlParameters[2] = new SqlParameter("@UserType", SqlDbType.VarChar);
            sqlParameters[2].Value = userType.ToString();

            if (DataConnection.SelectData("Login_Procedure", sqlParameters).Rows.Count > 0)
            {
                Username = username;
                Password = password;
                UserType = userType;

                return true;
            }
            return false;
        }

        #endregion
    }
}

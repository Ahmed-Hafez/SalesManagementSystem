using System.Data.SqlClient;
using System.Data;
using System;

namespace SalesManagment
{
    /// <summary>
    /// Represents a variety of methods to deal with the database
    /// </summary>
    public static class DataConnection
    {
        #region Private members

        /// <summary>
        /// The SQL connection object
        /// </summary>
        private static SqlConnection Connection;

        /// <summary>
        /// The string used to provide the connection data
        /// </summary>
        private static string connectionString;

        #endregion

        #region Constructor

        /// <summary>
        /// Initilize the connection data
        /// </summary>
        static DataConnection()
        {
            connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ProductDB;Integrated Security=True;";
            Connection = new SqlConnection(connectionString);
        }

        #endregion

        #region Connection state methods

        /// <summary>
        /// Open the database connection
        /// </summary>
        private static void Open()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
        }

        /// <summary>
        /// Open the database connection
        /// </summary>
        private static void Close()
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }

        #endregion

        #region Deal methods

        /// <summary>
        /// Select data from the database
        /// </summary>
        /// <param name="stored_procedure">The name of the stored procedure in the database</param>
        /// <param name="param">The parameters required for the stored procedures</param>
        public static DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {
            try
            {
                Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = stored_procedure;
                sqlCmd.Connection = Connection;

                if (param != null)
                    sqlCmd.Parameters.AddRange(param);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch(Exception e)
            {
                // For debugging reasons
                Console.WriteLine($"Exception is : {e.Message}");

                throw new Exception("Database Connection Error");
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// Delete, update or insert data from the database depending on the stored procedure
        /// </summary>
        /// <param name="stored_procedure">The name of the stored procedure in the database</param>
        /// <param name="param">The parameters required for the stored procedures</param>
        public static void ExcuteCommand(string stored_procedure, params SqlParameter[] param)
        {
            try
            {
                Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = Connection;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = stored_procedure;

                if (param != null)
                    sqlCmd.Parameters.AddRange(param);

                sqlCmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                // For debugging reasons
                Console.WriteLine($"Exception is : {e.Message}");

                throw new Exception("Database Connection Error");
            }
            finally
            {
                Close();
            }
        }

        #endregion
    }
}

using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace SalesManagment
{
    public static class DataConnection
    {
        private static SqlConnection Connection;
        private static string connectionString;

        static DataConnection()
        {
            connectionString = @"Data Source=.\SQLEXPRESS01;Initial Catalog=ProductDB;Integrated Security=True;";
            Connection = new SqlConnection(connectionString);
        }

        private static void Open() => Connection.Open();

        private static void Close() => Connection.Close();
        
        public static DataTable SelectData(string stored_procedure, SqlParameter[] param)
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

            Close();

            return dataTable;
        }

        public static void ExcuteCommand(string stored_procedure, params SqlParameter[] param)
        {
            Open();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = stored_procedure;

            if (param != null)
                sqlCmd.Parameters.AddRange(param);

            sqlCmd.ExecuteNonQuery();

            Close();
        }
    }
}

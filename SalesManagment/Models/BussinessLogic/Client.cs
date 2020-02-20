using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SalesManagment
{
    /// <summary>
    /// The gender of the client
    /// </summary>
    public enum GenderType
    {
        Male,
        Female
    }

    public class Client
    {
        #region Public Properties

        /// <summary>
        /// Client ID
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Client first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Client second name
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Client gender
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Client phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Client email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Client image
        /// </summary>
        public byte[] Image { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from <see cref="Client"/> class
        /// </summary>
        /// <param name="firstName">Client first name</param>
        /// <param name="secondName">Client second name</param>
        /// <param name="gender">Client gender</param>
        /// <param name="phone">Client phone number</param>
        /// <param name="email">Client email</param>
        /// <param name="image">Client image</param>
        public Client(string firstName, string secondName, GenderType gender, string phone, string email, byte[] image)
        {
            if (string.IsNullOrEmpty(firstName)
               || string.IsNullOrWhiteSpace(firstName)
               || string.IsNullOrEmpty(secondName)
               || string.IsNullOrWhiteSpace(secondName)
               || string.IsNullOrEmpty(phone)
               || string.IsNullOrWhiteSpace(phone)
               || string.IsNullOrEmpty(email)
               || string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Invalid Data");
            }

            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Gender = gender;
            this.Phone = phone;
            this.Email = email;
            this.Image = image;
        }

        /// <summary>
        /// Initializes a new instance from <see cref="Client"/> class
        /// </summary>
        /// <param name="id">Client ID</param>
        /// <param name="firstName">Client first name</param>
        /// <param name="secondName">Client second name</param>
        /// <param name="gender">Client gender</param>
        /// <param name="phone">Client phone number</param>
        /// <param name="email">Client email</param>
        /// <param name="image">Client image</param>
        public Client(int id, string firstName, string secondName, GenderType gender, string phone, string email, byte[] image)
            : this(firstName, secondName, gender, phone, email, image)
        {
            this.ID = id;
        }

        #endregion

        #region Methods

        #region Static Methods

        /// <summary>
        /// Getting all clients from database
        /// </summary>
        /// <returns></returns>
        public static List<Client> GetAllClients()
        {
            var clients = DataConnection.SelectData("Get_All_Clients_Procedure", null);
            var clientsList = new List<Client>();

            // If clients found, return them
            if (clients.Rows.Count > 0)
            {
                for (int i = 0; i < clients.Rows.Count; i++)
                {
                    int id = clients.Rows[i].Field<int>("Customer_ID");
                    string firstName = clients.Rows[i].Field<string>("First_Name");
                    string secondName = clients.Rows[i].Field<string>("Last_Name");
                    GenderType gender = (clients.Rows[i].Field<string>("Gender").Equals("male") ? GenderType.Male : GenderType.Female);
                    string phone = clients.Rows[i].Field<string>("Telephone");
                    string email = clients.Rows[i].Field<string>("Email");
                    byte[] image = clients.Rows[i].Field<byte[]>("Image");
                    clientsList.Add(new Client(id, firstName, secondName, gender, phone, email, image));
                }
                return clientsList;
            }

            // Otherwise
            return null;
        }

        /// <summary>
        /// Returns true if there is a client with this phone number or email in the database
        /// </summary>
        /// <param name="clientPhone">The phone number of the client to search for</param>
        /// <param name="clientEmail">The email of the client to search for</param>
        public static bool IsFound(string clientPhone, string clientEmail)
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Telephone", SqlDbType.NChar);
            sqlParameters[0].Value = clientPhone;
            sqlParameters[1] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlParameters[1].Value = clientEmail;

            var dt = DataConnection.SelectData("Find_Client_Procedure", sqlParameters);

            if (dt.Rows.Count > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Returns a client with the specified phone number if found
        /// </summary>
        /// <param name="clientPhone">phone number of the client</param>
        public static Client GetClientByPhone(string clientPhone)
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Telephone", SqlDbType.NChar);
            sqlParameters[0].Value = clientPhone;
            sqlParameters[1] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlParameters[1].Value = "";

            var dt = DataConnection.SelectData("Find_Client_Procedure", sqlParameters);

            if (dt.Rows.Count > 0)
                return GetClient(dt.Rows[0]);
            else
                throw new Exception($"Client with the phone number: {clientPhone} is not found");
        }

        /// <summary>
        /// Returns a client with the specified email if found
        /// </summary>
        /// <param name="clientEmail">The email of the client</param>
        public static Client GetClientByEmail(string clientEmail)
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Telephone", SqlDbType.NChar);
            sqlParameters[0].Value = "";
            sqlParameters[1] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlParameters[1].Value = clientEmail;

            var dt = DataConnection.SelectData("Find_Client_Procedure", sqlParameters);

            if (dt.Rows.Count > 0)
                return GetClient(dt.Rows[0]);
            else
                throw new Exception($"Client with the email: {clientEmail} is not found");
        }

        /// <summary>
        /// Returns a client with the specified id if found
        /// </summary>
        /// <param name="client">The data row in the database 
        /// which hold the client</param>
        private static Client GetClient(DataRow client)
        {
            int id = client.Field<int>("Customer_ID");
            string firstName = client.Field<string>("First_Name");
            string secondName = client.Field<string>("Last_Name");
            GenderType gender = (client.Field<string>("Gender") == "male") ? GenderType.Male : GenderType.Female;
            string phone = client.Field<string>("Telephone");
            string email = client.Field<string>("Email");
            byte[] image = client.Field<byte[]>("Image");

            return new Client(id, firstName, secondName, gender, phone, email, image);
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Adds a new client to the database,
        /// Returns True if the client was added otherwise false
        /// </summary>
        public bool Add()
        {
            // Check if there is already product with this ID in the database
            if (IsFound(Phone, Email))
                return false;

            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@First_Name", SqlDbType.VarChar);
            sqlParameters[0].Value = FirstName;
            sqlParameters[1] = new SqlParameter("@Last_Name", SqlDbType.VarChar);
            sqlParameters[1].Value = SecondName;
            sqlParameters[2] = new SqlParameter("@Gender", SqlDbType.VarChar);
            sqlParameters[2].Value = (Gender == GenderType.Male) ? "male" : "female";
            sqlParameters[3] = new SqlParameter("@Telephone", SqlDbType.NChar);
            sqlParameters[3].Value = Phone;
            sqlParameters[4] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlParameters[4].Value = Email;
            sqlParameters[5] = new SqlParameter("@Image", SqlDbType.Image);
            sqlParameters[5].Value = Image;

            DataConnection.ExcuteCommand("Add_Client_Procedure", sqlParameters);

            return true;
        }

        /// <summary>
        /// Edits the client data in the database
        /// </summary>
        public void Edit()
        {
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@Customer_ID", SqlDbType.Int);
            sqlParameters[0].Value = ID;
            sqlParameters[1] = new SqlParameter("@First_Name", SqlDbType.VarChar);
            sqlParameters[1].Value = FirstName;
            sqlParameters[2] = new SqlParameter("@Last_Name", SqlDbType.VarChar);
            sqlParameters[2].Value = SecondName;
            sqlParameters[3] = new SqlParameter("@Gender", SqlDbType.VarChar);
            sqlParameters[3].Value = (Gender == GenderType.Male) ? "male" : "female";
            sqlParameters[4] = new SqlParameter("@Telephone", SqlDbType.NChar);
            sqlParameters[4].Value = Phone;
            sqlParameters[5] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlParameters[5].Value = Email;
            sqlParameters[6] = new SqlParameter("@Image", SqlDbType.Image);
            sqlParameters[6].Value = Image;

            DataConnection.ExcuteCommand("Edit_Client_Procedure", sqlParameters);
        }

        /// <summary>
        /// Returns the client name
        /// </summary>
        public override string ToString()
        {
            return FirstName + " " + SecondName;
        }

        #endregion

        #endregion
    }
}

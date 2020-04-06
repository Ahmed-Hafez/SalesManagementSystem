using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SalesManagment
{
    public class Order
    {
        #region Private Members

        /// <summary>
        /// The total price of the order in the cart
        /// </summary>
        private decimal mtotalPrice;

        /// <summary>
        /// Determine if the order is recorded in the database or not
        /// </summary>
        private bool mRecorded;

        #endregion

        #region Public Properties

        /// <summary>
        /// The ID of the order (i.e Bill Number)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The date and the time at which the order is made in it
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The client name that order made for him
        /// 
        /// (optional) 
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// The name of the seller that creates the order (A program user)
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// The total price of the order in the cart
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                // If price is recorded, return it.
                if (mRecorded) return mtotalPrice;

                // Else compute it.
                orderLines.ForEach((orderLine) => mtotalPrice += orderLine.TotalPrice);
                return mtotalPrice;
            }
            private set { mtotalPrice = value; }
        }

        /// <summary>
        /// The order details
        /// </summary>
        public List<OrderLine> orderLines { get; set; }

        /// <summary>
        /// The current order to made
        /// </summary>
        public static Order CurrentOrder { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from <see cref="Order"/> class - 
        /// Note: this constructor was made to use it when creating new (unrecorded) order
        /// </summary>
        private Order()
        {
            orderLines = new List<OrderLine>();
            SellerName = User.CurrentUser?.Username;
            mtotalPrice = 0;
            mRecorded = false;
        }

        /// <summary>
        /// Initializes a new instance from <see cref="Order"/> class - 
        /// Note: this constructor was made to use it when creating new (recorded) order
        /// </summary>
        /// <param name="id">The id of the order</param>
        /// <param name="date">The date in which the order is made</param>
        /// <param name="clientName">The client which the order made for him</param>
        /// <param name="sellerName">The name of the seller</param>
        /// <param name="totalPrice">The total price of the order</param>
        private Order(int id, DateTime date, string clientName, string sellerName, decimal totalPrice)
        {
            this.ID = id;
            this.Date = date;
            this.ClientName = clientName;
            this.SellerName = sellerName;
            this.mtotalPrice = totalPrice;
            mRecorded = true;
        }

        #endregion

        #region Mehtods

        /// <summary>
        /// Adding a new product to the order
        /// </summary>
        /// <param name="rowNumber">The rank of the product in the bill</param>
        /// <param name="productName">The product name</param>
        /// <param name="productPrice">The product price</param>
        /// <param name="quantity">The quantity to sell</param>
        /// <param name="discount">The product discount</param>
        public void AddOrderLine(int rowNumber, long productID, string productName, decimal productPrice, int quantity, decimal discount)
        {
            orderLines.Add(new OrderLine(rowNumber, productID, productName, productPrice, CurrentOrder, quantity, discount));
        }

        /// <summary>
        /// Recording an order to the database
        /// </summary>
        public bool MakeOrder()
        {
            // If there are no products then there is no order to made.
            if (orderLines.Count == 0)
                return false;

            mtotalPrice = 0;
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@Order_Date", SqlDbType.DateTime);
            sqlParameters[0].Value = DateTime.Now;
            sqlParameters[1] = new SqlParameter("@Customer_Name", SqlDbType.VarChar);
            sqlParameters[1].Value = "";
            sqlParameters[2] = new SqlParameter("@Seller_Name", SqlDbType.VarChar);
            sqlParameters[2].Value = User.CurrentUser.Username;
            sqlParameters[3] = new SqlParameter("@TotalPrice", SqlDbType.Decimal);
            sqlParameters[3].Value = this.TotalPrice;
            DataConnection.ExcuteCommand("Add_Order_Procedure", sqlParameters);

            foreach (OrderLine orderLine in orderLines)
            {
                sqlParameters = new SqlParameter[6];
                sqlParameters[0] = new SqlParameter("@Product_Name", SqlDbType.VarChar);
                sqlParameters[0].Value = orderLine.ProductName;
                sqlParameters[1] = new SqlParameter("@Product_Price", SqlDbType.Decimal);
                sqlParameters[1].Value = orderLine.ProductPrice;
                sqlParameters[2] = new SqlParameter("@Order_ID", SqlDbType.Int);
                sqlParameters[2].Value = CurrentOrder.ID;
                sqlParameters[3] = new SqlParameter("@Quantity", SqlDbType.Int);
                sqlParameters[3].Value = orderLine.Quantity;
                sqlParameters[4] = new SqlParameter("@Discount", SqlDbType.Decimal);
                sqlParameters[4].Value = orderLine.Discount;
                sqlParameters[5] = new SqlParameter("@Row_Number", SqlDbType.Int);
                sqlParameters[5].Value = orderLine.RowNumber;
                DataConnection.ExcuteCommand("Add_OrderDetails_Procedure", sqlParameters);

                SqlParameter[] productSqlParameters = new SqlParameter[2];
                productSqlParameters[0] = new SqlParameter("@Product_ID", SqlDbType.VarChar);
                productSqlParameters[0].Value = orderLine.ProductID.ToString();
                productSqlParameters[1] = new SqlParameter("@Quantity", SqlDbType.Int);
                productSqlParameters[1].Value = orderLine.Quantity;
                DataConnection.ExcuteCommand("Update_Product_Quantity_Procedure", productSqlParameters);
            }

            // Order is made successfully
            // Now: Advance the bill number and reset the total price.
            CurrentOrder.ID++;
            CurrentOrder.TotalPrice = 0;
            orderLines = new List<OrderLine>();
            return true;
        }

        /// <summary>
        /// Returns the current bill number
        /// </summary>
        public static long GetCurrentOrderID()
        {
            if (CurrentOrder == null)
            {
                CurrentOrder = new Order();
                var orderID = DataConnection.SelectData("Get_Current_OrderID_Procedure", null);
                CurrentOrder.ID = (DBNull.Value.Equals(orderID.Rows[0]["Max_ID"])) ? 1 : orderID.Rows[0].Field<int>("Max_ID");
            }
            return CurrentOrder.ID;
        }

        /// <summary>
        /// Returns the order details
        /// </summary>
        /// <param name="orderID">The id of the order to get its details</param>
        public static List<OrderLine> GetOrderLines(int orderID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Order_ID", SqlDbType.Int);
            sqlParameters[0].Value = orderID;
            var dt = DataConnection.SelectData("Get_OrderDetails_Procedure", sqlParameters);

            List<OrderLine> orderLines = new List<OrderLine>();

            foreach (DataRow item in dt.Rows)
            {
                Order order = GetOrder(item.Field<int>("Order_ID"));
                int quantity = item.Field<int>("Quantity");
                decimal discount = item.Field<decimal>("Discount");
                int rowNumber = item.Field<int>("Row_Number");
                string productName = item.Field<string>("Product_Name");
                decimal productPrice = item.Field<decimal>("Product_Price");
                orderLines.Add(new OrderLine(rowNumber, productName, productPrice, order, quantity, discount));
            }

            return orderLines;
        }

        /// <summary>
        /// Returns the basic data of the order
        /// </summary>
        /// <param name="orderID">The ID of the order</param>
        public static Order GetOrder(int orderID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Order_ID", SqlDbType.Int);
            sqlParameters[0].Value = orderID;

            var dt = DataConnection.SelectData("Get_Order_Procedure", sqlParameters);

            if (dt.Rows.Count > 0)
                return GetOrder(dt.Rows[0]);
            else
                throw new Exception($"Order with the ID = {orderID} is not found");
        }

        /// <summary>
        /// A helper method to get the order data from <see cref="DataRow"/>
        /// </summary>
        /// <param name="order">The data row to get data from it</param>
        private static Order GetOrder(DataRow order)
        {
            int orderID = order.Field<int>("Order_ID");
            DateTime orderDate = order.Field<DateTime>("Order_Date");
            decimal totalPrice = order.Field<decimal>("TotalPrice");
            string clientName = order.Field<string>("Customer_Name");
            string sellerName = order.Field<string>("Seller_Name");

            return new Order(orderID, orderDate, clientName, sellerName, totalPrice);
        }
        #endregion
    }
}

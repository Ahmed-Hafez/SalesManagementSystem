namespace SalesManagment
{
    public class OrderLine
    {
        #region Public Properties

        /// <summary>
        /// The row number which holds the order line
        /// </summary>
        public int RowNumber { get; set; }

        /// <summary>
        /// The id of the product to sell
        /// </summary>
        public long ProductID { get; }

        /// <summary>
        /// The product name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The product price
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// The quantity of the product to sell
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The applied discount
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// The total price of the order line
        /// </summary>
        public decimal TotalPrice { get { return (1 - Discount) * (Quantity * ProductPrice); } }

        /// <summary>
        /// The order which holds this order line
        /// </summary>
        public Order Order { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize an instance from <see cref="OrderLine"/> class
        /// </summary>
        /// <param name="rowNumber">The row number which holds the order line</param>
        /// <param name="productName">The product name</param>
        /// <param name="productPrice">The product price</param>
        /// <param name="order">The order which holds this order line</param>
        /// <param name="quantity">The quantity of the product to sell</param>
        /// <param name="discount">The applied discount</param>
        public OrderLine(int rowNumber, string productName, decimal productPrice, Order order, int quantity, decimal discount)
        {
            this.RowNumber = rowNumber;
            this.ProductName = productName;
            this.ProductPrice = productPrice;
            this.Order = order;
            this.Quantity = quantity;
            this.Discount = discount;
        }

        /// <summary>
        /// Initialize an instance from <see cref="OrderLine"/> class
        /// </summary>
        /// <param name="rowNumber">The row number which holds the order line</param>
        /// <param name="productID">The product id</param>
        /// <param name="productName">The product name</param>
        /// <param name="productPrice">The product price</param>
        /// <param name="order">The order which holds this order line</param>
        /// <param name="quantity">The quantity of the product to sell</param>
        /// <param name="discount">The applied discount</param>
        public OrderLine(int rowNumber, long productID, string productName, decimal productPrice, Order order,
            int quantity, decimal discount) : this(rowNumber, productName, productPrice, order, quantity, discount)
        {
            this.ProductID = productID;
        }

        #endregion
    }
}
using System;
using System.Windows.Input;

namespace SalesManagment
{
    public class OrderRowViewerViewModel : BaseRowViewerViewModel
    {
        #region Private Members

        /// <summary>
        /// The quantity to sell from the product (in a string format)
        /// </summary>
        private string mQuantityString = "1";

        /// <summary>
        /// The applied discount (in a string format)
        /// </summary>
        private string mDiscountString = "0";

        #endregion

        #region Public Events

        /// <summary>
        /// Fires when the total price of the order line is changed
        /// </summary>
        public event Action TotalPriceChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// The row number of this row viewer in the row viewers list
        /// </summary>
        public int RowNumber { get; set; }

        /// <summary>
        /// The ID of the order which this row viewer belongs to
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// The view model of the product which this row viewer belongs to
        /// </summary>
        public ProductRowViewerViewModel ProductViewModel { get; set; }

        /// <summary>
        /// The ID Of the product to sell
        /// </summary>
        public long ProductID { get; }

        /// <summary>
        /// The name Of the product to sell
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The price Of the product to sell
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// The quantity to sell from the product
        /// </summary>
        public int Quantity { get { return Convert.ToInt32(QuantityString == "" ? "1" : QuantityString); } }

        /// <summary>
        /// The quantity to sell from the product (in a string format)
        /// </summary>
        /// 
        /// <!--Note: it was made as a string to allow writing the number normally in the Numeric Textbox
        /// because if it is integer directly then there is a problem when removing and adding numbers 
        /// with decimal points if we need them-->
        public string QuantityString
        {
            get { return mQuantityString; }
            set
            {
                mQuantityString = value;
                TotalPriceChanged?.Invoke();
            }
        }

        /// <summary>
        /// The applied discount
        /// </summary>
        public decimal Discount { get { return Convert.ToDecimal(DiscountString == "" ? "0" : DiscountString); } }

        /// <summary>
        /// The applied discount (in a string format)
        /// </summary>
        /// 
        /// <!--Note: it was made as a string to allow writing the number normally in the Numeric Textbox
        /// because if it is decimal directly then there is a problem when removing and adding numbers with decimal points-->
        public string DiscountString
        {
            get { return mDiscountString; }
            set
            {
                mDiscountString = value;
                TotalPriceChanged?.Invoke();
            }
        }

        /// <summary>
        /// The total price of the order line
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                if (CanDelete)
                    return (1 - Discount) * (ProductPrice * Quantity);
                return (1 - Discount) * (ProductPrice * Quantity);
            }
        }

        /// <summary>
        /// Determine if the delete button can be used or not,
        /// It is used when a new cart has being made,
        /// And not used if the row viewer is for existing order line in the database
        /// </summary>
        public bool CanDelete { get; set; } = true;

        #region Public Commands

        public override ICommand DeleteCommand { get; set; }
        public override ICommand EditCommand { get; set; }
        public override ICommand PrintCommand { get; set; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize a new instance from <see cref="OrderRowViewerViewModel"/> class
        /// </summary>
        /// <param name="rowNumber">The row number which holds the order line</param>
        /// <param name="orderID">The ID of the order which contains the order line to show</param>
        /// <param name="quantityString">The quantity of the product to sell</param>
        /// <param name="discountString">The applied discount</param>
        private OrderRowViewerViewModel(int rowNumber, int orderID, string quantityString, string discountString)
        {
            this.RowNumber = rowNumber;
            this.OrderID = orderID;
            this.QuantityString = quantityString;
            this.DiscountString = discountString;
        }

        /// <summary>
        /// Initialize a new instance from <see cref="OrderRowViewerViewModel"/> class
        /// </summary>
        /// <param name="rowNumber">The row number which holds the order line</param>
        /// <param name="orderID">The ID of the order which contains the order line to show</param>
        /// <param name="quantityString">The quantity of the product to sell</param>
        /// <param name="discountString">The applied discount</param>
        /// <param name="productName">The product name</param>
        /// <param name="productName">The product price</param>
        public OrderRowViewerViewModel(int rowNumber, int orderID, string quantityString, string discountString,
            string productName, decimal productPrice) : this(rowNumber, orderID, quantityString, discountString)
        {
            this.ProductName = productName;
            this.ProductPrice = productPrice;
        }

        /// <summary>
        /// Initialize a new instance from <see cref="OrderRowViewerViewModel"/> class
        /// </summary>
        /// <param name="rowNumber">The row number which holds the order line</param>
        /// <param name="orderID">The ID of the order which contains the order line to show</param>
        /// <param name="quantityString">The quantity of the product to sell</param>
        /// <param name="discountString">The applied discount</param>
        /// <param name="productViewModel">The view model to get product data from it</param>
        public OrderRowViewerViewModel(int rowNumber, int orderID, string quantityString, string discountString,
            ProductRowViewerViewModel productViewModel) : this(rowNumber, orderID, quantityString, discountString)
        {
            this.ProductViewModel = productViewModel;
            this.ProductID = productViewModel.ID;
            this.ProductName = productViewModel.Name;
            this.ProductPrice = productViewModel.Price;
            productViewModel.ProductUpdated += () =>
            {
                ProductName = productViewModel.Name;
                ProductPrice = productViewModel.Price;
            };
        }

        #endregion
    }
}

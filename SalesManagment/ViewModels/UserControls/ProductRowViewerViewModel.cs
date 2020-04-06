using System;
using System.Windows.Input;

namespace SalesManagment
{
    public class ProductRowViewerViewModel : BaseRowViewerViewModel
    {
        #region Public Events
        
        /// <summary>
        /// Fire when product is updated
        /// </summary>
        public event Action ProductUpdated;

        #endregion
        
        #region Public Properties

        #region Product Data

        /// <summary>
        /// The ID of the product
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Quantity of the product in the stock
        /// </summary>
        public double StoredQuantity { get; set; }

        /// <summary>
        /// The Price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The formated price of the product
        /// </summary>
        public string FormatedPrice { get { return Price.ToString() + " L.E"; } }

        /// <summary>
        /// The CategoryName of the product
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// The Description of the product
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Picture of the product
        /// </summary>
        public byte[] Picture { get; set; }

        /// <summary>
        /// Determine if product isn't in the cart or in it
        /// </summary>
        public bool IsOutFromCart { get; set; } = true;

        #endregion

        #region Public Commands

        public override ICommand DeleteCommand { get; set; }
        public override ICommand EditCommand { get; set;}
        public override ICommand PrintCommand { get; set;}

        /// <summary>
        /// The command used to add product to cart
        /// </summary>
        public ICommand AddToCartCommand { get; set; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize an instance from the <see cref="ProductRowViewerViewModel"/> class
        /// </summary>
        public ProductRowViewerViewModel()
        {
            AddToCartCommand = new RelayCommand(() => AddToCart());
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adding this item to cart
        /// </summary>
        public void AddToCart()
        {
            OrderRowViewerListViewModel.Instance.AddToCart(this);
        }

        /// <summary>
        /// Notify that the product is updated
        /// </summary>
        public void Update()
        {
            ProductUpdated?.Invoke();
        }

        #endregion
    }
}

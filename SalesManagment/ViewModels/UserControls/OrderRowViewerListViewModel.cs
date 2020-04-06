using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SalesManagment
{
    public class OrderRowViewerListViewModel : BaseRowViewerListViewModel
    {
        #region Private Members

        /// <summary>
        /// Determine if there is searching now or not
        /// </summary>
        private bool mIsSearching = false;

        #endregion

        #region Public Properties

        /// <summary>
        /// A singleton instance
        /// </summary>
        public static OrderRowViewerListViewModel Instance { get; private set; }

        /// <summary>
        /// The current cart to add products in it
        /// </summary>
        public ObservableCollection<BaseRowViewerViewModel> CurrentCart { get; private set; }

        /// <summary>
        /// The bill number of the bill that is shown in this time
        /// </summary>
        public long BillNumber { get { return (mIsSearching) ? long.Parse(SearchText) : Order.GetCurrentOrderID(); } }

        /// <summary>
        /// The total price of the bill that is shown in this time
        /// </summary>
        public decimal TotalPrice { get { return ComputeTotalPrice(); } }

        #region Commands

        /// <summary>
        /// The command related to confirm the orders and make the bill
        /// </summary>
        public ICommand ConfirmCommand { get; set; }

        /// <summary>
        /// The command related to remove all orders
        /// </summary>
        public ICommand RemoveAllCommand { get; set; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the <see cref="OrderRowViewerListViewModel"/> class
        /// </summary>
        public OrderRowViewerListViewModel()
        {
            // Just Initialization to avoid errors in the base class, But there is no use for it here.
            AllItems = null;

            Instance = this;
            CurrentCart = new ObservableCollection<BaseRowViewerViewModel>();

            // Searching here is to make the (Items) list equals the (CurrentCart)
            // i.e First if condition will hold
            searchHandler();

            this.SearchFinished += () => OnPropertyChanged(nameof(TotalPrice));

            LoadAnimationDuration = 50;

            ConfirmCommand = new RelayCommand(Confirm);
            RemoveAllCommand = new RelayCommand(RemoveAll);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Searches for the specified bill
        /// </summary>
        protected override ObservableCollection<BaseRowViewerViewModel> Search()
        {
            if (string.IsNullOrEmpty(SearchText) || string.IsNullOrWhiteSpace(SearchText))
            {
                mIsSearching = false;
                OnPropertyChanged(nameof(BillNumber));
                return CurrentCart;
            }
            mIsSearching = true;
            OnPropertyChanged(nameof(BillNumber));
            var list = Order.GetOrderLines(System.Convert.ToInt32(SearchText))
                .ConvertAll((orderLine) => ConvertToOrderRowViewer(orderLine));
            var foundedItems = new ObservableCollection<BaseRowViewerViewModel>(list);
            return foundedItems;
        }

        /// <summary>
        /// Matches the passed view model with the text in the searchBox depending on
        /// the type of search
        /// </summary>
        /// <param name="viewModel">The view model to match with</param>
        protected override bool IsMatch(BaseRowViewerViewModel viewModel)
        {
            if (((OrderRowViewerViewModel)viewModel).OrderID == long.Parse(SearchText))
                return true;
            return false;
        }

        /// <summary>
        /// Deletes the specified item from the list
        /// </summary>
        /// <param name="viewModel">The view model of the item to delete</param>
        protected override void DeleteItem(BaseRowViewerViewModel viewModel)
        {
            OrderRowViewerViewModel vm = viewModel as OrderRowViewerViewModel;

            // Delete from the items list
            Items.Remove(viewModel);
            CurrentCart.Remove(viewModel);
            vm.ProductViewModel.IsOutFromCart = true;
            for (int i = ((OrderRowViewerViewModel)viewModel).RowNumber - 1; i < Items.Count; i++)
                ((OrderRowViewerViewModel)Items[i]).RowNumber--;
            OnPropertyChanged(nameof(TotalPrice));
        }

        protected override void EditItem(BaseRowViewerViewModel viewModel) => throw new System.NotImplementedException();

        protected override void PrintItem(BaseRowViewerViewModel viewModel) => throw new System.NotImplementedException();

        protected void CancelEditing(BaseRowViewerViewModel viewModel) => throw new System.NotImplementedException();

        #endregion

        #region Private Helpers

        /// <summary>
        /// Converting the <see cref="Order"/> object 
        /// to <see cref="OrderRowViewer"/> object using <see cref="OrderRowViewerViewModel"/>
        /// </summary>
        /// <param name="orderLine">The order line to convert</param>
        private OrderRowViewerViewModel ConvertToOrderRowViewer(OrderLine orderLine)
        {
            var viewModel = new OrderRowViewerViewModel
                (
                orderLine.RowNumber,
                orderLine.Order.ID,
                orderLine.Quantity.ToString(),
                orderLine.Discount.ToString(),
                orderLine.ProductName,
                orderLine.ProductPrice
                );
            viewModel.CanDelete = false;

            return viewModel;
        }

        /// <summary>
        /// Adds the specified product to cart
        /// </summary>
        /// <param name="productViewModel">The view model of the product row viewer to add product</param>
        public void AddToCart(ProductRowViewerViewModel productViewModel)
        {
            var viewModel = new OrderRowViewerViewModel
            (
                CurrentCart.Count + 1,
                Order.CurrentOrder.ID,
                "1",
                "0",
                productViewModel
            );
            viewModel.CanDelete = true;

            // Updates the list price
            viewModel.TotalPriceChanged += () => OnPropertyChanged(nameof(TotalPrice));
            viewModel.Deleted += DeleteItem;

            if (!mIsSearching)
            {
                CurrentCart.Add(viewModel);
                Items.Add(viewModel);
            }
            else CurrentCart.Add(viewModel);

            // Make the product not available to be added to the cart again
            // Because the qunatity of the product can be specified in the (CartPage)
            productViewModel.IsOutFromCart = false;

            OnPropertyChanged(nameof(TotalPrice));
        }

        /// <summary>
        /// Removes the product from the cart
        /// </summary>
        /// <param name="viewModel">The view model of the product row viewer to remove the product</param>
        public void RemoveFromCart(ProductRowViewerViewModel viewModel)
        {
            // Removing it from the (Items) list if there is no searching now
            if (!mIsSearching)
            {
                foreach (OrderRowViewerViewModel item in Items)
                {
                    if (item.ProductViewModel.Equals(viewModel))
                    {
                        Items.Remove(item);
                        break;
                    }
                }
            }

            // Removing it from the cart
            foreach (OrderRowViewerViewModel item in CurrentCart)
            {
                if (item.ProductViewModel.Equals(viewModel))
                {
                    CurrentCart.Remove(item);
                    break;
                }
            }
        }

        /// <summary>
        /// Removes all products from the cart
        /// </summary>
        public void RemoveAll()
        {
            if (!mIsSearching)
                foreach (var item in CurrentCart)
                    Items.Remove(item);

            // Make the product available to be added in another cart
            foreach (OrderRowViewerViewModel item in CurrentCart)
                item.ProductViewModel.IsOutFromCart = true;

            CurrentCart.Clear();

            OnPropertyChanged(nameof(TotalPrice));
        }

        /// <summary>
        /// Updates the bill number
        /// </summary>
        public void UpdateBillNumber()
        {
            OnPropertyChanged(nameof(BillNumber));
            OnPropertyChanged(nameof(TotalPrice));
        }

        /// <summary>
        /// Computes the total price of the cart
        /// </summary>
        private decimal ComputeTotalPrice()
        {
            decimal totalPrice = 0;
            if (mIsSearching)
                foreach (var item in Items)
                    totalPrice += ((OrderRowViewerViewModel)item).TotalPrice;
            else
                foreach (var item in CurrentCart)
                    totalPrice += ((OrderRowViewerViewModel)item).TotalPrice;
            return totalPrice;
        }

        /// <summary>
        /// Validates the cart and makes an order
        /// </summary>
        public void Confirm()
        {
            foreach (OrderRowViewerViewModel item in CurrentCart)
            {
                if (item.Quantity > item.ProductViewModel.StoredQuantity)
                {
                    MessageBox.Show($"there are no enough products from item {item.ProductViewModel.Name} " +
                        $"in row number {item.RowNumber}", "Confirmation faild", MessageBoxButton.OK, MessageBoxImage.Error);
                    Order.CurrentOrder.orderLines = new System.Collections.Generic.List<OrderLine>();
                    return;
                }
                else if (item.Quantity == 0)
                {
                    MessageBox.Show($"Quantity can't be zero " +
                        $"in row number {item.RowNumber}", "Confirmation faild", MessageBoxButton.OK, MessageBoxImage.Error);
                    Order.CurrentOrder.orderLines = new System.Collections.Generic.List<OrderLine>();
                    return;
                }
                else if (item.Discount > 1)
                {
                    MessageBox.Show($"Discount precentage must be value between 0.0 and 1.0 " +
                        $"in row number {item.RowNumber}", "Confirmation faild", MessageBoxButton.OK, MessageBoxImage.Error);
                    Order.CurrentOrder.orderLines = new System.Collections.Generic.List<OrderLine>();
                    return;
                }
                Order.CurrentOrder.AddOrderLine(item.RowNumber, item.ProductID, item.ProductName, item.ProductPrice, item.Quantity, item.Discount);
            }

            if (Order.CurrentOrder.MakeOrder())
                MessageBox.Show("Order was made successfully", "Order succeeded", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Cart is empty", "Order failed", MessageBoxButton.OK, MessageBoxImage.Error);

            foreach (OrderRowViewerViewModel item in CurrentCart)
                item.ProductViewModel.StoredQuantity -= item.Quantity;

            RemoveAll();
            UpdateBillNumber();
        }

        #endregion
    }
}

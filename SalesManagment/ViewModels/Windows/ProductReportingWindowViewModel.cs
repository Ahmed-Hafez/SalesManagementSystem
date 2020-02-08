namespace SalesManagment
{
    public class ProductReportingWindowViewModel : BaseWindowViewModel<ProductReportingWindowViewModel>
    {
        /// <summary>
        /// ID of the product to be shown
        /// </summary>
        private long mProductID;

        /// <summary>
        /// Initialize an instance from the <see cref="ProductReportingWindowViewModel"/> class
        /// </summary>
        /// <param name="productID">The ID of the product to printed</param>
        public ProductReportingWindowViewModel(long productID)
        {
            this.mProductID = productID;
        }

        public override object WindowLoaded(params object[] parameters)
        {
            ProductReport productReport = new ProductReport();
            productReport.SetParameterValue("@Product_ID", mProductID.ToString());
            return productReport;
        }
    }
}

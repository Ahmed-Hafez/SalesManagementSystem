namespace SalesManagment
{
    public class ProductRowViewerViewModel
    {
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
        public string Quantity { get; set; }

        /// <summary>
        /// The Price of the product
        /// </summary>
        public string Price { get; set; }

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
    }
}

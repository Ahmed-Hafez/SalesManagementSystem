using System.Collections.Generic;

namespace SalesManagment
{
    public class AddingProductPageViewModel : BasePageViewModel
    {
        public List<string> CategoryItems { get; set; }

        public AddingProductPageViewModel()
        {
            CategoryItems = new List<string> { "Ahmed Hafez", "Mohamed Hafez", "Sara Hafez", "Hafez Taha", "Shadia Fawzy" };
        }

    }
}

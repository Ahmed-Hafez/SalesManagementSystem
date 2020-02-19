using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesManagment
{
    /// <summary>
    /// Interaction logic for CategoriesManagementPage.xaml
    /// </summary>
    public partial class CategoriesManagementPage : BasePage<CategoriesManagementPageViewModel>
    {
        private readonly int AddingCategorySectionHeight = 200;
        private DoubleAnimation openAddingCategorySection;
        private DoubleAnimation closeAddingCategorySection;
        private bool isAddingCategorySection_Opened = false;

        public static CategoriesManagementPage GetInstance { get; private set; } = new CategoriesManagementPage();

        private CategoriesManagementPage()
        {
            InitializeComponent();
            openAddingCategorySection = new DoubleAnimation(0, AddingCategorySectionHeight, TimeSpan.FromMilliseconds(100));
            closeAddingCategorySection = new DoubleAnimation(AddingCategorySectionHeight, 0, TimeSpan.FromMilliseconds(100));
        }

        /// <summary>
        /// Opens the adding category section
        /// </summary>
        private void OpenAddingCategorySection(object sender, RoutedEventArgs e)
        {
            if (!isAddingCategorySection_Opened)
            {
                isAddingCategorySection_Opened = true;
                AddingCategorySection.BeginAnimation(HeightProperty, openAddingCategorySection);
            }
        }

        /// <summary>
        /// Closes the adding category section
        /// </summary>
        private void CloseAddingCategorySection(object sender, RoutedEventArgs e)
        {
            isAddingCategorySection_Opened = false;
            AddingCategorySection.BeginAnimation(HeightProperty, closeAddingCategorySection);
        }
    }
}

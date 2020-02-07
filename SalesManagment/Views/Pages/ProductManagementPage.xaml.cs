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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesManagment
{
    /// <summary>
    /// Interaction logic for ProductManagementPage.xaml
    /// </summary>
    public partial class ProductManagementPage : BasePage<ProductManagementPageViewModel>
    {
        public static ProductManagementPage GetInstance { get; private set; } = new ProductManagementPage();

        /// <summary>
        /// Determine whether it's the first load of the page or not
        /// </summary>
        public bool FirstLoad { get; private set; } = true;

        private ProductManagementPage()
        {
            InitializeComponent();
            this.Loaded += ProductManagementPage_Loaded;
        }

        private void Shell_SizeChanged(object sender, SizeChangedEventArgs e) => UpdateValues();

        private void ProductManagementPage_Loaded(object sender, RoutedEventArgs e) 
        {
            if(FirstLoad)
            {
                ApplicationDirector.ApplicationShell.Shell.SizeChanged += Shell_SizeChanged;
                FirstLoad = false;
            }
            UpdateValues();
        }
        

        private void UpdateValues()
        {
            var vm = this.ViewModel as ProductManagementPageViewModel;
            vm.Width = this.WindowWidth;
            vm.Height = this.WindowHeight;
            vm.OnPropertyChanged(nameof(vm.MinFrameWidth));
        }
    }
}

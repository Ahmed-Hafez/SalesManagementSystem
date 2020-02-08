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
using System.Windows.Shapes;

namespace SalesManagment
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ProductReportingWindow : Window
    {
        public ProductReportingWindow()
        {
            InitializeComponent();
            Loaded += ProductReportingWindow_Loaded;
        }

        private void ProductReportingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = (this.DataContext as ProductReportingWindowViewModel);
            var report = vm.WindowLoaded() as ProductReport;
            reportViewer.ViewerCore.ReportSource = report;
        }
    }
}

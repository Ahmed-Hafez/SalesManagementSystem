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
    /// Interaction logic for CategoriesManagementPage.xaml
    /// </summary>
    public partial class CategoriesManagementPage : BasePage<CategoriesManagementPageViewModel>
    {
        public static CategoriesManagementPage GetInstance { get; private set; } = new CategoriesManagementPage();
        public CategoriesManagementPage()
        {
            InitializeComponent();
        }
    }
}

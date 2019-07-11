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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : BasePage<MainPageViewModel> 
    {
        public MainPage()
        {
            InitializeComponent();
            
            //object[] commands =
            //{
            //    new RelayCommand(() => MessageBox.Show("Button1")),
            //    new RelayCommand(() => MessageBox.Show("Button2")),
            //    new RelayCommand(() => MessageBox.Show("Button3")),
            //    new RelayCommand(() => MessageBox.Show("Button4")),
            //    new RelayCommand(() => MessageBox.Show("Button5"))
            //};

            //btnlist.ButtonsCommands = commands;
        }

        private void Btnlist_Open(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("works");
        }
    }
}

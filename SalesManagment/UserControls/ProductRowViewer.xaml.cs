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
    /// Interaction logic for ProductRowViewer.xaml
    /// </summary>
    public partial class ProductRowViewer : UserControl
    {
        private bool DescriptionGridOpened;
        private DoubleAnimation openDescriptionGrid;
        private DoubleAnimation closeDescriptionGrid;
        private readonly double descriptionGridOpeningHeight;

        public ProductRowViewer()
        {
            InitializeComponent();

            DescriptionGrid.Height = 0;
            DescriptionGridOpened = false;

            descriptionGridOpeningHeight = 
                DescriptionBox.Height + DescriptionLabel.FontSize + DescriptionBox.BorderThickness.Bottom ;

            openDescriptionGrid = new DoubleAnimation(0, descriptionGridOpeningHeight, TimeSpan.FromMilliseconds(300));
            closeDescriptionGrid = new DoubleAnimation(descriptionGridOpeningHeight, 0, TimeSpan.FromMilliseconds(300));
        }


        // TODO : Fix this
        private void notesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!DescriptionGridOpened)
            {
                DescriptionGridOpened = true;
                DescriptionGrid.BeginAnimation(HeightProperty, openDescriptionGrid);
            }
            else
            {
                DescriptionGridOpened = false;
                DescriptionGrid.BeginAnimation(HeightProperty, closeDescriptionGrid);
            }
        }

    }
}

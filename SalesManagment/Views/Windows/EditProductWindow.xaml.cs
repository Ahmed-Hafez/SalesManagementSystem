﻿using System;
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
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        public EditProductWindow()
        {
            InitializeComponent();
        }

        private void DraggableBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
﻿using Baudi.Client.ViewModels;
using Baudi.DAL.Models;
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

namespace GUIBD
{
    /// <summary>
    /// Interaction logic for OknoEdycjiLokalu.xaml
    /// </summary>
    public partial class LocalEditWindow : Window
    {
        public LocalEditWindow(Local selectedLocal, BuildingEditWindowCode owner)
        {
            InitializeComponent();
            this.DataContext = new LocalEditWindowCode(selectedLocal, this, owner);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

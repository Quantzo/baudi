﻿using Baudi.Client.ViewModels;
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

namespace Baudi.Client.View.SelectorWindow
{
    /// <summary>
    /// Interaction logic for BuildingSelector.xaml
    /// </summary>
    public partial class BuildingSelector : Window
    {
        public BuildingSelector(OwnershipEditWindowCode owner)
        {
            InitializeComponent();
            this.DataContext = new BuildingSelectorCode(this, owner);
        }
    }
}
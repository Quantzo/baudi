﻿using System.Windows.Controls;
using Baudi.Client.ViewModels.TabsViewModels;

namespace Baudi.Client.View.Tabs
{
    /// <summary>
    ///     Interaction logic for NotificationsTab.xaml
    /// </summary>
    public partial class NotificationsTab : UserControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NotificationsTab()
        {
            InitializeComponent();
            DataContext = new NotificationsTabViewModel();
        }
    }
}
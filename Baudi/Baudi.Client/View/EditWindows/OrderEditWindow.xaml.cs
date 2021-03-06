﻿using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    public partial class OrderEditWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ordersTabViewModel">Orders tabs View model</param>
        /// <param name="order">Order</param>
        public OrderEditWindow(OrdersTabViewModel ordersTabViewModel, Order order)
        {
            InitializeComponent();
            DataContext = new OrderEditWindowViewModel(ordersTabViewModel, this, order);
        }
    }
}
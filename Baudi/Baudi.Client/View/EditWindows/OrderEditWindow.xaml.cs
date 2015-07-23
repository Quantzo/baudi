using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;

namespace Baudi.Client.View.EditWindows
{
    public partial class OrderEditWindow : Window
    {
        public OrderEditWindow(OrdersTabViewModel ordersTabViewModel, Order order)
        {
            InitializeComponent();
            DataContext = new OrderEditWindowViewModel(ordersTabViewModel, this, order);
        }
    }
}
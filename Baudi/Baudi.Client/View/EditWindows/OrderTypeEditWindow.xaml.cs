using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for OrderTypeEditWindow.xaml
    /// </summary>
    public partial class OrderTypeEditWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderTypesTabViewModel">Order types tab view model</param>
        /// <param name="orderType">Order type</param>
        public OrderTypeEditWindow(OrderTypesTabViewModel orderTypesTabViewModel, OrderType orderType)
        {
            InitializeComponent();
            DataContext = new OrderTypeEditWindowViewModel(orderTypesTabViewModel, this, orderType);
        }
    }
}
using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    /// Interaction logic for OrderTypeEditWindow.xaml
    /// </summary>
    public partial class OrderTypeEditWindow : Window
    {
        public OrderTypeEditWindow(OrderTypesTabViewModel orderTypesTabViewModel, OrderType orderType)
        {
            InitializeComponent();
            //DataContext = new OrderTypeEditWindowViewModel(orderTypesTabViewModel, this, orderType);
        }
    }
}

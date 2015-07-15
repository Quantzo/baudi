using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;

namespace Baudi.Client.View.EditWindows
{
    public partial class CyclicOrderEditWindow : Window
    {
        public CyclicOrderEditWindow(CyclicOrdersTabViewModel cyclicOrderTabViewModel, CyclicOrder cyclicOrder)
        {
            InitializeComponent();
            DataContext = new CyclicOrderEditWindowViewModel(cyclicOrderTabViewModel, this, cyclicOrder);
        }
    }
}
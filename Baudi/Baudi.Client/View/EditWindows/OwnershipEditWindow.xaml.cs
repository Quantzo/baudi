using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    /// Interaction logic for OwnershipEditWindow.xaml
    /// </summary>
    public partial class OwnershipEditWindow : Window
    {
        public OwnershipEditWindow(OwnershipsTabViewModel ownershipsTabViewModel, Ownership ownership)
        {
            InitializeComponent();
            DataContext = new OwnershipEditWindowViewModel(ownershipsTabViewModel, this, ownership);
        }
    }
}

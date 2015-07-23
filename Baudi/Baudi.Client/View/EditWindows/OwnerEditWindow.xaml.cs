using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;

namespace Baudi.Client.View.EditWindows
{
    public partial class OwnerEditWindow : Window
    {
        public OwnerEditWindow(OwnersTabViewModel ownersTabViewModel, Owner owner)
        {
            InitializeComponent();
            DataContext = new OwnerEditWindowViewModel(ownersTabViewModel, this, owner);
        }
    }
}
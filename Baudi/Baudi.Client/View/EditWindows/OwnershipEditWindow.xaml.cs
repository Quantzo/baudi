using System.Windows;
using Baudi.Client.ViewModels.EditWindowCode;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for OwnershipEditWindow.xaml
    /// </summary>
    public partial class OwnershipEditWindow : Window
    {
        public OwnershipEditWindow(Ownership selectedOwnership, OwnerEditWindowCode owner)
        {
            InitializeComponent();
            DataContext = new OwnershipEditWindowCode(selectedOwnership, this, owner);
        }
    }
}
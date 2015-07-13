using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.Client.ViewModels.EditWindowCode;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for OwnerEditWindow.xaml
    /// </summary>
    public partial class OwnerEditWindow : Window
    {
        public OwnerEditWindow(Person selectedOwner, MainWindowViewModel owner)
        {
            InitializeComponent();
            DataContext = new OwnerEditWindowCode(selectedOwner, this, owner);
        }
    }
}
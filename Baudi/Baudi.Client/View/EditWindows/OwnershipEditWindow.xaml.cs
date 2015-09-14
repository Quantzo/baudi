using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for OwnershipEditWindow.xaml
    /// </summary>
    public partial class OwnershipEditWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ownershipsTabViewModel">Ownerships tab view model</param>
        /// <param name="ownership">Ownership</param>
        public OwnershipEditWindow(OwnershipsTabViewModel ownershipsTabViewModel, Ownership ownership)
        {
            InitializeComponent();
            DataContext = new OwnershipEditWindowViewModel(ownershipsTabViewModel, this, ownership);
        }
    }
}
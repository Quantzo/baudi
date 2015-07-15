using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.SelectorWindowCode;
using Baudi.DAL.Models;

namespace Baudi.Client.View.SelectorWindow
{
    /// <summary>
    ///     Interaction logic for LocalSelector.xaml
    /// </summary>
    public partial class LocalSelector : Window
    {
        public LocalSelector(OwnershipEditWindowCode owner, Building selectedBuilding)
        {
            InitializeComponent();
            DataContext = new LocalSelectorCode(this, owner, selectedBuilding);
        }
    }
}
using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.SelectorWindowCode;

namespace Baudi.Client.View.SelectorWindow
{
    /// <summary>
    ///     Interaction logic for BuildingSelector.xaml
    /// </summary>
    public partial class BuildingSelector : Window
    {
        public BuildingSelector(OwnershipEditWindowCode owner)
        {
            InitializeComponent();
            DataContext = new BuildingSelectorCode(this, owner);
        }
    }
}
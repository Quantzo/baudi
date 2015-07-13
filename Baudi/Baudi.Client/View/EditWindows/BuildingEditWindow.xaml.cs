using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.Client.ViewModels.EditWindowCode;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for OknoEdycjiBudynku.xaml
    /// </summary>
    public partial class BuildingEditWindow : Window
    {
        public BuildingEditWindow(Building selectedBuilding, MainWindowViewModel owner)
        {
            InitializeComponent();
            DataContext = new BuildingEditWindowCode(selectedBuilding, this, owner);
        }
    }
}
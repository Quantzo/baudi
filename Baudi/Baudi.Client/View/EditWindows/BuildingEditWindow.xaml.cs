using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    public partial class BuildingEditWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="buildingsTabViewModel">Buildings tab view model</param>
        /// <param name="building">Building</param>
        public BuildingEditWindow(BuildingsTabViewModel buildingsTabViewModel, Building building)
        {
            InitializeComponent();
            DataContext = new BuildingEditWindowViewModel(buildingsTabViewModel, this, building);
        }
    }
}
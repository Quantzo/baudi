using Baudi.Client.ViewModels;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUIBD
{
    /// <summary>
    /// Interaction logic for OknoEdycjiBudynku.xaml
    /// </summary>
    public partial class BuildingEditWindow : Window
    {
        public BuildingEditWindow(Building selectedBuilding, MainWindowViewModel owner)
        {
            InitializeComponent();
            this.DataContext = new BuildingEditWindowCode(selectedBuilding, this, owner);
        }
    }
}

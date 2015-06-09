using Baudi.Client.ViewModels;
using Baudi.DAL.Models;
using GUIBD;
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

namespace Baudi.Client.View.SelectorWindow
{
    /// <summary>
    /// Interaction logic for LocalSelector.xaml
    /// </summary>
    public partial class LocalSelector : Window
    {
        public LocalSelector(OwnershipEditWindowCode owner, Building selectedBuilding)
        {
            InitializeComponent();
            this.DataContext = new LocalSelectorCode(this, owner, selectedBuilding);
        }
    }
}

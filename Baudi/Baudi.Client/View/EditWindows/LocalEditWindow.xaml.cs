using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    public partial class LocalEditWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="localsTabViewModel">Locals tab view Model</param>
        /// <param name="local">Local</param>
        public LocalEditWindow(LocalsTabViewModel localsTabViewModel, Local local)
        {
            InitializeComponent();
            DataContext = new LocalEditWindowViewModel(localsTabViewModel, this, local);
        }
    }
}
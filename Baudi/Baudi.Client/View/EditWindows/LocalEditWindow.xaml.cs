using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;

namespace Baudi.Client.View.EditWindows
{
    public partial class LocalEditWindow : Window
    {
        public LocalEditWindow(LocalsTabViewModel localsTabViewModel, Local local)
        {
            InitializeComponent();
            DataContext = new LocalEditWindowViewModel(localsTabViewModel, this, local);
        }
    }
}
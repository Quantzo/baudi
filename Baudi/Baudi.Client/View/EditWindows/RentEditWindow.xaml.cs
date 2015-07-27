using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for RentEditWindow.xaml
    /// </summary>
    public partial class RentEditWindow : Window
    {
        public RentEditWindow(RentsTabViewModel rentsTabViewModel, Rent rent)
        {
            InitializeComponent();
            DataContext = new RentEditWindowViewModel(rentsTabViewModel, this, rent);
        }
    }
}
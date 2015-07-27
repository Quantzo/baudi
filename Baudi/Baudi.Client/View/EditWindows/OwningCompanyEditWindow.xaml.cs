using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for OwningCompanyEditWindow.xaml
    /// </summary>
    public partial class OwningCompanyEditWindow : Window
    {
        public OwningCompanyEditWindow(OwningCompaniesTabViewModel owningCompaniesTabViewModel,
            OwningCompany owningCompany)
        {
            InitializeComponent();
            DataContext = new OwningCompanyEditWindowViewModel(owningCompaniesTabViewModel, this, owningCompany);
        }
    }
}
using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    public partial class CompanyEditWindow : Window
    {
        public CompanyEditWindow(CompaniesTabViewModel companiesTabViewModel, Company company)
        {
            InitializeComponent();
            DataContext = new CompanyEditWindowViewModel(companiesTabViewModel, this, company);
        }
    }
}
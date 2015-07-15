using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.Client.ViewModels.EditWindowCode;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;

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
using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;

namespace Baudi.Client.View.EditWindows
{
    public partial class EmployeeEditWindow : Window
    {
        public EmployeeEditWindow(EmployeesTabViewModel employeesTabViewModel, Employee employee)
        {
            InitializeComponent();
            DataContext = new EmployeeEditWindowViewModel(employeesTabViewModel, this, employee);
        }

    }
}
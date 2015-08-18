using System.Security;
using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    public partial class EmployeeEditWindow : Window
    {
        public EmployeeEditWindow(EmployeesTabViewModel employeesTabViewModel, Employee employee)
        {
            InitializeComponent();
            DataContext = new EmployeeEditWindowViewModel(employeesTabViewModel, this, employee);
        }
        public SecureString Password => PasswordBox.SecurePassword;
    }
}
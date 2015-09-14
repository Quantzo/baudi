using System.Security;
using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    public partial class EmployeeEditWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="employeesTabViewModel">Employee tab view model</param>
        /// <param name="employee">Employee</param>
        public EmployeeEditWindow(EmployeesTabViewModel employeesTabViewModel, Employee employee)
        {
            InitializeComponent();
            DataContext = new EmployeeEditWindowViewModel(employeesTabViewModel, this, employee);
        }
        /// <summary>
        /// Gets password
        /// </summary>
        public SecureString Password
        {
            get { return PasswordBox.SecurePassword; }
        }
    }
}
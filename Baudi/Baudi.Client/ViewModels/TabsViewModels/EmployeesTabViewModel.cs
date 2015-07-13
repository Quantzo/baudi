using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class EmployeesTabViewModel : INotifyPropertyChanged
    {
        public EmployeesTabViewModel()
        {
            Load();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Employee> _employeesList;
        public List<Employee> EmployeesList
        {
            get { return _employeesList; }
            set { _employeesList = value; OnPropertyChanged("EmployeesList"); }
        }

        public Employee SelectedEmployee
        {
            get;
            set;
        }

        public void Load()
        {
            using (var con = new BaudiDbContext())
            {
                _employeesList = con.Employees.ToList();

            }
        }
        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        } 
    }
}

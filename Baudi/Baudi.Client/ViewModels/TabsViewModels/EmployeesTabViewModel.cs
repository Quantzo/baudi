using System;
using System.Collections.Generic;
using System.Linq;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class EmployeesTabViewModel : TabViewModel
    {
        private List<Employee> _employeesList;

        public List<Employee> EmployeesList
        {
            get { return _employeesList; }
            set
            {
                _employeesList = value;
                OnPropertyChanged("EmployeesList");
            }
        }

        public Employee SelectedEmployee { get; set; }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                EmployeesList = con.Employees.ToList();
            }
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }
        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Edit()
        {
            throw new NotImplementedException();
        }

        public override bool IsSomethingSelected()
        {
            if (SelectedEmployee != null)
            {
                return true;
            }
            return false;
        }
    }
}
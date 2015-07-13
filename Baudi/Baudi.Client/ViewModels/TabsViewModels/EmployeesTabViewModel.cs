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
    public class EmployeesTabViewModel :TabViewModel
    {
 
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

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                _employeesList = con.Employees.ToList();

            }
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Update()
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
    }
}

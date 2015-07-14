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
            using (var con = new BaudiDbContext())
            {
                var employee = con.Employees.Find(SelectedEmployee.OwnerID);
                con.Salaries.RemoveRange(employee.Salaries);

                var dispatcher = employee as Dispatcher;
                var menager = employee as Menager;

                employee.Notifications.Clear();
                con.Ownerships.RemoveRange(employee.Ownerships);                

                if (dispatcher != null)
                {
                    dispatcher.DispatcherNotifications.Clear();
                    con.Employees.Remove(dispatcher);
                }
                else if (menager != null)
                {
                    menager.MenagerSalaries.Clear();
                    menager.MenagerExpenses.Clear();
                    menager.CyclicOrders.Clear();
                    menager.Orders.Clear();
                    con.Employees.Remove(menager);
                }
                else
                {
                    con.Employees.Remove(employee);
                }
                con.SaveChanges();
            }
            Update();
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
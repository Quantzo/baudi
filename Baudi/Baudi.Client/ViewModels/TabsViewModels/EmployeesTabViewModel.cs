﻿using System.Collections.Generic;
using System.Linq;
using Baudi.Client.View.EditWindows;
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

        /// <summary>
        /// Load action
        /// </summary>
        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                EmployeesList = con.Employees.ToList();
            }
        }

        /// <summary>
        /// Add action
        /// </summary>
        public override void Add()
        {
            var employeeEditWindow = new EmployeeEditWindow(this, null);
            employeeEditWindow.Show();
        }

        /// <summary>
        /// Delete action
        /// </summary>
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

        /// <summary>
        /// Edit action
        /// </summary>
        public override void Edit()
        {
            var employeeEditWindow = new EmployeeEditWindow(this, SelectedEmployee);
            employeeEditWindow.Show();
        }

        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
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
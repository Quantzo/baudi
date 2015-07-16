using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;
using System.ComponentModel;
using System;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class EmployeeEditWindowViewModel : EditWindowViewModel
    {
        #region Properties

        protected readonly EmployeeRole OrginalRole;

        private EmployeeRole _employeeRole;
        public EmployeeRole EmployeeRole
        {
            get
            {
                return _employeeRole;
            }
            set
            {
                _employeeRole = value;
                OnPropertyChanged("EmployeeRole");
            }
        }

        public IEnumerable<EmployeeRole> EmployeeRoleValues
        {
            get
            {
                return Enum.GetValues(typeof(EmployeeRole))
                    .Cast<EmployeeRole>();
            }
        }



        private Employee _employee;
        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                OnPropertyChanged("Employee");
            }
        }
        #endregion

        public EmployeeEditWindowViewModel(EmployeesTabViewModel employeesTabViewModel, EmployeeEditWindow employeeEditWindow, Employee employee)
            : base(employeesTabViewModel, employeeEditWindow, employee)
        {
            if (Update)
            {
                if(employee as Administrator != null)
                {
                    Employee = new Administrator
                    {
                        OwnerID = employee.OwnerID,
                        Name = employee.Name,
                        Surname= employee.Surname,
                        PESEL = employee.PESEL,
                        Telephone = employee.Telephone,
                        City = employee.City,
                        Street = employee.Street,
                        HouseNumber = employee.HouseNumber,
                        LocalNumber = employee.LocalNumber,
                        BankAccountNumber = employee.BankAccountNumber,
                        Salary = employee.Salary
                    };
                    EmployeeRole = EmployeeRole.Administrator;
                    OrginalRole = EmployeeRole.Administrator;
                }
                else if (employee as Menager != null)
                {
                    Employee = new Menager
                    {
                        OwnerID = employee.OwnerID,
                        Name = employee.Name,
                        Surname= employee.Surname,
                        PESEL = employee.PESEL,
                        Telephone = employee.Telephone,
                        City = employee.City,
                        Street = employee.Street,
                        HouseNumber = employee.HouseNumber,
                        LocalNumber = employee.LocalNumber,
                        BankAccountNumber = employee.BankAccountNumber,
                        Salary = employee.Salary
                    };
                    EmployeeRole = EmployeeRole.Menager;
                    OrginalRole = EmployeeRole.Menager;
                }
                else if (employee as Dispatcher != null)
                {
                    Employee = new Dispatcher
                    {
                        OwnerID = employee.OwnerID,
                        Name = employee.Name,
                        Surname= employee.Surname,
                        PESEL = employee.PESEL,
                        Telephone = employee.Telephone,
                        City = employee.City,
                        Street = employee.Street,
                        HouseNumber = employee.HouseNumber,
                        LocalNumber = employee.LocalNumber,
                        BankAccountNumber = employee.BankAccountNumber,
                        Salary = employee.Salary
                    };
                    EmployeeRole = EmployeeRole.Dispatcher;
                    OrginalRole = EmployeeRole.Dispatcher;
                }
                else
                {
                    Employee = new Employee
                    {
                        OwnerID = employee.OwnerID,
                        Name = employee.Name,
                        Surname = employee.Surname,
                        PESEL = employee.PESEL,
                        Telephone = employee.Telephone,
                        City = employee.City,
                        Street = employee.Street,
                        HouseNumber = employee.HouseNumber,
                        LocalNumber = employee.LocalNumber,
                        BankAccountNumber = employee.BankAccountNumber,
                        Salary = employee.Salary
                    };
                    EmployeeRole = EmployeeRole.Other;
                    OrginalRole = EmployeeRole.Other;
                }
            }
            else
            {
                Employee = new Employee();
            }
        }

        public override void Save()
        {
            if (Update)
            {
                if(OrginalRole != EmployeeRole)
                {
                    using (var con = new BaudiDbContext())
                    {
                        var orginalEmployee = con.Employees.Find(Employee.OwnerID);

                        prepareToChangeEmployeeRole(orginalEmployee);



                        Employee employee = EmployeeFactory();

                        copyEmployeeState(employee);


                        employee.Notifications = orginalEmployee.Notifications;
                        orginalEmployee.Notifications = null;
                        employee.Ownerships = orginalEmployee.Ownerships;
                        orginalEmployee.Ownerships = null;
                        employee.Salaries = orginalEmployee.Salaries;
                        orginalEmployee.Ownerships = null;

                        
                        con.Employees.Remove(orginalEmployee);
                        con.Entry(orginalEmployee).State = EntityState.Deleted;

                        con.Employees.Add(employee);
                        con.SaveChanges();

                    }

                }
                else
                {
                    using (var con = new BaudiDbContext())
                    {
                       
                        var employee = con.Employees.Find(Employee.OwnerID);
                        copyEmployeeState(employee);
                        con.Entry(employee).State = EntityState.Modified;
                        con.SaveChanges();
                    }
                }



            }
            else
            {
                using (var con = new BaudiDbContext())
                {
                    Employee employee = EmployeeFactory();
                    copyEmployeeState(employee);
                    con.Employees.Add(employee);
                    con.SaveChanges();
                }
            }

            ParentViewModel.Update();
            CloseWindow();
        }

        private void prepareToChangeEmployeeRole(DAL.Models.Employee orginalEmployee)
        {
            if (OrginalRole == EmployeeRole.Administrator)
            {
            }
            else if (OrginalRole == EmployeeRole.Menager)
            {
                (orginalEmployee as Menager).CyclicOrders.Clear();
                (orginalEmployee as Menager).MenagerExpenses.Clear();
                (orginalEmployee as Menager).MenagerSalaries.Clear();
                (orginalEmployee as Menager).Orders.Clear();
            }
            else if (OrginalRole == EmployeeRole.Dispatcher)
            {
                (orginalEmployee as Dispatcher).DispatcherNotifications.Clear();
            }
            else
            {
            }
        }

        private void copyEmployeeState(Employee employee)
        {
            employee.Name = Employee.Name;
            employee.Surname = Employee.Surname;
            employee.PESEL = Employee.PESEL;
            employee.Telephone = Employee.Telephone;
            employee.City = Employee.City;
            employee.Street = Employee.Street;
            employee.HouseNumber = Employee.HouseNumber;
            employee.LocalNumber = Employee.LocalNumber;
            employee.BankAccountNumber = Employee.BankAccountNumber;
            employee.Salary = Employee.Salary;
        }

        private DAL.Models.Employee EmployeeFactory()
        {
            Employee employee;

            if (EmployeeRole == EmployeeRole.Administrator)
            {
                employee = new Administrator();
            }
            else if (EmployeeRole == EmployeeRole.Menager)
            {
                employee = new Menager();
            }
            else if (EmployeeRole == EmployeeRole.Dispatcher)
            {
                employee = new Dispatcher();
            }
            else
            {
                employee = new Employee();
            }
            return employee;
        }

        public override bool IsValid()
        {
            return true;
        }


    }

    public enum EmployeeRole
    {
        [Description("Administrator")]
        Administrator,
        [Description("Dispatcher")]
        Dispatcher,
        [Description("Menager")]
        Menager,
        [Description("Inny")]
        Other
    }

    public static class ReflectionHelpers
    {
        public static string GetCustomDescription(object objEnum)
        {
            var fi = objEnum.GetType().GetField(objEnum.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : objEnum.ToString();
        }

        public static string Description(this EmployeeRole value)
        {
            return GetCustomDescription(value);
        }
    }
}
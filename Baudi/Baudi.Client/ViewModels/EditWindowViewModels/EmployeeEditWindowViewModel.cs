using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Security;
using Baudi.Client.Helpers;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class EmployeeEditWindowViewModel : EditWindowViewModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="employeesTabViewModel">Employess tab view model</param>
        /// <param name="employeeEditWindow">Employee edit window</param>
        /// <param name="employee">Employee</param>
        public EmployeeEditWindowViewModel(EmployeesTabViewModel employeesTabViewModel,
            EmployeeEditWindow employeeEditWindow, Employee employee)
            : base(employeesTabViewModel, employeeEditWindow, employee)
        {
            if (Update)
            {
                EditUser = false;
                if (employee is Administrator)
                {
                    Employee = new Administrator
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
                        Salary = employee.Salary,
                        Username = employee.Username
                    };
                    EmployeeRole = EmployeeRole.Administrator;
                    _orginalRole = EmployeeRole.Administrator;
                }
                else if (employee is Menager)
                {
                    Employee = new Menager
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
                        Salary = employee.Salary,
                        Username = employee.Username
                    };
                    EmployeeRole = EmployeeRole.Menager;
                    _orginalRole = EmployeeRole.Menager;
                }
                else if (employee is Dispatcher)
                {
                    Employee = new Dispatcher
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
                        Salary = employee.Salary,
                        Username = employee.Username
                    };
                    EmployeeRole = EmployeeRole.Dispatcher;
                    _orginalRole = EmployeeRole.Dispatcher;
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
                        Salary = employee.Salary,
                        Username = employee.Username
                    };
                    EmployeeRole = EmployeeRole.Other;
                    _orginalRole = EmployeeRole.Other;
                }
            }
            else
            {
                EditUser = true;
                Employee = new Employee();
            }
            using (var con = new BaudiDbContext())
            {
                _currentUserNames = Update ? con.Employees.Where(e => e.OwnerID != employee.OwnerID).Select(e => e.Username).ToList() : con.Employees.Select(e => e.Username).ToList();
            }
        }

        private void PrepareToChangeEmployeeRole(Employee orginalEmployee)
        {
            if (_orginalRole == EmployeeRole.Administrator)
            {
            }
            else if (_orginalRole == EmployeeRole.Menager)
            {
                (orginalEmployee as Menager).CyclicOrders.Clear();
                (orginalEmployee as Menager).MenagerExpenses.Clear();
                (orginalEmployee as Menager).MenagerSalaries.Clear();
                (orginalEmployee as Menager).Orders.Clear();
            }
            else if (_orginalRole == EmployeeRole.Dispatcher)
            {
                (orginalEmployee as Dispatcher).DispatcherNotifications.Clear();
            }
        }

        private void CopyEmployeeState(Employee employee)
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
            employee.Username = Employee.Username;
        }

        private Employee EmployeeFactory()
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

        /// <summary>
        /// Returns if state is valid
        /// </summary>
        /// <returns>Returns if state is valid</returns>
        public override bool IsValid()
        {
            return Update
                ? !CheckIfLoginExist()
                : ((EmployeeEditWindow) EditWindow).Password.Length != 0 && !CheckIfLoginExist();
        }

        private bool CheckIfLoginExist()
        {
            return _currentUserNames.Contains(Employee.Username,StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Adds new item
        /// </summary>
        public override void Add()
        {
            using (var con = new BaudiDbContext())
            {
                var employee = EmployeeFactory();
                CopyEmployeeState(employee);
                employee.PasswordSalt = SecurityHelper.GeneratePasswordSalt();
                employee.Password = SecurityHelper.ComputeHash(employee.PasswordSalt,
                    (EditWindow as EmployeeEditWindow).Password);
                con.Employees.Add(employee);
                con.SaveChanges();
            }
        }

        /// <summary>
        /// Edits item
        /// </summary>
        public override void Edit()
        {
            if (_orginalRole != EmployeeRole)
            {
                using (var con = new BaudiDbContext())
                {
                    var orginalEmployee = con.Employees.Find(Employee.OwnerID);

                    PrepareToChangeEmployeeRole(orginalEmployee);


                    var employee = EmployeeFactory();

                    CopyEmployeeState(employee);


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
                    CopyEmployeeState(employee);
                    con.Entry(employee).State = EntityState.Modified;
                    con.SaveChanges();
                }
            }
        }

        #region Properties

        /// <summary>
        /// Checks if utem is edited
        /// </summary>
        public bool EditUser { get; set; }


        private readonly EmployeeRole _orginalRole;

        private EmployeeRole _employeeRole;

        private readonly List<string> _currentUserNames; 


        public EmployeeRole EmployeeRole
        {
            get { return _employeeRole; }
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
                return Enum.GetValues(typeof (EmployeeRole))
                    .Cast<EmployeeRole>();
            }
        }


        private Employee _employee;

        public Employee Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged("Employee");
            }
        }

        #endregion
    }


    public enum EmployeeRole
    {
        [Description("Administrator")] Administrator,
        [Description("Dyspozytor")] Dispatcher,
        [Description("Menager")] Menager,
        [Description("Inny")] Other
    }

    public static class ReflectionHelpers
    {
        public static string GetCustomDescription(object objEnum)
        {
            var fi = objEnum.GetType().GetField(objEnum.ToString());
            var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof (DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : objEnum.ToString();
        }

        public static string Description(this EmployeeRole value)
        {
            return GetCustomDescription(value);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;


namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class SalaryEditWindowViewModel : EditWindowViewModel
    {
        #region Properties
        private Salary _salary;
        public Salary Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                OnPropertyChanged("Salary");
            }

        }

        private List<Menager> _menagersList;
        public List<Menager> MenagersList
        {
            get
            {
                return _menagersList;
            }

            set
            {
                _menagersList = value;
                OnPropertyChanged("MenagersList");
            }
        }
        private Menager _selectedMenager;
        public Menager SelectedMenager
        {
            get
            {
                return _selectedMenager;
            }
            set
            {
                _selectedMenager = value;
                OnPropertyChanged("SelectedMenager");
            }
        }


        private List<Employee> _employeesList;
        public List<Employee> EmployeesList
        {
            get
            {
                return _employeesList;
            }

            set
            {
                _employeesList = value;
                OnPropertyChanged("EmployeesList");
            }
        }
        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }
            #endregion

            public SalaryEditWindowViewModel(SalariesTabViewModel salaryTabViewModel, SalaryEditWindow salaryEditWindow, Salary salary)
            : base(salaryTabViewModel, salaryEditWindow, salary)
        {

            using (var con = new BaudiDbContext())
            {
                MenagersList = con.Menagers.ToList();
                EmployeesList = con.Employees.ToList();
                if (Update)
                {
                    Salary = con.Salaries.Find(salary.PaymentID);
                    SelectedMenager = Salary.Menager;
                    SelectedEmployee = Salary.Employee;
                }
                else
                {
                    Salary = new Salary();
                }
            }
        }

        public override bool IsValid()
        {
            if(SelectedMenager != null && SelectedEmployee != null)
            {
                return true;
            }
            return false;
        }

        public override void Save()
        {
            if (Update)
            {
                using (var con = new BaudiDbContext())
                {
                    var menager = con.Menagers.Find(SelectedMenager.OwnerID);
                    var employee = con.Employees.Find(SelectedEmployee.OwnerID);



                    var salary = con.Salaries.Find(Salary.PaymentID);

                    salary.Menager = menager;
                    salary.Employee = employee;

                    salary.Date = Salary.Date;
                    salary.Cost = Salary.Cost;
                    salary.Paid = Salary.Paid;


                    con.Entry(salary).State = EntityState.Modified;

                    con.SaveChanges();
                }

            }
            else
            {
                using (var con = new BaudiDbContext())
                {
                    var menager = con.Menagers.Find(SelectedMenager.OwnerID);
                    var employee = con.Employees.Find(SelectedEmployee.OwnerID);

                    Salary.Menager = menager;
                    Salary.Employee = employee;

                    con.Salaries.Add(Salary);
                    con.SaveChanges();
                }
            }
            ParentViewModel.Update();
            CloseWindow();
        }
    }
}

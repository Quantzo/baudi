using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.DAL;
using Baudi.DAL.Models;
using Baudi.Client.View.EditWindows;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class SalariesTabViewModel : TabViewModel
    {
        private List<Salary> _salariesList;

        public List<Salary> SalariesList
        {
            get { return _salariesList; }
            set
            {
                _salariesList = value;
                OnPropertyChanged("SalariesList");
            }
        }

        public Salary SelectedSalary { get; set; }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                SalariesList = con.Salaries
                    .Include(s => s.Employee)
                    .Include(s => s.Menager)
                    .ToList();
            }
        }

        public override void Add()
        {
            var salaryEditWindow = new SalaryEditWindow(this, null);
            salaryEditWindow.Show();
        }

        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var salary = con.Salaries.Find(SelectedSalary.PaymentID);
                salary.Menager = null;
                salary.Employee = null;
                con.Salaries.Remove(salary);
                con.SaveChanges();
            }
            Update();
        }

        public override void Edit()
        {
            var salaryEditWindow = new SalaryEditWindow(this, SelectedSalary);
            salaryEditWindow.Show();
        }

        public override bool IsSomethingSelected()
        {
            if (SelectedSalary != null)
            {
                return true;
            }
            return false;
        }
    }
}
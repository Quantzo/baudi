using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;

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

        /// <summary>
        /// Load action
        /// </summary>
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

        /// <summary>
        /// Add action
        /// </summary>
        public override void Add()
        {
            var salaryEditWindow = new SalaryEditWindow(this, null);
            salaryEditWindow.Show();
        }

        /// <summary>
        /// Delete action
        /// </summary>
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

        /// <summary>
        /// Edit action
        /// </summary>
        public override void Edit()
        {
            var salaryEditWindow = new SalaryEditWindow(this, SelectedSalary);
            salaryEditWindow.Show();
        }

        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
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
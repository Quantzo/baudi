using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            if (SelectedSalary != null)
            {
                return true;
            }
            return false;
        }
    }
}
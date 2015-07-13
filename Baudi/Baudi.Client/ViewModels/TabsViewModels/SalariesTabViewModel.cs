using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class SalariesTabViewModel : INotifyPropertyChanged
    {
        public SalariesTabViewModel()
        {
            Load();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Salary> _salariesList;
        public List<Salary> SalariesList
        {
            get { return _salariesList; }
            set { _salariesList = value; OnPropertyChanged("SalariesList"); }

        }
        public Salary SelectedSalary
        {
            get;
            set;
        }
            public void Load()
        {
            using (var con = new BaudiDbContext())
            {
                _salariesList = con.Salaries
                    .Include(s => s.Employee)
                    .Include(s => s.Menager)
                    .ToList();

            }
        }
            private void OnPropertyChanged(string property)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            } 
    }
}

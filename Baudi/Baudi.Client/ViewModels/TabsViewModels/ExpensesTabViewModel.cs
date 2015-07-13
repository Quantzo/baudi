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
    public class ExpensesTabViewModel : INotifyPropertyChanged
    {
        public ExpensesTabViewModel()
        {
            Load();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Expense> _ExpensesList;
        public List<Expense> ExpensesList
        {
            get { return _ExpensesList; }
            set { _ExpensesList = value; OnPropertyChanged("ExpensesList"); }
        }

        public Expense SelectedExpense
        {
            get;
            set;
        }

        public void Load()
        {
            using (var con = new BaudiDbContext())
            {
                _ExpensesList = con.Expenses
                    .Include(e => e.ExpenseTarget)
                    .Include(e => e.Menager)
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

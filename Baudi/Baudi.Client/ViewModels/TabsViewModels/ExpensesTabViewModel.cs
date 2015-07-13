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
    public class ExpensesTabViewModel :TabViewModel
    {

        private List<Expense> _expensesList;
        public List<Expense> ExpensesList
        {
            get { return _expensesList; }
            set { _expensesList = value; OnPropertyChanged("ExpensesList"); }
        }

        public Expense SelectedExpense
        {
            get;
            set;
        }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                ExpensesList = con.Expenses
                    .Include(e => e.ExpenseTarget)
                    .Include(e => e.Menager)
                    .ToList();

            }
        }


        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Update()
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
            throw new NotImplementedException();
        }
    }
}

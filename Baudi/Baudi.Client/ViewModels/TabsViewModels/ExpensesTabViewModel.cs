using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class ExpensesTabViewModel : TabViewModel
    {
        private List<Expense> _expensesList;

        public List<Expense> ExpensesList
        {
            get { return _expensesList; }
            set
            {
                _expensesList = value;
                OnPropertyChanged("ExpensesList");
            }
        }

        public Expense SelectedExpense { get; set; }

        /// <summary>
        /// Load action
        /// </summary>
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

        /// <summary>
        /// Add action
        /// </summary>
        public override void Add()
        {
            var expenseEditWindow = new ExpenseEditWindow(this, null);
            expenseEditWindow.Show();
        }

        /// <summary>
        /// Delete action
        /// </summary>
        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var expense = con.Expenses.Find(SelectedExpense.PaymentID);
                expense.ExpenseTarget = null;
                expense.Menager = null;
                con.Expenses.Remove(expense);
                con.SaveChanges();
            }
            Update();
        }

        /// <summary>
        /// Edit action
        /// </summary>
        public override void Edit()
        {
            var expenseEditWindow = new ExpenseEditWindow(this, SelectedExpense);
            expenseEditWindow.Show();
        }

        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
        public override bool IsSomethingSelected()
        {
            if (SelectedExpense != null)
            {
                return true;
            }
            return false;
        }
    }
}
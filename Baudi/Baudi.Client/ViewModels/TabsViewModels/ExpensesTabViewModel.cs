using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.DAL;
using Baudi.DAL.Models;
using Baudi.Client.View.EditWindows;

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
            var expenseEditWindow = new ExpenseEditWindow(this, null);
            expenseEditWindow.Show();
        }

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

        public override void Edit()
        {
            var expenseEditWindow = new ExpenseEditWindow(this, SelectedExpense);
            expenseEditWindow.Show();
        }

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
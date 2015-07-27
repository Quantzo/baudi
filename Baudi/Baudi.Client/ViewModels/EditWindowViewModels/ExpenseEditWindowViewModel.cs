using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class ExpenseEditWindowViewModel : EditWindowViewModel
    {
        public ExpenseEditWindowViewModel(ExpensesTabViewModel expensesTabViewModel, ExpenseEditWindow expenseEditWindow,
            Expense expense)
            : base(expensesTabViewModel, expenseEditWindow, expense)
        {
            using (var con = new BaudiDbContext())
            {
                MenagersList = con.Menagers.ToList();
                ExpenseTargetsList = con.ExpenseTargets.ToList();
                if (Update)
                {
                    Expense = con.Expenses.Find(expense.PaymentID);
                    SelectedMenager = Expense.Menager;
                    SelectedExpenseTarget = Expense.ExpenseTarget;
                }
                else
                {
                    Expense = new Expense();
                }
            }
        }

        public override bool IsValid()
        {
            if (SelectedMenager != null && SelectedExpenseTarget != null)
            {
                return true;
            }
            return false;
        }

        public override void Add()
        {
            using (var con = new BaudiDbContext())
            {
                var expenseTarget = con.ExpenseTargets.Find(SelectedExpenseTarget.ExpenseTargetID);
                var menager = con.Menagers.Find(SelectedMenager.OwnerID);

                Expense.ExpenseTarget = expenseTarget;
                Expense.Menager = menager;

                con.Expenses.Add(Expense);
                con.SaveChanges();
            }
        }

        public override void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                var expenseTarget = con.ExpenseTargets.Find(SelectedExpenseTarget.ExpenseTargetID);
                var menager = con.Menagers.Find(SelectedMenager.OwnerID);


                var expense = con.Expenses.Find(Expense.PaymentID);
                expense.ExpenseTarget = expenseTarget;
                expense.Menager = menager;
                expense.Date = Expense.Date;
                expense.Cost = Expense.Cost;
                expense.Paid = Expense.Paid;


                con.Entry(expense).State = EntityState.Modified;

                con.SaveChanges();
            }
        }

        #region Properties

        private Expense _expense;

        public Expense Expense
        {
            get { return _expense; }
            set
            {
                _expense = value;
                OnPropertyChanged("Expense");
            }
        }

        private List<Menager> _menagersList;

        public List<Menager> MenagersList
        {
            get { return _menagersList; }
            set
            {
                _menagersList = value;
                OnPropertyChanged("MenagersList");
            }
        }

        private Menager _selectedMenager;

        public Menager SelectedMenager
        {
            get { return _selectedMenager; }
            set
            {
                _selectedMenager = value;
                OnPropertyChanged("SelectedMenager");
            }
        }

        private List<ExpenseTarget> _expensesTargetsList;

        public List<ExpenseTarget> ExpenseTargetsList
        {
            get { return _expensesTargetsList; }
            set
            {
                _expensesTargetsList = value;
                OnPropertyChanged("ExpenseTargetsList");
            }
        }

        private ExpenseTarget _selectedExpenseTarget;

        public ExpenseTarget SelectedExpenseTarget
        {
            get { return _selectedExpenseTarget; }
            set
            {
                _selectedExpenseTarget = value;
                OnPropertyChanged("SelectedExpenseTarget");
            }
        }

        #endregion
    }
}
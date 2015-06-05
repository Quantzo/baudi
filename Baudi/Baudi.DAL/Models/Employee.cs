using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class Employee : Person, IExpenseTarget
    {
        public string BankAccountNumber { get; set; }
        public double Salary { get; set; }
        public virtual List<Expense> Expenses { get; set; }
    }
}
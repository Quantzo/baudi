using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class Employee : Person, IExpenseTarget
    {
        public int EmployeeID { get; set; }
        public string BankAccountNumber { get; set; }
        public double Salary { get; set; }
        public virtual List<Expense> Expenses { get; set; }

    }
}
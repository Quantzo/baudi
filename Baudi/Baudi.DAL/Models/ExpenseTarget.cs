using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class ExpenseTarget
    {
        public int ExpenseTargetID { get; set; }
        public virtual List<Expense> Expenses { get; set; } 
    }
}
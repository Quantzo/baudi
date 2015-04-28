using System;

namespace BaudiService.Models
{
    public class Expense : Payment
    {
        public int ExpenseID { get; set; }
        public virtual Menager Menager {get; set; }
        public virtual IExpenseTarget ExpenseTarget { get; set; }
    }
}
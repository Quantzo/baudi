using System;

namespace BaudiService.Models
{
    public class Expense : Payment
    {
        public virtual Menager Menager {get; set; }
        public virtual IExpenseTarget ExpenseTarget { get; set; }
    }
}
namespace Baudi.DAL.Models
{
    public class Expense : Payment
    {
        public virtual Menager Menager {get; set; }
        public ExpenseTarget ExpenseTarget { get; set; }
    }
}
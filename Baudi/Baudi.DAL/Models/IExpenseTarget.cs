using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public interface IExpenseTarget
    {
        List<Expense> Expenses { get; set; } 
    }
}
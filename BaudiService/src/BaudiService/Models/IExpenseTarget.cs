using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public interface IExpenseTarget
    {
        List<Expense> Expenses { get; set; } 
    }
}
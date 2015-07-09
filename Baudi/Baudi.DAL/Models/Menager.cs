using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class Menager : Employee
    {
        public virtual List<CyclicOrder> CyclicOrders { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Expense> MenagerExpenses { get; set; }
        public virtual List<Salary> MenagerSalaries { get; set; }
    }
}
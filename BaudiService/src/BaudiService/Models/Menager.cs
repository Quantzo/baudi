using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class Menager : Employee
    {
        public int MenagerID { get; set; }
        public virtual List<CyclicOrder> CyclicOrders { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Expense> MenagerExpenses { get; set; }
    }
}
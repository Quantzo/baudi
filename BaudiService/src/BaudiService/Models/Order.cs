using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class Order : IExpenseTarget
    {
        public int OrderID { get; set; }
        public double Cost { get; set; }
        public string LastChanged { get; set; }
        public string FilingDate { get; set; }
        public OrderStatus Status { get; set; }
        public virtual Company Company { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual Menager Menager { get; set; }
        public virtual Notification Notification { get; set; }
        public virtual List<Expense> Expenses { get; set; }

    }
    public enum OrderStatus
    {

    }
}
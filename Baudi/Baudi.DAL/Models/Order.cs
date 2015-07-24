using System.Collections.Generic;
using System.ComponentModel;

namespace Baudi.DAL.Models
{
    public class Order : ExpenseTarget
    {
        public double Cost { get; set; }
        public string LastChanged { get; set; }
        public string FilingDate { get; set; }
        public OrderStatus Status { get; set; }
        public virtual Company Company { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual Menager Menager { get; set; }
        public virtual Notification Notification { get; set; }


    }
    public enum OrderStatus
    {
        [Description("Przyjęte")]
        Accepted,
        [Description("W trakcie realizacji")]
        InProgress,
        [Description("Odbiór")]
        Validation,
        [Description("Ukończone")]
        Completed
    }
}
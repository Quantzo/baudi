using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Baudi.DAL.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public DateTime LastChanged { get; set; }
        public DateTime FilingDate { get; set; }
        public string Description { get; set; }
        public NotificationStatus Status { get; set; }
        public virtual NotificationTarget NotificationTarget { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Dispatcher Dispatcher { get; set; }
        public virtual List<Order> Orders { get; set; }


    }
    public enum NotificationStatus
    {
        [Description("Przyjęte")]
        Accepted,
        [Description("Odrzucone")]
        Rejected,
        [Description("Do realizacji")]
        Approved,
        [Description("W trakcie realizacji")]
        InProgress,
        [Description("Ukończone")]
        Completed
    }
}


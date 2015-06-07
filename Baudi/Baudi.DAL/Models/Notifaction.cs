﻿using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public string LastChanged { get; set; }
        public string FilingDate { get; set; }
        public string Description { get; set; }
        public NotificationStatus Status { get; set; }
        public virtual INotificationTarget NotificationTarget { get; set; }
        public virtual IOwner Owner { get; set; }
        public virtual Dispatcher Dispatcher { get; set; }
        public virtual List<Order> Orders { get; set; }


    }
    public enum NotificationStatus
    {
        Accepted,
        Rejected,
        Approved,
        InProgress,
        Completed
    }
}

using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class NotificationTarget
    {
        public int NotificationTargetID { get; set; }
        public virtual List<Notification> Notifactions { get; set; }
    }
}
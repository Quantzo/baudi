using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class INotificationTarget
    {
        public int NotificationTargetID { get; set; }
        public virtual List<Notification> Notifactions { get; set; }
    }
}
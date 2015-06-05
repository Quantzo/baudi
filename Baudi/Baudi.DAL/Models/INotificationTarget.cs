using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public interface INotificationTarget
    {      
        List<Notification> Notifactions { get; set; }
    }
}
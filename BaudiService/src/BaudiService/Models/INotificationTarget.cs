using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public interface INotificationTarget
    {      
        List<Notification> Notifactions { get; set; }
    }
}
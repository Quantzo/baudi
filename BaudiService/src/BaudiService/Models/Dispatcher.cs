using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class Dispatcher : Employee
    {
        public int DispatcherID { get; set; }
        public virtual List<Notification> DispatcherNotifications { get; set; }
    }
}
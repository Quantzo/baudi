using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class Dispatcher : Employee
    {
        public virtual List<Notification> DispatcherNotifications { get; set; }
    }
}
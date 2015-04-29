using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class Local : INotificationTarget
    {
        public int LocalID { get; set; }
        public string LocalNumber { get; set; }
        public double RentValue { get; set; }
        public int NumberOfRooms { get; set; }
        public double Area { get; set; }
        public virtual Building Building { get; set; }
        public virtual List<Ownership> Ownerships { get; set; }
        public virtual List<Rent> Rents { get; set; }
        public virtual List<Notification> Notifactions { get; set; }


    }
}
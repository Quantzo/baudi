using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class Owner
    {
        public int OwnerTypeID { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public virtual List<Notification> Notifications { get; set; }
        public virtual List<Ownership> Ownerships { get; set; }
    }
}
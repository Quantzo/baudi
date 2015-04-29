using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class Owner
    {
        public int OwnerID { get; set; }
        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string LocalNumber { get; set; }
        public string OwnerName { get; set; }
        public string NIP { get; set; }
        public string Telephone { get; set; }
        public virtual List<Notification> Notifications { get; set; }
        public virtual List<Ownership> Ownerships { get; set; }
    }
}
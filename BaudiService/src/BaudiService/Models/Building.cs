using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class Building
    {
        public int BuildingID { get; set; }
        public string City { get; set; }
        public string Adres { get; set; }
        public virtual List<Local> Locals { get; set; }
        public virtual List<Notification> Notifactions { get; set; }
        public virtual List<CyclicOrder> CyclicOrders { get; set; }
    }
}
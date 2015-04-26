using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class Building : NotificationTarget
    {
        public int BuildingID { get; set; }
        public string Adres { get; set; }
        public virtual List<Local> Locals { get; set; }
        public virtual List<CyclicOrder> CyclicOrders { get; set; }
    }
}
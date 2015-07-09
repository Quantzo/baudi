using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class Building : NotificationTarget
    {
        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public virtual List<Local> Locals { get; set; }
        public virtual List<CyclicOrder> CyclicOrders { get; set; }

    }
}
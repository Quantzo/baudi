using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class OrderType
    {
        public int OrderTypeID { get; set; }
        public string Name { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Specialization> Specializations { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class Specialization
    {
        public int SpecializationID { get; set; }
        public virtual List<Company> Companies { get; set; }
        public virtual List<OrderType> OrderTypes { get; set; }
    }
}
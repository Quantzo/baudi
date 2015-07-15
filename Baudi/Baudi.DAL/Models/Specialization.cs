using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class Specialization
    {
        public int SpecializationID { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public virtual List<Company> Companies { get; set; }
        public virtual List<OrderType> OrderTypes { get; set; }
    }
}
using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class Ownership
    {
        public int OwnershipID { get; set; }
        public string PurchaseDate { get; set; }
        public string SaleDate { get; set; }
        public virtual IOwner Owner { get; set; }
        public virtual Local Local { get; set; }
        public virtual List<Rent> Rents { get; set; } 
    }
}
using System;
using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class Ownership
    {
        public int OwnershipID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? SaleDate { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Local Local { get; set; }
        public virtual List<Rent> Rents { get; set; } 
    }
}
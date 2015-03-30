using System;

namespace BaudiService.Models
{
    public class Ownership
    {
        public int OwnershipID { get; set; }
        public string PurchaseDate { get; set; }
        public string SaleDate { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Local Local { get; set; }
    }
}
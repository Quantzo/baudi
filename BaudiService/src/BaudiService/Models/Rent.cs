using System;

namespace BaudiService.Models
{
    public class Rent : Payment
    {
        public int RentID { get; set; }
        public virtual Local Local { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class Local
    {
        public int LocalID { get; set; }
        public double Rent { get; set; }
        public int NumberOfRooms { get; set; }
        public double Area { get; set; }
        public virtual Building Building { get; set; }
        public virtual List<Inhabitancy> Inhabitancies { get; set; }
        public virtual List<Ownership> Ownerships { get; set; }
        public virtual List<Payment> Payments { get; set; }

    }
}
using System;

namespace BaudiService.Models
{
    public class CyclicOrder
    {
        public int CyclicOrderID { get; set; }
        public double Cost { get; set; }
        public string Frequency { get; set; }
        public string LastRealizationDate { get; set; }
        public virtual Building Building { get; set; }
        public virtual Menager Menager { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Company Company { get; set; }

    }
}
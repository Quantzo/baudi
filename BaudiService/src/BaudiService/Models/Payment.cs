using System;

namespace BaudiService.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string Date { get; set; }
        public double Cost { get; set; }
        public bool Paid { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual Local Local { get; set; }
        public virtual Order Order { get; set; }
        public virtual CyclicOrder CyclicOrder { get; set; }

    }
}
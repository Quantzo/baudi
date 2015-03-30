using System;

namespace BaudiService.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public double Cost { get; set; }
        public string LastChanged { get; set; }
        public string FilingDate { get; set; }
        public Status Status { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Company Company { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual Menager Menager { get; set; }
        public virtual Notification Notification { get; set; }




    }
}
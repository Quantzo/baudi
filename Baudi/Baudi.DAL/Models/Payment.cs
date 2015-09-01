using System;

namespace Baudi.DAL.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        public bool Paid { get; set; }

    }
}
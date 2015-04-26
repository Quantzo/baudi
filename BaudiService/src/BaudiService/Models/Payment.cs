using System;

namespace BaudiService.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string Date { get; set; }
        public double Cost { get; set; }
        public bool Paid { get; set; }

    }
}
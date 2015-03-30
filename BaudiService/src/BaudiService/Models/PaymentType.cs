using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class PaymentType
    {
        public int PaymentTypeID { get; set; }
        public string Name { get; set; }
        public virtual List<Payment> Payments { get; set; }
    }
}
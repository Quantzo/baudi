﻿using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string LocalNumber { get; set; }
        public string NIP { get; set; }
        public string TelephoneNumber { get; set; }
        public string Owner { get; set; }
        public virtual List<CyclicOrder> CyclicOrders { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Specialization> Specializations { get; set; }
    }
}
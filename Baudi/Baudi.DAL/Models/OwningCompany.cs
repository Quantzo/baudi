using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class OwningCompany : Owner
    {

        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string LocalNumber { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string Telephone { get; set; }      


    }
}
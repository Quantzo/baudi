using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class Person : IOwner
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PESEL { get; set; }
        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string LocalNumber { get; set; }
        public string Telephone { get; set; }

    }
}
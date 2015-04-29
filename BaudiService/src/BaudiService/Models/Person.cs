using System;
using System.Collections.Generic;

namespace BaudiService.Models
{
    public class Person : Owner
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PESEL { get; set; }
        
    }
}
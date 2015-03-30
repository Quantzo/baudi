using System;

namespace BaudiService.Models
{
    public class Employee : Person
    {
        public int EmployeeID { get; set; }
        public string City { get; set; }
        public string Adres { get; set; }
        public string BankAccountNumber { get; set; }

    }
}
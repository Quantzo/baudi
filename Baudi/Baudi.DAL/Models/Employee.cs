using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class Employee : Person
    {
        public string BankAccountNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public double Salary { get; set; }
        public virtual List<Salary> Salaries { get; set; }
    }
}
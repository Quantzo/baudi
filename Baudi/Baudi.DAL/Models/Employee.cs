using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class Employee : Person
    {
        public string BankAccountNumber { get; set; }
        public double Salary { get; set; }
        public virtual List<Salary> Salaries { get; set; }
    }
}
using Baudi.Client.Helpers;
using Baudi.DAL.Models;

namespace Baudi.Client.Reports.SalaryReport
{
    internal class SalaryTableRow : TableRow
    {
        public string EmployeeName { get; set; }
        public string BankAccount { get; set; }
        public string ResposiblePerson { get; set; }

        public SalaryTableRow(Salary salary) : base(salary)
        {
            EmployeeName = FullNameHelper.ToFullName(salary.Employee.Name, salary.Employee.Surname);
            BankAccount = salary.Employee.BankAccountNumber;
            ResposiblePerson = FullNameHelper.ToFullName(salary.Menager.Name, salary.Menager.Surname);
        }
    }
}
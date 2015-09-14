using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baudi.Client.Helpers;
using Baudi.DAL.Models;

namespace Baudi.Client.Reports.BuildingReport.ExpenseReport
{
    internal class ExpenseTableRow : TableRow
    {
        public string ResposiblePerson { get; set; }
        public ExpenseTableRow(Expense expense) : base(expense)
        {
            ResposiblePerson = FullNameHelper.ToFullName(expense.Menager.Name, expense.Menager.Surname);
        }
    }
}

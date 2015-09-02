using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Baudi.Client.Helpers;
using Baudi.DAL.Models;

namespace Baudi.Client.Reports.BuildingReport.ExpenseReport
{
    public class ExpenseTable
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Cost { get; set; }
        public string ResposiblePerson { get; set; }
        public List<ExpenseTableRow> TableRows { get; set; } 

        public ExpenseTable(CyclicOrder cyclicOrder, DateTime dateFrom, DateTime dateTo)
        {
            TableRows = new List<ExpenseTableRow>();
            CompanyName = cyclicOrder.Company.Name;
            Description = cyclicOrder.Description;
            Cost = cyclicOrder.Cost.ToString(CultureInfo.CurrentCulture);
            ResposiblePerson = FullNameHelper.ToFullName(cyclicOrder.Menager.Name, cyclicOrder.Menager.Surname);

            var expenses = cyclicOrder.Expenses.Where(e => e.Date >= dateFrom && e.Date <= dateTo);

            foreach (var expense in expenses)
            {
                TableRows.Add(new ExpenseTableRow(expense));
            }

        }
        public ExpenseTable(Order order,DateTime dateFrom, DateTime dateTo)
        {
            TableRows = new List<ExpenseTableRow>();
            CompanyName = order.Company.Name;
            Description = order.Description;
            Cost = order.Cost.ToString(CultureInfo.CurrentCulture);
            ResposiblePerson = FullNameHelper.ToFullName(order.Menager.Name, order.Menager.Surname);

            var expenses = order.Expenses.Where(e => e.Date >= dateFrom && e.Date <= dateTo);

            foreach (var expense in expenses)
            {
                TableRows.Add(new ExpenseTableRow(expense));
            }
        }

    }
}
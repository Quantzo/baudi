using System;
using System.Collections.Generic;

namespace Baudi.Client.Reports
{
    public class SalaryReport : Report
    {
        private List<SalaryTableRow> SalaryTableRows { get; set; } 
        public SalaryReport(DateTime dateFrom, DateTime dateTo) : base(dateFrom, dateTo)
        {
        }

        public override void PrintPdf()
        {
            throw new NotImplementedException();
        }

        public override void LoadData()
        {
            throw new NotImplementedException();
        }
    }
}
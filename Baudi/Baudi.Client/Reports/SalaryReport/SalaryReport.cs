using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Baudi.Client.Reports.SalaryReport
{
    public class SalaryReport : Report
    {
        private List<SalaryTableRow> SalaryTableRows { get; set; } 
        public SalaryReport(DateTime dateFrom, DateTime dateTo, string path) : base(dateFrom, dateTo, path)
        {
            SalaryTableRows = new List<SalaryTableRow>();
        }

        protected override void ConvertDataToPdf(Document document)
        {
            document.Add(new Paragraph("Pensje w okresie od "+ DateFrom.ToLongDateString()+" do "+DateTo.ToLongDateString()));

            PdfPTable table = new PdfPTable(6);

            table.AddCell("Pracownik");
            table.AddCell("Konto bankowe");
            table.AddCell("Kwota");
            table.AddCell("Data");
            table.AddCell("Uregulowane");
            table.AddCell("Odpowiedzialny");

            SalaryTableRows.ForEach(s => AddRow(table, s));

            document.Add(table);
        }

        protected override void FindData(BaudiDbContext con)
        {
            var salaries = con.Salaries.Where(s => (s.Date >= DateFrom && s.Date <= DateFrom)).Include(s => s.Employee).Include(s => s.Menager).ToList();
            salaries.ForEach(s => SalaryTableRows.Add(new SalaryTableRow(s)));
        }


        private void AddRow(PdfPTable table, SalaryTableRow dataRow)
        {
            table.AddCell(dataRow.EmployeeName);
            table.AddCell(dataRow.BankAccount);
            table.AddCell(dataRow.Cost);
            table.AddCell(dataRow.Date);
            table.AddCell(dataRow.Paid);
            table.AddCell(dataRow.ResposiblePerson);
        }


        
    }
}
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
            document.Add(new Paragraph("Pensje w okresie od "+ DateFrom.ToLongDateString()+" do "+DateTo.ToLongDateString(), FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));

            PdfPTable table = new PdfPTable(6);
            table.SpacingBefore = 10;

            table.AddCell(new Paragraph("Pracownik", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph("Konto bankowe", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph("Kwota", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph("Data", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph("Uregulowane", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph("Odpowiedzialny", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));

            SalaryTableRows.ForEach(s => AddRow(table, s));

            document.Add(table);
        }

        protected override void FindData(BaudiDbContext con)
        {
            var salaries = con.Salaries.Where(s => (s.Date >= DateFrom && s.Date <= DateTo)).Include(s => s.Employee).Include(s => s.Menager).ToList();
            salaries.ForEach(s => SalaryTableRows.Add(new SalaryTableRow(s)));
        }


        private void AddRow(PdfPTable table, SalaryTableRow dataRow)
        {
            table.AddCell(new Paragraph(dataRow.EmployeeName, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph(dataRow.BankAccount, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph(dataRow.Cost, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph(dataRow.Date, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph(dataRow.Paid, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph(dataRow.ResposiblePerson, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
        }


        
    }
}
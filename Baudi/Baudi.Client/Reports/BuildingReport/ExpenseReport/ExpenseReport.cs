using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baudi.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Baudi.Client.Reports.BuildingReport.ExpenseReport
{
    public class ExpenseReport : BuildingReport
    {
        private List<ExpenseTable> ExpenseTables { get; set; }  
        public ExpenseReport(DateTime dateFrom, DateTime dateTo, string path, int buildingId) : base(dateFrom, dateTo, path, buildingId)
        {
            ExpenseTables = new List<ExpenseTable>();
        }

        private void GenateExpenseTable(Document document, ExpenseTable expenseTable)
        {
            

            document.Add(new Paragraph("Wykaz wydatkow dla zlecenia: " + expenseTable.Description, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            document.Add(new Paragraph("Firma odpowiedzialna za realizację: " + expenseTable.CompanyName, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            document.Add(new Paragraph("Przewidywany koszt: " + expenseTable.Cost, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            document.Add(new Paragraph("Osoba odpowiedzialna: " + expenseTable.ResposiblePerson, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));

            var table = new PdfPTable(4) {SpacingBefore = 10};

            table.AddCell(new Paragraph("Kwota", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph("Data", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph("Uregulowane", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph("Osoba odpowiedzialna", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));

            expenseTable.TableRows.ForEach(r => AddRow(table, r));
            document.Add(table);
        }

        protected override void ConvertDataToPdf(Document document)
        {
            document.Add(new Paragraph("Wykaz dla budynku " + BuildingId, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));

            document.Add(new Paragraph("Wydatki w okresie od " + DateFrom.ToLongDateString() + " do " + DateTo.ToLongDateString(), FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));

            ExpenseTables.ForEach(et => GenateExpenseTable(document,et));
        }

        protected override void FindData(BaudiDbContext con)
        {
            var allCyclicOrders = con.Buildings.Find(BuildingId).CyclicOrders.Where(c => c.Expenses.Any( e => e.Date >= DateFrom && e.Date <= DateTo));
            var allOrders = con.Orders.Where(
                o => (o.Notification.NotificationTarget.NotificationTargetID == BuildingId 
                || con.Locals.Where(l => l.Building.NotificationTargetID == BuildingId).Select(l => l.NotificationTargetID).Contains(o.Notification.NotificationTarget.NotificationTargetID)) 
                && o.Expenses.Any(e => e.Date >= DateFrom && e.Date <= DateTo));

            foreach (var cyclicOrder in allCyclicOrders)
            {
                ExpenseTables.Add(new ExpenseTable(cyclicOrder, DateFrom, DateTo));
            }
            foreach (var order in allOrders)
            {
                ExpenseTables.Add(new ExpenseTable(order, DateFrom, DateTo));
            }

        }

        private void AddRow(PdfPTable table, ExpenseTableRow dataRow)
        {
            table.AddCell(new Paragraph(dataRow.Cost, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph(dataRow.Date, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph(dataRow.Paid, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph(dataRow.ResposiblePerson, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
        }



    }
}

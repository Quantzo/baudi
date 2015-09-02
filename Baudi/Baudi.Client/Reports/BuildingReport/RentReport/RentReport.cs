using System;
using System.Collections.Generic;
using System.Linq;
using Baudi.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Baudi.Client.Reports.BuildingReport.RentReport
{
    public class RentReport : BuildingReport
    {
        private List<RentTable> RentTables { get; set; }

        public RentReport(DateTime dateFrom, DateTime dateTo, string path, int buildingId) : base(dateFrom, dateTo, path, buildingId)
        {
        }

        private void GenerateRentTable(Document document, RentTable rentTable)
        {
            document.Add(new Paragraph("Wykaz czynszów dla " + rentTable.Owner));

            PdfPTable table = new PdfPTable(6);

            table.AddCell("ID lokalu");
            table.AddCell("ID Posiadania");
            table.AddCell("Kwota");
            table.AddCell("Data");
            table.AddCell("Uregulowane");
            table.AddCell("Numer lokalu");

            rentTable.TableRows.ForEach(r => AddRow(table, r));

            document.Add(table);

        }

        protected override void ConvertDataToPdf(Document document)
        {
            document.Add(new Paragraph("Wykaz dla budynku " + BuildingId));

            document.Add(new Paragraph("Czynsz w okresie od " + DateFrom.ToLongDateString() + " do " + DateTo.ToLongDateString()));
            
            RentTables.ForEach(rt => GenerateRentTable(document,rt));
            
        }

        protected override void FindData(BaudiDbContext con)
        {
            var groupedRents = con.Rents
                .Where(s =>(s.Ownership.Local.Building.NotificationTargetID == BuildingId) && (s.Date >= DateFrom && s.Date <= DateTo))
                .GroupBy(r => r.Ownership.Owner);
            foreach (var group in groupedRents)
            {
                RentTables.Add(new RentTable(group));
            }
        }

        private void AddRow(PdfPTable table, RentTableRow dataRow)
        {
            table.AddCell(dataRow.LocalId);
            table.AddCell(dataRow.OwnershipId);
            table.AddCell(dataRow.Cost);
            table.AddCell(dataRow.Date);
            table.AddCell(dataRow.Paid);
            table.AddCell(dataRow.LocalNumber);
        }


    }
}

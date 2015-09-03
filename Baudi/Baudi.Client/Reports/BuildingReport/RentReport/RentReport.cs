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
            RentTables = new List<RentTable>();
        }

        private void GenerateRentTable(Document document, RentTable rentTable)
        {
            document.Add(new Paragraph("Wykaz czynszów dla " + rentTable.Owner, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));

            PdfPTable table = new PdfPTable(6) {SpacingBefore = 10};


            table.AddCell(new Paragraph("ID lokalu", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph("ID Posiadania", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph("Kwota", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph("Data", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph("Uregulowane", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph("Numer lokalu", FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));

            rentTable.TableRows.ForEach(r => AddRow(table, r));

            document.Add(table);

        }

        protected override void ConvertDataToPdf(Document document)
        {
            document.Add(new Paragraph("Wykaz dla budynku " + BuildingId, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));

            document.Add(new Paragraph("Czynsz w okresie od " + DateFrom.ToLongDateString() + " do " + DateTo.ToLongDateString(), FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            
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
            table.AddCell(new Paragraph(dataRow.LocalId, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph(dataRow.OwnershipId, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph(dataRow.Cost, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph(dataRow.Date, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph(dataRow.Paid, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
            table.AddCell(new Paragraph(dataRow.LocalNumber, FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10)));
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baudi.DAL;
using iTextSharp.text;

namespace Baudi.Client.Reports
{
    public class RentReport : Report
    {
        private List<RentTable> RentTables { get; set; }
        public RentReport(DateTime dateFrom, DateTime dateTo, string path) : base(dateFrom, dateTo, path)
        {
        }

        protected override void ConvertDataToPdf(Document document)
        {
            throw new NotImplementedException();
        }

        protected override void FindData(BaudiDbContext con)
        {
            var groupedRents = con.Rents.Where(s => (s.Date >= DateFrom && s.Date <= DateFrom)).GroupBy(r => r.Ownership.Owner).ToList();
            groupedRents.ForEach(g => RentTables.Add( new RentTable(g)) );
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Baudi.Client.Helpers;
using Baudi.DAL.Models;

namespace Baudi.Client.Reports.BuildingReport.RentReport
{
    public class RentTable
    {
        public string Owner { get; set; }
        public List<RentTableRow> TableRows { get; set; }
        public RentTable(IGrouping<Owner, Rent> group)
        {
            if (group.Key is OwningCompany)
            {
                Owner = ((OwningCompany)@group.Key).Name + " " + ((OwningCompany)@group.Key).NIP;
            }
            else if (group.Key is Person)
            {
                Owner = FullNameHelper.ToFullName(((Person) @group.Key).Name, ((Person) @group.Key).Surname);
            }
            TableRows = new List<RentTableRow>();
            foreach (var item in group)
            {
                TableRows.Add(new RentTableRow(item));
            }

        }
    }
}

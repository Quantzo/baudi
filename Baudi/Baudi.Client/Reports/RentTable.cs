using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baudi.DAL.Models;

namespace Baudi.Client.Reports
{
    public class RentTable
    {
        public string Owner { get; set; }
        public List<RentTableRow> TableRows { get; set; }
        public RentTable(IGrouping<Owner, Rent> group)
        {
            
        }
    }
}

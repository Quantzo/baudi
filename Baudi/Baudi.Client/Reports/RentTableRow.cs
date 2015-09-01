using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baudi.DAL.Models;

namespace Baudi.Client.Reports
{
    public class RentTableRow : TableRow
    {
        public string OwnershipId { get; set; }
        public string LocalId { get; set; }

        public RentTableRow(Rent rent) : base(rent)
        {

        }
    }
}

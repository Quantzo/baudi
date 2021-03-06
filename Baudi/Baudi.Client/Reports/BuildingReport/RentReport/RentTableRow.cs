﻿using Baudi.DAL.Models;

namespace Baudi.Client.Reports.BuildingReport.RentReport
{
    public class RentTableRow : TableRow
    {
        public string OwnershipId { get; set; }
        public string LocalId { get; set; }
        public string LocalNumber { get; set; }

        public RentTableRow(Rent rent) : base(rent)
        {
            OwnershipId = rent.Ownership.OwnershipID.ToString();
            LocalId = rent.Ownership.Local.NotificationTargetID.ToString();
            LocalNumber = rent.Ownership.Local.LocalNumber;
        }
    }
}

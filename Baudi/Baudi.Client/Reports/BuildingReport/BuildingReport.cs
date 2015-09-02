using System;

namespace Baudi.Client.Reports.BuildingReport
{
    public abstract class BuildingReport : Report
    {
        protected int BuildingId { get; set; }

        public BuildingReport(DateTime dateFrom, DateTime dateTo, string path, int buildingId) : base(dateFrom, dateTo, path)
        {
            BuildingId = buildingId;
        }
    }
}

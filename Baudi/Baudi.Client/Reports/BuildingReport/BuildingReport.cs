using System;

namespace Baudi.Client.Reports.BuildingReport
{
    /// <summary>
    /// Abstract class for building report
    /// </summary>
    public abstract class BuildingReport : Report
    {
        /// <summary>
        /// Building Id
        /// </summary>
        protected int BuildingId { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dateFrom">Date from</param>
        /// <param name="dateTo">Date to</param>
        /// <param name="path">Path to save</param>
        /// <param name="buildingId">Building id in database</param>
        protected BuildingReport(DateTime dateFrom, DateTime dateTo, string path, int buildingId) : base(dateFrom, dateTo, path)
        {
            BuildingId = buildingId;
        }
    }
}

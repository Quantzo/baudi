using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baudi.DAL.Models;

namespace Baudi.Client.Reports
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

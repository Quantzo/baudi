using System;

namespace Baudi.Client.Reports
{
    public abstract class Report
    {
        #region Properties
        protected DateTime DateFrom { get; set; }
        protected  DateTime DateTo { get; set; }

        #endregion

        public Report(DateTime dateFrom, DateTime dateTo)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        public abstract void PrintPdf();
        public abstract void LoadData();


    }
}
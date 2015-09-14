using System;
using System.IO;
using Baudi.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Baudi.Client.Reports
{
    /// <summary>
    /// Abstract class for report
    /// </summary>
    public abstract class Report
    {
        #region Properties
        /// <summary>
        /// Date from
        /// </summary>
        protected DateTime DateFrom { get; set; }
        /// <summary>
        /// Date to
        /// </summary>
        protected  DateTime DateTo { get; set; }
        private string Path { get; set; }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dateFrom">Date from</param>
        /// <param name="dateTo">Date to</param>
        /// <param name="path">Path to save</param>
        public Report(DateTime dateFrom, DateTime dateTo, string path)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
            Path = path;
        }

        /// <summary>
        /// Converts data to pdf
        /// </summary>
        /// <param name="document">Pdf document</param>
        protected abstract void ConvertDataToPdf(Document document);


        /// <summary>
        /// Generate pdf
        /// </summary>
        public void PrintPdf()
        {
            var document = new Document();
            var output = new FileStream(Path, FileMode.Create);
            var writer = PdfWriter.GetInstance(document, output);
            document.Open();
            ConvertDataToPdf(document);
            document.Close();
        }

        /// <summary>
        /// Load data from database
        /// </summary>
        public void LoadData()
        {
            using (var con = new BaudiDbContext())
            {
                FindData(con);
            }
        }

        /// <summary>
        /// Find data in database
        /// </summary>
        /// <param name="con">data context</param>
        protected abstract void FindData(BaudiDbContext con);


    }
}
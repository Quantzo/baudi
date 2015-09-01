using System;
using System.IO;
using Baudi.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Baudi.Client.Reports
{
    public abstract class Report
    {
        #region Properties
        protected DateTime DateFrom { get; set; }
        protected  DateTime DateTo { get; set; }
        private string Path { get; set; }

        #endregion

        public Report(DateTime dateFrom, DateTime dateTo, string path)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
            Path = path;
        }

        protected abstract void ConvertDataToPdf(Document document);


        public void PrintPdf()
        {
            var document = new Document();
            var output = new FileStream(Path, FileMode.Create);
            var writer = PdfWriter.GetInstance(document, output);
            document.Open();
            ConvertDataToPdf(document);
            document.Close();
        }

        public void LoadData()
        {
            using (var con = new BaudiDbContext())
            {
                FindData(con);
            }
        }

        protected abstract void FindData(BaudiDbContext con);


    }
}
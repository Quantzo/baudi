using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baudi.DAL.Models;

namespace Baudi.Client.Reports
{
    public abstract class TableRow
    {
        public string Date { get; set; }
        public string Cost { get; set; }
        public string Paid { get; set; }

        protected TableRow(Payment payment)
        {
            Date = payment.Date.ToLongDateString();
            Paid = payment.Paid ? "Tak" : "Nie";
            Cost = payment.Cost.ToString(CultureInfo.CurrentCulture);
        }
    }
}

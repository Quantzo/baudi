using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baudi.DAL.Models;

namespace Baudi.Client.Reports
{
    /// <summary>
    /// Table row for expense
    /// </summary>
    public abstract class TableRow
    {
        /// <summary>
        /// Date
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Cost
        /// </summary>
        public string Cost { get; set; }
        /// <summary>
        /// Paid
        /// </summary>
        public string Paid { get; set; }

        /// <summary>
        /// Load data form payment instance
        /// </summary>
        /// <param name="payment"></param>
        protected TableRow(Payment payment)
        {
            Date = payment.Date.ToLongDateString();
            Paid = payment.Paid ? "Tak" : "Nie";
            Cost = payment.Cost.ToString(CultureInfo.CurrentCulture);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.DAL.Models
{
    public class Salary : Payment
    {
        public virtual Menager Menager { get; set; }
        public virtual Employee Employee { get; set; }
    }
}

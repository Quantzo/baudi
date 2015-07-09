using System.Collections.Generic;

namespace Baudi.DAL.Models
{
    public class CyclicOrder : IExpenseTarget
    {
        public double Cost { get; set; }
        public string Frequency { get; set; }
        public string LastRealizationDate { get; set; }
        public virtual Building Building { get; set; }
        public virtual Menager Menager { get; set; }        
        public virtual Company Company { get; set; }

    }
}
using System;

namespace BaudiService.Models
{
    public class Inhabitancy
    {
        public int InhabitancyID { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public virtual Person Person { get; set; }
        public virtual Local Local { get; set; }
    }
}
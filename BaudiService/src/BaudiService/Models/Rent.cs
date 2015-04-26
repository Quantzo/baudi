using System;

namespace BaudiService.Models
{
    public class Rent : Payment
    {
        public virtual Local Local { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.DAL.Models
{
    public class IOwner
    {
        public int OwnerID { get; set; }
        public virtual List<Notification> Notifications { get; set; }
        public virtual List<Ownership> Ownerships { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.DAL.Models
{
    public interface IOwner
    {
        List<Notification> Notifications { get; set; }
        List<Ownership> Ownerships { get; set; }
    }
}

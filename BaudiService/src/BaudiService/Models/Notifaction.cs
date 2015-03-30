using System;

namespace BaudiService.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public string LastChanged { get; set; }
        public string FilingDate { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public virtual Building Building { get; set; }
        public virtual Local Local { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Dispatcher Dispatcher { get; set; }


}
    public enum Status
    {

    }
}


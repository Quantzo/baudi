using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class NotificationsTabViewModel :TabViewModel
    {

        private List<Notification> _notificationsList;
        public List<Notification> NotificationsList
        {
            get { return _notificationsList; }
            set { _notificationsList = value; OnPropertyChanged("NotificationsList"); }
        }
        public Notification SelectedNotification { get; set; }
        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                _notificationsList = con.Notifications.Include(n => n.Dispatcher).ToList();

            }
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Edit()
        {
            throw new NotImplementedException();
        }
    }
}

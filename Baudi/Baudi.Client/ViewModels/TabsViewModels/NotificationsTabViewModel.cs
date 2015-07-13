using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class NotificationsTabViewModel : TabViewModel
    {
        private List<Notification> _notificationsList;

        public List<Notification> NotificationsList
        {
            get { return _notificationsList; }
            set
            {
                _notificationsList = value;
                OnPropertyChanged("NotificationsList");
            }
        }

        public Notification SelectedNotification { get; set; }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                NotificationsList = con.Notifications.Include(n => n.Dispatcher).ToList();
            }
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            Load();
        }

        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var notification = con.Notifications.Find(SelectedNotification.NotificationID);
                con.Orders.RemoveRange(notification.Orders);
                con.Notifications.Remove(notification);
                con.SaveChanges();
            }
            Update();
        }

        public override void Edit()
        {
            throw new NotImplementedException();
        }

        public override bool IsSomethingSelected()
        {
            if (SelectedNotification != null)
            {
                return true;
            }
            return false;
        }
    }
}
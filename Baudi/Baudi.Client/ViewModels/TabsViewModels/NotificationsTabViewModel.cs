using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
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

        /// <summary>
        /// Load action
        /// </summary>
        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                NotificationsList = con.Notifications.Include(n => n.Dispatcher).ToList();
            }
        }

        /// <summary>
        /// Add action
        /// </summary>
        public override void Add()
        {
            var notificationEditWindow = new NotificationEditWindow(this, null);
            notificationEditWindow.Show();
        }

        /// <summary>
        /// Delete action
        /// </summary>
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

        /// <summary>
        /// Edit action
        /// </summary>
        public override void Edit()
        {
            var notificationEditWindow = new NotificationEditWindow(this, SelectedNotification);
            notificationEditWindow.Show();
        }

        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
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
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
    public class NotificationsTabViewModel : INotifyPropertyChanged
    {
        public NotificationsTabViewModel()
        {
            Load();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Notification> _notificationsList;
        public List<Notification> NotificationsList
        {
            get { return _notificationsList; }
            set { _notificationsList = value; OnPropertyChanged("NotificationsList"); }
        }
        public Notification SelectedNotification { get; set; }
        public void Load()
        {
            using (var con = new BaudiDbContext())
            {
                _notificationsList = con.Notifications.Include(n => n.Dispatcher).ToList();

            }
        }
        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        } 


    }
}

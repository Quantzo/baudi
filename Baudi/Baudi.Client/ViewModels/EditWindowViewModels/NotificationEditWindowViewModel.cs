using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class NotificationEditWindowViewModel : EditWindowViewModel
    {
        public NotificationEditWindowViewModel(NotificationsTabViewModel notificationTabViewModel,
            NotificationEditWindow notificationEditWindow, Notification notification)
            : base(notificationTabViewModel, notificationEditWindow, notification)
        {
            using (var con = new BaudiDbContext())
            {
                NotificationTargetsList = con.NotificationTargets.ToList();
                OwnersList = con.Owners.ToList();
                DispatchersList = con.Dispatchers.ToList();
                if (Update)
                {
                    Notification = con.Notifications.Find(notification.NotificationID);
                    SelectedNotificationStatus = Notification.Status;
                    SelectedNotificationTarget = Notification.NotificationTarget;
                    SelectedOwner = Notification.Owner;
                    SelectedDispatcher = Notification.Dispatcher;
                }
                else
                {
                    Notification = new Notification();
                    Notification.FilingDate = DateTime.Now;
                    Notification.LastChanged = DateTime.Now;
                   
                }
            }
        }

        /// <summary>
        /// Returns if state is valid
        /// </summary>
        /// <returns>Returns if state is valid</returns>
        public override bool IsValid()
        {
            if (SelectedNotificationTarget != null && SelectedOwner != null && SelectedDispatcher != null)
                return true;
            return false;
        }

        /// <summary>
        /// Adds new item
        /// </summary>
        public override void Add()
        {
            using (var con = new BaudiDbContext())
            {
                var notificationTarget = con.NotificationTargets.Find(SelectedNotificationTarget.NotificationTargetID);
                var owner = con.Owners.Find(SelectedOwner.OwnerID);
                var dispatcher = con.Dispatchers.Find(SelectedDispatcher.OwnerID);

                Notification.NotificationTarget = notificationTarget;
                Notification.Owner = owner;
                Notification.Dispatcher = dispatcher;

                con.Notifications.Add(Notification);
                con.SaveChanges();
            }
        }

        /// <summary>
        /// Edits item
        /// </summary>
        public override void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                var notificationTarget = con.NotificationTargets.Find(SelectedNotificationTarget.NotificationTargetID);
                var owner = con.Owners.Find(SelectedOwner.OwnerID);
                var dispatcher = con.Dispatchers.Find(SelectedDispatcher.OwnerID);


                var notification = con.Notifications.Find(Notification.NotificationID);
                notification.Description = Notification.Description;
                notification.Dispatcher = dispatcher;
                notification.FilingDate = Notification.FilingDate;
                notification.LastChanged = Notification.LastChanged;
                notification.NotificationTarget = notificationTarget;
                notification.Owner = owner;
                notification.Status = SelectedNotificationStatus;


                con.Entry(notification).State = EntityState.Modified;

                con.SaveChanges();
            }
        }

        #region Properties

        private Notification _notification;

        public Notification Notification
        {
            get { return _notification; }
            set
            {
                _notification = value;
                OnPropertyChanged("Notification");
            }
        }


        public IEnumerable<NotificationStatus> NotificationStatus
        {
            get
            {
                return Enum.GetValues(typeof (NotificationStatus))
                    .Cast<NotificationStatus>();
            }
        }

        private NotificationStatus _selectedNotificationStatus;

        public NotificationStatus SelectedNotificationStatus
        {
            get { return _selectedNotificationStatus; }
            set
            {
                _selectedNotificationStatus = value;
                OnPropertyChanged("SelectedNotificationStatus");
            }
        }

        private List<NotificationTarget> _notificationTargetsList;

        public List<NotificationTarget> NotificationTargetsList
        {
            get { return _notificationTargetsList; }
            set
            {
                _notificationTargetsList = value;
                OnPropertyChanged("NotificationTargetsList");
            }
        }

        private NotificationTarget _selectedNotificationTarget;

        public NotificationTarget SelectedNotificationTarget
        {
            get { return _selectedNotificationTarget; }
            set
            {
                _selectedNotificationTarget = value;
                OnPropertyChanged("SelectedNotificationTarget");
            }
        }

        private List<Owner> _ownersList;

        public List<Owner> OwnersList
        {
            get { return _ownersList; }
            set
            {
                _ownersList = value;
                OnPropertyChanged("OwnersList");
            }
        }

        private Owner _selectedOwner;

        public Owner SelectedOwner
        {
            get { return _selectedOwner; }
            set
            {
                _selectedOwner = value;
                OnPropertyChanged("SelectedOwner");
            }
        }

        private List<Dispatcher> _dispatchersList;

        public List<Dispatcher> DispatchersList
        {
            get { return _dispatchersList; }
            set
            {
                _dispatchersList = value;
                OnPropertyChanged("DispatchersList");
            }
        }

        private Dispatcher _selectedDispatcher;

        public Dispatcher SelectedDispatcher
        {
            get { return _selectedDispatcher; }
            set
            {
                _selectedDispatcher = value;
                OnPropertyChanged("SelectedDispatcher");
            }
        }

        #endregion
    }
}
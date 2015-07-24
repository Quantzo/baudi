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
        #region Properties
        private Notification _notification;
        public Notification Notification
        {
            get
            {
                return _notification;
            }
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
                return Enum.GetValues(typeof(NotificationStatus))
                    .Cast<NotificationStatus>();
            }
        }

        private NotificationStatus _selectedNotificationStatus;
        public NotificationStatus SelectedNotificationStatus
        {
            get
            {
                return _selectedNotificationStatus;
            }
            set
            {
                _selectedNotificationStatus = value;
                OnPropertyChanged("SelectedNotificationStatus");
            }

        }

        private List<NotificationTarget> _notificationTargetsList;
        public List<NotificationTarget> NotificationTargetsList
        {
            get
            {
                return _notificationTargetsList;
            }
            set
            {

                _notificationTargetsList = value;
                OnPropertyChanged("NotificationTargetsList");
            }
        }

        private NotificationTarget _selectedNotificationTarget;
        public  NotificationTarget SelectedNotificationTarget
        {
            get
            {
                return _selectedNotificationTarget;
            }
            set
            {
                _selectedNotificationTarget = value;
                OnPropertyChanged("SelectedNotificationTarget");
            }

        }

        private List<Owner> _ownersList;
        public List<Owner> OwnersList
        {
            get
            {
                return _ownersList;
            }
            set
            {

                _ownersList = value;
                OnPropertyChanged("OwnersList");
            }
        }
        private Owner _selectedOwner;
        public Owner SelectedOwner
        {
            get
            {
                return _selectedOwner;
            }
            set
            {
                _selectedOwner = value;
                OnPropertyChanged("SelectedOwner");
            }

        }

        private List<Dispatcher> _dispatchersList;
        public List<Dispatcher> DispatchersList
        {
            get
            {
                return _dispatchersList;
            }
            set
            {

                _dispatchersList = value;
                OnPropertyChanged("DispatchersList");
            }
        }

        private Dispatcher _selectedDispatcher;
        public Dispatcher SelectedDispatcher
        {
            get
            {
                return _selectedDispatcher;
            }
            set
            {
                _selectedDispatcher = value;
                OnPropertyChanged("SelectedDispatcher");
            }
        }

        #endregion

        public NotificationEditWindowViewModel(NotificationsTabViewModel notificationTabViewModel, NotificationEditWindow notificationEditWindow, Notification notification)
            : base(notificationTabViewModel, notificationEditWindow, notification)
        {

        }


        public override bool IsValid()
        {
            if (SelectedNotificationTarget != null && SelectedOwner != null && SelectedDispatcher != null)
                return true;
            return false;
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}

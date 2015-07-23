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
        #endregion

        public NotificationEditWindowViewModel(NotificationsTabViewModel notificationTabViewModel, NotificationEditWindow notificationEditWindow, Notification notification)
            : base(notificationTabViewModel, notificationEditWindow, notification)
        {

        }


        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}

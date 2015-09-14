using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    public partial class NotificationEditWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="notificationsTabViewModel">Notification tab view model</param>
        /// <param name="notification">Notification</param>
        public NotificationEditWindow(NotificationsTabViewModel notificationsTabViewModel, Notification notification)
        {
            InitializeComponent();
            DataContext = new NotificationEditWindowViewModel(notificationsTabViewModel, this, notification);
        }
    }
}
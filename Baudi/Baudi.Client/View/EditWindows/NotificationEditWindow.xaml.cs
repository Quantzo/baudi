using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;

namespace Baudi.Client.View.EditWindows
{
    public partial class NotificationEditWindow : Window
    {
        public NotificationEditWindow(NotificationsTabViewModel notificationsTabViewModel, Notification notification)
        {
            InitializeComponent();
            DataContext = new NotificationEditWindowViewModel(notificationsTabViewModel, this, notification);
        }
    }
}
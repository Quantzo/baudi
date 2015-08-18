using System.Security;
using System.Windows;
using Baudi.Client.ViewModels;

namespace Baudi.Client.View
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            DataContext = new LoginWindowViewModel(this);
            InitializeComponent();
            
        }
        public SecureString Password => PasswordBox.SecurePassword;
    }
}
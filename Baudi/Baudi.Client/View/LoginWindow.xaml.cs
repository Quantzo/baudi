using System.Security;
using System.Windows;
using Baudi.Client.ViewModels;

namespace Baudi.Client.View
{
    public partial class LoginWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LoginWindow()
        {
            DataContext = new LoginWindowViewModel(this);
            InitializeComponent();
            
        }
        /// <summary>
        /// Returns password
        /// </summary>
        public SecureString Password
        {
            get { return PasswordBox.SecurePassword; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Security.Cryptography;
using Baudi.Client.View;
using Baudi.DAL;
using Baudi.DAL.Models;


namespace Baudi.Client.ViewModels
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        #region Properties

        private LoginWindow LoginWindow;
        public ICommand ButtonExit { get; set; }
        public ICommand ButtonLogin { get; set; }
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
#endregion

        public LoginWindowViewModel(LoginWindow loginWindow)
        {
            LoginWindow = loginWindow;
            ButtonLogin = new RelayCommand(pars => Login());
            ButtonExit = new RelayCommand(pars => ExitWindow());
        }

        private void Login()
        {
            Employee employee;
            if (TryFindEmployee(out employee))
            {
                if (IsPasswordValid(employee.Password, employee.PasswordSalt))
                {
                    LaunchApplication();
                }
                else
                {
                    MessageBox.Show("Złe hasło");
                }
            }
            MessageBox.Show("Login jest zły");
        }


        private bool TryFindEmployee(out Employee employee)
        {
            
            using (var con = new BaudiDbContext())
            {
                employee = con.Employees
                    .FirstOrDefault(e => e.Username.Equals(Username));
            }
            return employee != null;
        }

        private bool IsPasswordValid(string hashedPassword, string passwordSalt)
        {
            string computedHash;
            using (var hash = new SHA512Managed())
            {
                computedHash= Convert.ToBase64String(hash.ComputeHash(Convert.FromBase64String(LoginWindow.Password+passwordSalt)));
            }
            return computedHash.Equals(hashedPassword);
        }

        private void LaunchApplication()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            LoginWindow.Close();
        }

       



        private void ExitWindow()
        {
            
        }
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

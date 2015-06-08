using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baudi.DAL;
using Baudi.DAL.Models;
using System.Windows.Input;

namespace Baudi.Client.ViewModels
{
    public class MainWindowCode : INotifyPropertyChanged
    {

        public MainWindowCode()
        {
            Load();
            Button_Click_Add = new RelayCommand(pars => Add());
        }
        public event PropertyChangedEventHandler PropertyChanged = null;
        private List<Building> _BuildingsList;
        public List<Building> BuildingsList
        {
            get { return _BuildingsList; }
        }

        private List<Person> _OwnersList;
        public List<Person> OwnersList
        {
            get { return _OwnersList; }
        }

        private List<Employee> _EmployeesList;
        public List<Employee> EmployeesList
        {
            get { return _EmployeesList; }
        }

        private List<Notification> _NotificationsList;
        public List<Notification> NotificationsList
        {
            get { return _NotificationsList; }
        }
        private List<Company> _CompaniesList;
        public List<Company> CompaniesList
        {
            get { return _CompaniesList; }
        }

        void Load()
        {
            using(var con = Connection.Con)
            {
                _BuildingsList = con.Buildings.ToList();
                _OwnersList = con.Peoples.ToList();
                _EmployeesList = con.Employees.ToList();
                _NotificationsList = con.Notifications.ToList();
                _CompaniesList = con.Companies.ToList();
            }
        }

        void Add()
        {
            int i = 0;
        }

        public ICommand Button_Click_Add { get; set; }

        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }		
    }
}

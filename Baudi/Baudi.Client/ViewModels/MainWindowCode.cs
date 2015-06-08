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

        void Load()
        {
            using(var con = Connection.Con)
            {
                _BuildingsList = con.Buildings.ToList();
                _OwnersList = con.Peoples.ToList();
                _EmployeesList = con.Employees.ToList();
            }
        }


        public ICommand Button_Click_Add { get; set; }

        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }		
    }
}

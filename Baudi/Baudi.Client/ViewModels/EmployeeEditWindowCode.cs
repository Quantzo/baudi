using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication1;

namespace Baudi.Client.ViewModels
{
    class EmployeeEditWindowCode
    {

        Employee selectedEmployee;
        EmployeeEditWindow thisWindow;
        MainWindowCode thisWindowOwner;

        public EmployeeEditWindowCode(Employee selectedEmployee, EmployeeEditWindow thisWindow, MainWindowCode thisWindowOwner)
        {
            this.selectedEmployee = selectedEmployee;
            this.thisWindow = thisWindow;
            this.thisWindowOwner = thisWindowOwner;
            Button_Click_Cancel = new RelayCommand(pars => Cancel());
            Button_Click_Save = new RelayCommand(pars => Save());
            if (selectedEmployee != null)
            {
                _Name = selectedEmployee.Name;
                _PESEL = selectedEmployee.PESEL;
                _Surname = selectedEmployee.Surname;
                _Street = selectedEmployee.Street;
                _HouseNumber = selectedEmployee.HouseNumber;
                _LocalNumber = selectedEmployee.LocalNumber;
                _Telephone = selectedEmployee.Telephone;
                _City = selectedEmployee.City;
                _BankAccountNumber = selectedEmployee.BankAccountNumber;
                _Salary = selectedEmployee.Salary;
            }
        }

        public ICommand Button_Click_Cancel { get; set; }
        public ICommand Button_Click_Save { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = null;

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged("LocalNumber"); }
        }
        
        private string _Surname;
        public string Surname
        {
            get { return _Surname; }
            set { _Surname = value; OnPropertyChanged("NumberOfRooms"); }
        }

        private string _PESEL;
        public string PESEL
        {
            get { return _PESEL; }
            set { _PESEL = value; OnPropertyChanged("PESEL");}
        }

        private string _Street;
        public string Street
        {
            get { return _Street; }
            set { _Street = value; OnPropertyChanged("Street"); }
        }

        private string _HouseNumber;
        public string HouseNumber
        {
            get { return _HouseNumber; }
            set { _HouseNumber = value; OnPropertyChanged("HouseNumber"); }
        }

        private string _LocalNumber;
        public string LocalNumber
        {
            get { return _LocalNumber; }
            set { _LocalNumber = value; OnPropertyChanged("LocalNumber"); }
        }

        private string _Telephone;
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; OnPropertyChanged("Telephone"); }
        }

        private string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; OnPropertyChanged("City"); }
        }

        private string _BankAccountNumber;
        public string BankAccountNumber
        {
            get { return _BankAccountNumber; }
            set { _BankAccountNumber = value; OnPropertyChanged("City"); }
        }

        private double _Salary;
        public double Salary
        {
            get { return _Salary; }
            set { _Salary = value; OnPropertyChanged("City"); }
        }

        void Cancel()
        {
            thisWindow.Close();
        }

        void Save()
        {
            using (var con = new BaudiDbContext())
            {
                if (selectedEmployee != null)
                {
                    var orginal = con.Employees.Find(selectedEmployee.PersonID);
                    if (orginal != null)
                    {
                        orginal.Name = Name;
                        orginal.PESEL = PESEL;
                        orginal.Surname = Surname;
                        orginal.Street = Street;
                        orginal.HouseNumber = HouseNumber;
                        orginal.LocalNumber = LocalNumber;
                        orginal.Telephone = Telephone;
                        orginal.City = City;
                        orginal.BankAccountNumber = BankAccountNumber;
                        orginal.Salary = Salary;
                    }
                }
                else
                {
                    var e = new Employee();
                    e.Name = Name;
                    e.PESEL = PESEL;
                    e.Surname = Surname;
                    e.Street = Street;
                    e.HouseNumber = HouseNumber;
                    e.LocalNumber = LocalNumber;
                    e.Telephone = Telephone;
                    e.City = City;
                    e.BankAccountNumber = BankAccountNumber;
                    e.Salary = Salary;
                    con.Employees.Add(e);
                }
                con.SaveChanges();
            }
            thisWindowOwner.Update();
            thisWindow.Close();
            
        }

        virtual public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }	


    }
}

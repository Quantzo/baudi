using System.ComponentModel;
using System.Windows.Input;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowCode
{
    internal class EmployeeEditWindowCode
    {
        private readonly Employee selectedEmployee;
        private readonly EmployeeEditWindow thisWindow;
        private readonly MainWindowViewModel thisWindowOwner;
        private string _BankAccountNumber;
        private string _City;
        private string _HouseNumber;
        private string _LocalNumber;
        private string _Name;
        private string _PESEL;
        private double _Salary;
        private string _Street;
        private string _Surname;
        private string _Telephone;

        public EmployeeEditWindowCode(Employee selectedEmployee, EmployeeEditWindow thisWindow,
            MainWindowViewModel thisWindowOwner)
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

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("LocalNumber");
            }
        }

        public string Surname
        {
            get { return _Surname; }
            set
            {
                _Surname = value;
                OnPropertyChanged("NumberOfRooms");
            }
        }

        public string PESEL
        {
            get { return _PESEL; }
            set
            {
                _PESEL = value;
                OnPropertyChanged("PESEL");
            }
        }

        public string Street
        {
            get { return _Street; }
            set
            {
                _Street = value;
                OnPropertyChanged("Street");
            }
        }

        public string HouseNumber
        {
            get { return _HouseNumber; }
            set
            {
                _HouseNumber = value;
                OnPropertyChanged("HouseNumber");
            }
        }

        public string LocalNumber
        {
            get { return _LocalNumber; }
            set
            {
                _LocalNumber = value;
                OnPropertyChanged("LocalNumber");
            }
        }

        public string Telephone
        {
            get { return _Telephone; }
            set
            {
                _Telephone = value;
                OnPropertyChanged("Telephone");
            }
        }

        public string City
        {
            get { return _City; }
            set
            {
                _City = value;
                OnPropertyChanged("City");
            }
        }

        public string BankAccountNumber
        {
            get { return _BankAccountNumber; }
            set
            {
                _BankAccountNumber = value;
                OnPropertyChanged("City");
            }
        }

        public double Salary
        {
            get { return _Salary; }
            set
            {
                _Salary = value;
                OnPropertyChanged("City");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Cancel()
        {
            thisWindow.Close();
        }

        private void Save()
        {
            using (var con = new BaudiDbContext())
            {
                if (selectedEmployee != null)
                {
                    var orginal = con.Employees.Find(selectedEmployee.OwnerID);
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

        public virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
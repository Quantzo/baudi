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
    public class CompanyEditWindowCode : INotifyPropertyChanged
    {
        Company selectedCompany; ///Selected company in MainWindow.
        CompanyEditWindow thisWindow; ///Handler for window combined with this code.
        MainWindowViewModel thisWindowOwner; ///Handler for MainWindow code.



        ///Constructor - initialize handler, button, and form.
        public CompanyEditWindowCode(Company selectedCompany, CompanyEditWindow thisWindow, MainWindowViewModel thisWindowOwner)
        {
            this.selectedCompany = selectedCompany;
            this.thisWindow = thisWindow;
            this.thisWindowOwner = thisWindowOwner;
            Button_Click_Cancel = new RelayCommand(pars => Cancel());
            Button_Click_Save = new RelayCommand(pars => Save());
            if (selectedCompany != null)
            {
                _City = selectedCompany.City;
                _NIP = selectedCompany.NIP;
                _Owner = selectedCompany.Owner;
                _Street = selectedCompany.Street;
                _HouseNumber = selectedCompany.HouseNumber;
                _LocalNumber = selectedCompany.LocalNumber;
                _Telephone = selectedCompany.TelephoneNumber;
                _Specialization = selectedCompany.Specializations;
            }
        }

        public ICommand Button_Click_Cancel { get; set; }
        public ICommand Button_Click_Save { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = null;

        private string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; OnPropertyChanged("LocalNumber"); }
        }
        
        private string _Owner;
        public string Owner
        {
            get { return _Owner; }
            set { _Owner = value; OnPropertyChanged("NumberOfRooms"); }
        }

        private string _NIP;
        public string NIP
        {
            get { return _NIP; }
            set { _NIP = value; OnPropertyChanged("Area");}
        }

        private string _Street;
        public string Street
        {
            get { return _Street; }
            set { _Street = value; OnPropertyChanged("Area"); }
        }

        private string _HouseNumber;
        public string HouseNumber
        {
            get { return _HouseNumber; }
            set { _HouseNumber = value; OnPropertyChanged("Area"); }
        }

        private string _LocalNumber;
        public string LocalNumber
        {
            get { return _LocalNumber; }
            set { _LocalNumber = value; OnPropertyChanged("Area"); }
        }

        private string _Telephone;
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; OnPropertyChanged("Area"); }
        }

        private List<Specialization> _Specialization;
        public List<Specialization> Specialization
        {
            get { return _Specialization; }
            set { _Specialization = value; OnPropertyChanged("Area"); }
        }

        /// <summary>
        /// Methode for Cancel button.
        /// </summary>
        void Cancel()
        {
            thisWindow.Close();
        }

        /// <summary>
        /// Methode for Save button.
        /// </summary>
        void Save()
        {
            using (var con = new BaudiDbContext())
            {
                //if company was select then update company
                if (selectedCompany != null)
                {
                    var orginal = con.Companies.Find(selectedCompany.CompanyID);
                    if (orginal != null)
                    {
                        orginal.Owner = Owner;
                        orginal.City = City;
                        orginal.HouseNumber = HouseNumber;
                        orginal.LocalNumber = LocalNumber;
                        orginal.NIP = NIP;
                        orginal.Street = Street;
                        orginal.TelephoneNumber = Telephone;
                    }
                }
                //if company was not select then add company
                else
                {
                    var b = new Company();
                    b.Owner = Owner;
                    b.City = City;
                    b.HouseNumber = HouseNumber;
                    b.LocalNumber = LocalNumber;
                    b.NIP = NIP;
                    b.Street = Street;
                    b.TelephoneNumber = Telephone;
                    con.Companies.Add(b);
                }
                con.SaveChanges();
            }
            thisWindowOwner.Update();
            thisWindow.Close();
            
        }

        /// <summary>
        /// Methode implementation from INotifyPropertyChanged
        /// </summary>
        virtual public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }	
    }
}

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
    public class CompanyEditWindowCode
    {

        Company selectedCompany;
        CompanyEditWindow thisWindow;
        MainWindowCode thisWindowOwner;

        public CompanyEditWindowCode(Company selectedCompany, CompanyEditWindow thisWindow, MainWindowCode thisWindowOwner)
        {
            this.selectedCompany = selectedCompany;
            this.thisWindow = thisWindow;
            this.thisWindowOwner = thisWindowOwner;
            Button_Click_Cancel = new RelayCommand(pars => Cancel());
            Button_Click_Save = new RelayCommand(pars => Save());
            if (selectedCompany != null)
            {
                _City = selectedCompany.LocalNumber;
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

        void Cancel()
        {
            thisWindow.Close();
        }

        void Save()
        {
            using (var con = new BaudiDbContext())
            {
                if (selectedCompany != null)
                {
                    var orginal = con.Companies.Find(selectedCompany.CompanyID);
                    if (orginal != null)
                    {
                        orginal.Owner = Owner;
                        orginal.City = City;
                        orginal.HouseNumber = HouseNumber;
                        orginal.LocalNumber = City;
                        orginal.NIP = NIP;
                        orginal.Street = Street;
                        orginal.TelephoneNumber = Telephone;
                        orginal.Specializations = Specialization;
                        thisWindowOwner.Update();
                    }
                }
                else
                {
                    var b = new Company();
                    b.Owner = Owner;
                    b.City = City;
                    b.HouseNumber = HouseNumber;
                    b.LocalNumber = City;
                    b.NIP = NIP;
                    b.Street = Street;
                    b.TelephoneNumber = Telephone;
                    b.Specializations = Specialization;
                    con.Companies.Add(b);
                    thisWindowOwner.Update();
                }
                con.SaveChanges();
            }            
            thisWindow.Close();
        }

        virtual public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }	
    }
}

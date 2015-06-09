using Baudi.DAL;
using Baudi.DAL.Models;
using GUIBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Baudi.Client.ViewModels
{
    public class OwnerEditWindowCode
    {

        Person selectedOwner;
        OwnerEditWindow thisWindow;
        MainWindowCode thisWindowOwner;
        List<Ownership> addedOwnership;
        List<Ownership> updatedOwnership;
        bool update = false;
        public OwnerEditWindowCode(Person selectedOwner, OwnerEditWindow thisWindow, MainWindowCode thisWindowOwner)
        {
            this.selectedOwner = selectedOwner;
            this.thisWindow = thisWindow;
            this.thisWindowOwner = thisWindowOwner;
            addedOwnership = new List<Ownership>();
            updatedOwnership = new List<Ownership>();
            Button_Click_Cancel = new RelayCommand(pars => Cancel());
            Button_Click_Save = new RelayCommand(pars => Save());
            Button_Click_Add = new RelayCommand(pars => Add());
            Button_Click_Edit = new RelayCommand(pars => Edit());
            Button_Click_Delete = new RelayCommand(pars => Delete());
            if (selectedOwner != null)
            {
                _Name = selectedOwner.Name;
                _PESEL = selectedOwner.PESEL;
                _Surname = selectedOwner.Surname;
                _Street = selectedOwner.Street;
                _HouseNumber = selectedOwner.HouseNumber;
                _LocalNumber = selectedOwner.LocalNumber;
                _Telephone = selectedOwner.Telephone;
                _City = selectedOwner.City;
                OwnershipsList = selectedOwner.Ownerships;
            }
        }

        public ICommand Button_Click_Cancel { get; set; }
        public ICommand Button_Click_Save { get; set; }
        public ICommand Button_Click_Add { get; set; }
        public ICommand Button_Click_Edit { get; set; }
        public ICommand Button_Click_Delete { get; set; }

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

        private List<Ownership> _OwnershipsList;
        public List<Ownership> OwnershipsList
        {
            get { return _OwnershipsList; }
            set { _OwnershipsList = value; OnPropertyChanged("OwnershipsList"); }
        }

        public Ownership SelectedOwnership
        {
            get;
            set;
        }

        void Add()
        {
            Ownership b = null;
            OwnershipEditWindow bew = new OwnershipEditWindow(b, this);
            bew.Show();
        }

        void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                Ownership b = con.Ownerships.Find(SelectedOwnership.OwnershipID);
                OwnershipEditWindow bew = new OwnershipEditWindow(b, this);
                bew.Show();
            }
        }

        void Delete()
        {
            Ownership b = OwnershipsList.Find(x => x.OwnershipID.Equals(SelectedOwnership.OwnershipID));
            OwnershipsList.Remove(b);
        }

        void Cancel()
        {
            thisWindow.Close();
        }

        void Save()
        {
            using (var con = new BaudiDbContext())
            {
                if (selectedOwner != null)
                {
                    var orginal = con.Peoples.Find(selectedOwner.PersonID);
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
                        if (addedOwnership.Count != 0)
                        {
                            foreach (Ownership l in addedOwnership)
                            {
                                l.Owner = orginal;
                            }
                            con.Ownerships.AddRange(addedOwnership);
                        }
                        //updatelocals
                        if (addedOwnership.Count != 0)
                        {
                            foreach (Ownership l in updatedOwnership)
                            {
                                Ownership temp = con.Ownerships.Find(l.OwnershipID);
                                temp.Local = l.Local;
                                temp.PurchaseDate = l.PurchaseDate;
                                temp.SaleDate = l.SaleDate;
                            }
                        }
                    }
                }
                else
                {
                    var e = new Person();
                    e.Name = Name;
                    e.PESEL = PESEL;
                    e.Surname = Surname;
                    e.Street = Street;
                    e.HouseNumber = HouseNumber;
                    e.LocalNumber = LocalNumber;
                    e.Telephone = Telephone;
                    e.City = City;
                    con.Peoples.Add(e);

                    if (addedOwnership.Count != 0)
                    {
                        foreach (Ownership l in addedOwnership)
                        {
                            l.Owner = e;
                        }
                        con.Ownerships.AddRange(addedOwnership);
                    }
                    if (updatedOwnership.Count != 0)
                    {
                        foreach (Ownership l in updatedOwnership)
                        {
                            Ownership temp = con.Ownerships.Find(l.OwnershipID);
                            temp.Local = l.Local;
                            temp.PurchaseDate = l.PurchaseDate;
                            temp.SaleDate = l.SaleDate;
                        }
                    }
                }
                con.SaveChanges();
            }
            thisWindowOwner.Update();
            thisWindow.Close();
            
        }

        public void Update(Ownership b)
        {
            if (update == false)
            {
                List<Ownership> actualList = new List<Ownership>();
                addedOwnership.Add(b);
                actualList.Add(b);
                if (OwnershipsList != null)
                {
                    actualList.AddRange(OwnershipsList);
                    OwnershipsList = actualList;
                }
                else
                    OwnershipsList = addedOwnership;
            }
            else
            {
                List<Ownership> actualList = new List<Ownership>();
                updatedOwnership.Add(b);
                actualList.AddRange(OwnershipsList);
                Ownership orginal = actualList.Find(x => x.OwnershipID == b.OwnershipID);
                orginal.Local = b.Local;
                orginal.PurchaseDate = b.PurchaseDate;
                orginal.SaleDate = b.SaleDate;
                OwnershipsList = actualList;
            }
        }

        virtual public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }	
    }
}

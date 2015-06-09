using Baudi.Client.View.SelectorWindow;
using Baudi.DAL;
using Baudi.DAL.Models;
using GUIBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApplication1;

namespace Baudi.Client.ViewModels
{
    public class OwnershipEditWindowCode
    {

        Ownership selectedOwnership;
        OwnershipEditWindow thisWindow;
        OwnerEditWindowCode thisWindowOwner;

        public OwnershipEditWindowCode(Ownership selectedOwnership, OwnershipEditWindow thisWindow, OwnerEditWindowCode thisWindowOwner)
        {
            this.selectedOwnership = selectedOwnership;
            this.thisWindow = thisWindow;
            this.thisWindowOwner = thisWindowOwner;
            Button_Click_Cancel = new RelayCommand(pars => Cancel());
            Button_Click_Save = new RelayCommand(pars => Save());
            Button_Click_SelectLocal = new RelayCommand(pars => SelectLocal());
            Button_Click_SelectBuilding = new RelayCommand(pars => SelectBuilding());

            if (selectedOwnership != null)
            {
                List<Building> btemp = new List<Building>();
                List<Local> ltemp = new List<Local>();
                btemp.Add(selectedOwnership.Local.Building);
                ltemp.Add(selectedOwnership.Local);
                BuildingsList = btemp;
                LocalsList = ltemp;
                PurchaseDate = Convert.ToDateTime("12-12-2014");
                SaleDate = Convert.ToDateTime("12-12-2014");//selectedOwnership.SaleDate;
            }
        }

        public ICommand Button_Click_Cancel { get; set; }
        public ICommand Button_Click_Save { get; set; }
        public ICommand Button_Click_SelectLocal { get; set; }
        public ICommand Button_Click_SelectBuilding { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = null;

        private List<Local> _LocalsList;
        public List<Local> LocalsList
        {
            get { return _LocalsList; }
            set { _LocalsList = value; OnPropertyChanged("LocalsList"); }
        }

        private List<Building> _BuildingsList;
        public List<Building> BuildingsList
        {
            get { return _BuildingsList; }
            set { _BuildingsList = value; OnPropertyChanged("BuildingsList"); }
        }

        private DateTime _PurchaseDate;
        public DateTime PurchaseDate
        {
            get { return _PurchaseDate; }
            set { _PurchaseDate = value; OnPropertyChanged("PurchaseDate"); }
        }

        private DateTime _SaleDate;
        public DateTime SaleDate
        {
            get { return _SaleDate; }
            set { _SaleDate = value; OnPropertyChanged("SaleDate"); }
        }

        void Cancel()
        {
            thisWindow.Close();
        }

        void Save()
        {
            using (var con = new BaudiDbContext())
            {
                if (selectedOwnership != null)
                {
                    var orginal = con.Ownerships.Find(selectedOwnership.OwnershipID);
                    if (orginal != null)
                    {
                        orginal.Local = selectedOwnership.Local;
                        orginal.PurchaseDate = PurchaseDate.ToString();
                        orginal.SaleDate = SaleDate.ToString();
                        thisWindowOwner.Update(orginal);
                    }
                }
                else
                {
                    var b = new Ownership();
                    b.Local = LocalsList.First();
                    b.PurchaseDate = PurchaseDate.ToString();
                    b.SaleDate = SaleDate.ToString();
                    thisWindowOwner.Update(b);
                }
                con.SaveChanges();
            }            
            thisWindow.Close();
        }

        void SelectLocal()
        {
            LocalSelector ls = new LocalSelector(this, BuildingsList.First());
            ls.Show();
        }

        void SelectBuilding()
        {
            BuildingSelector bs = new BuildingSelector(this);
            bs.Show();
        }

        public void Update(Local l, Building b)
        {
            using(var con = new BaudiDbContext())
            { 
            List<Local> newList = new List<Local>();
            List<Building> newList1 = new List<Building>();
            newList.Add(l);
            newList1.Add(b);
            if (l != null)
            {
                _LocalsList = newList;
                LocalsList = newList;
            }
            else if (b != null)
                BuildingsList = newList1;
                }
        }

        virtual public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }	
    }
}

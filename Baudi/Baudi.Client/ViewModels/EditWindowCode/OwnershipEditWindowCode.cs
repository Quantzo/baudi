﻿using Baudi.Client.View.SelectorWindow;
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

namespace Baudi.Client.ViewModels
{
    public class OwnershipEditWindowCode : INotifyPropertyChanged
    {
        Ownership selectedOwnership; ///Selected Building in MainWindow.
        OwnershipEditWindow thisWindow; ///Handler for window combined with this code.
        OwnerEditWindowCode thisWindowOwner; ///Handler for MainWindow code.

        /// <summary>
        /// Constructor - initialize handler, button, and form.
        /// </summary>                            
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
                List<Local> ltemp = new List<Local>();
                if (selectedOwnership.Local == null)
                {
                    using (var con = new BaudiDbContext())
                    {
                        selectedOwnership = con.Ownerships.Find(selectedOwnership.OwnershipID);
                        ltemp.Add(selectedOwnership.Local);
                    }
                }
                _LocalsList = ltemp;
                selectedOwnership.PurchaseDate = "11-11-2014";
                _PurchaseDate = selectedOwnership.PurchaseDate;
                selectedOwnership.SaleDate = "12-12-2014";
                _SaleDate = selectedOwnership.SaleDate;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = null;

        public ICommand Button_Click_Cancel { get; set; }
        public ICommand Button_Click_Save { get; set; }
        public ICommand Button_Click_SelectLocal { get; set; }
        public ICommand Button_Click_SelectBuilding { get; set; }

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

        private string _PurchaseDate;
        public string PurchaseDate
        {
            get { return _PurchaseDate; }
            set { _PurchaseDate = value; OnPropertyChanged("PurchaseDate"); }
        }

        private string _SaleDate;
        public string SaleDate
        {
            get { return _SaleDate; }
            set { _SaleDate = value; OnPropertyChanged("SaleDate"); }
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
                if (selectedOwnership != null)
                {
                    var orginal = con.Ownerships.Find(selectedOwnership.OwnershipID);
                    if (orginal != null)
                    {
                        orginal.Local = con.Locals.Find(selectedOwnership.Local.NotificationTargetID);
                        orginal.PurchaseDate = PurchaseDate.ToString();
                        orginal.SaleDate = SaleDate.ToString();
                        thisWindowOwner.Update(orginal);
                    }
                }
                else
                {
                    var b = new Ownership();
                    b.Local = con.Locals.Find(LocalsList.First().NotificationTargetID);
                    b.PurchaseDate = PurchaseDate.ToString();
                    b.SaleDate = SaleDate.ToString();
                    thisWindowOwner.Update(b);
                }
                con.SaveChanges();
            }
            thisWindow.Close();
        }

        /// <summary>
        /// Methode for SelectLocal button.
        /// </summary>
        void SelectLocal()
        {
            LocalSelector ls = new LocalSelector(this, BuildingsList.First());
            ls.Show();
        }

        /// <summary>
        /// Methode for SelectBuilding button.
        /// </summary>
        void SelectBuilding()
        {
            BuildingSelector bs = new BuildingSelector(this);
            bs.Show();
        }

        /// <summary>
        /// Update from Selector.
        /// </summary>
        public void Update(Local l, Building b)
        {
            using (var con = new BaudiDbContext())
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

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class OwnershipEditWindowViewModel : EditWindowViewModel
    {
        public OwnershipEditWindowViewModel(OwnershipsTabViewModel ownershipTabViewModel,
            OwnershipEditWindow ownershipEditWindow, Ownership ownership)
            : base(ownershipTabViewModel, ownershipEditWindow, ownership)
        {
            using (var con = new BaudiDbContext())
            {
                LocalsList = con.Locals.ToList();
                OwnersList = con.Owners.ToList();
                if (Update)
                {
                    Ownership = con.Ownerships.Find(ownership.OwnershipID);
                    SelectedLocal = Ownership.Local;
                    SelectedOwner = Ownership.Owner;
                }
                else
                {
                    Ownership = new Ownership();
                    Ownership.PurchaseDate = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Adds new item
        /// </summary>
        public override void Add()
        {
            using (var con = new BaudiDbContext())
            {
                var local = con.Locals.Find(SelectedLocal.NotificationTargetID);
                var owner = con.Owners.Find(SelectedOwner.OwnerID);

                Ownership.Local = local;
                Ownership.Owner = owner;

                con.Ownerships.Add(Ownership);
                con.SaveChanges();
            }
        }

        /// <summary>
        /// Edits item
        /// </summary>
        public override void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                var local = con.Locals.Find(SelectedLocal.NotificationTargetID);
                var owner = con.Owners.Find(SelectedOwner.OwnerID);

                var ownership = con.Ownerships.Find(Ownership.OwnershipID);
                ownership.PurchaseDate = Ownership.PurchaseDate;
                ownership.SaleDate = ownership.SaleDate;
                ownership.Owner = owner;
                ownership.Local = local;

                con.Entry(ownership).State = EntityState.Modified;

                con.SaveChanges();
            }
        }

        /// <summary>
        /// Returns if state is valid
        /// </summary>
        /// <returns>Returns if state is valid</returns>
        public override bool IsValid()
        {
            if (SelectedLocal != null && SelectedOwner != null)
                return true;
            return false;
        }

        #region Properties

        private Ownership _ownership;

        public Ownership Ownership
        {
            get { return _ownership; }
            set
            {
                _ownership = value;
                OnPropertyChanged("Ownership");
            }
        }

        private List<Owner> _ownersList;

        public List<Owner> OwnersList
        {
            get { return _ownersList; }
            set
            {
                _ownersList = value;
                OnPropertyChanged("OwnersList");
            }
        }

        private Owner _selectedOwner;

        public Owner SelectedOwner
        {
            get { return _selectedOwner; }
            set
            {
                _selectedOwner = value;
                OnPropertyChanged("SelectedOwner");
            }
        }

        private List<Local> _localsList;

        public List<Local> LocalsList
        {
            get { return _localsList; }
            set
            {
                _localsList = value;
                OnPropertyChanged("LocalsList");
            }
        }

        private Local _selectedLocal;

        public Local SelectedLocal
        {
            get { return _selectedLocal; }
            set
            {
                _selectedLocal = value;
                OnPropertyChanged("SelectedLocal");
            }
        }

        #endregion
    }
}
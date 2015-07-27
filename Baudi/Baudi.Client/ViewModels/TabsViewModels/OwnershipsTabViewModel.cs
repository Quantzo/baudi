using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.DAL;
using Baudi.DAL.Models;
using Baudi.Client.View.EditWindows;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class OwnershipsTabViewModel : TabViewModel
    {
        #region Properties
        private List<Ownership> _ownershipsList;
        public List<Ownership> OwnershipsList
        {
            get
            {
                return _ownershipsList;
            }
            set
            {
                _ownershipsList = value;
                OnPropertyChanged("OwnershipsList");
            }

        }

        public Ownership SelectedOwnership { get; set;}


        #endregion

        public override void Add()
        {
            var ownershipEditWindow = new OwnershipEditWindow(this, null);
            ownershipEditWindow.Show();
        }

        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var ownership = con.Ownerships.Find(SelectedOwnership.OwnershipID);
                ownership.Local = null;
                ownership.Owner = null;
                con.Ownerships.Remove(ownership);
                con.SaveChanges();
            }
            Update();
        }

        public override void Edit()
        {
            var ownershipEditWindow = new OwnershipEditWindow(this, SelectedOwnership);
            ownershipEditWindow.Show();
        }

        public override bool IsSomethingSelected()
        {
            if (SelectedOwnership != null)
            {
                return true;
            }
            return false;
        }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                OwnershipsList = con.Ownerships
                    .Include(ow => ow.Owner)
                    .Include(ow => ow.Local)
                    .ToList();
            }
        }
    }
}

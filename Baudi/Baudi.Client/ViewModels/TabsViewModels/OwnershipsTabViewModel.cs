using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class OwnershipsTabViewModel : TabViewModel
    {
        /// <summary>
        /// Add action
        /// </summary>
        public override void Add()
        {
            var ownershipEditWindow = new OwnershipEditWindow(this, null);
            ownershipEditWindow.Show();
        }

        /// <summary>
        /// Delete action
        /// </summary>
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

        /// <summary>
        /// Edit action
        /// </summary>
        public override void Edit()
        {
            var ownershipEditWindow = new OwnershipEditWindow(this, SelectedOwnership);
            ownershipEditWindow.Show();
        }

        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
        public override bool IsSomethingSelected()
        {
            if (SelectedOwnership != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Load action
        /// </summary>
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

        #region Properties

        private List<Ownership> _ownershipsList;

        public List<Ownership> OwnershipsList
        {
            get { return _ownershipsList; }
            set
            {
                _ownershipsList = value;
                OnPropertyChanged("OwnershipsList");
            }
        }

        public Ownership SelectedOwnership { get; set; }

        #endregion
    }
}
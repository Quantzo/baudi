using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class RentsTabViewModel : TabViewModel
    {
        private List<Rent> _rentsList;

        public List<Rent> RentsList
        {
            get { return _rentsList; }
            set
            {
                _rentsList = value;
                OnPropertyChanged("RentsList");
            }
        }

        public Rent SelectedRent { get; set; }

        /// <summary>
        /// Load action
        /// </summary>
        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                RentsList = con.Rents
                    .Include(r => r.Ownership)
                    .ToList();
            }
        }

        /// <summary>
        /// Add action
        /// </summary>
        public override void Add()
        {
            var rentEditWindow = new RentEditWindow(this, null);
            rentEditWindow.Show();
        }

        /// <summary>
        /// Delete action
        /// </summary>
        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var rent = con.Rents.Find(SelectedRent.PaymentID);
                rent.Ownership = null;
                con.Rents.Remove(rent);
                con.SaveChanges();
            }
            Update();
        }

        /// <summary>
        /// Edit action
        /// </summary>
        public override void Edit()
        {
            var rentEditWindow = new RentEditWindow(this, SelectedRent);
            rentEditWindow.Show();
        }

        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
        public override bool IsSomethingSelected()
        {
            if (SelectedRent != null)
            {
                return true;
            }
            return false;
        }
    }
}
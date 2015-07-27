using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class RentEditWindowViewModel : EditWindowViewModel
    {
        public RentEditWindowViewModel(RentsTabViewModel rentsTabViewModel, RentEditWindow rentEditWindow, Rent rent)
            : base(rentsTabViewModel, rentEditWindow, rent)
        {
            using (var con = new BaudiDbContext())
            {
                OwnershipsList = con.Ownerships.ToList();
                if (Update)
                {
                    Rent = con.Rents.Find(rent.PaymentID);
                    SelectedOwnership = Rent.Ownership;
                }
                else
                {
                    Rent = new Rent();
                }
            }
        }

        public override bool IsValid()
        {
            if (SelectedOwnership != null)
            {
                return true;
            }
            return false;
        }

        public override void Add()
        {
            using (var con = new BaudiDbContext())
            {
                var ownership = con.Ownerships.Find(SelectedOwnership.OwnershipID);

                Rent.Ownership = ownership;

                con.Rents.Add(Rent);
                con.SaveChanges();
            }
        }

        public override void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                var ownership = con.Ownerships.Find(SelectedOwnership.OwnershipID);


                var rent = con.Rents.Find(Rent.PaymentID);
                rent.Ownership = ownership;
                rent.Date = Rent.Date;
                rent.Cost = Rent.Cost;
                rent.Paid = Rent.Paid;


                con.Entry(rent).State = EntityState.Modified;

                con.SaveChanges();
            }
        }

        #region Properties

        private Rent _rent;

        public Rent Rent
        {
            get { return _rent; }
            set
            {
                _rent = value;
                OnPropertyChanged("Rent");
            }
        }

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

        private Ownership _selectedOwnership;

        public Ownership SelectedOwnership
        {
            get { return _selectedOwnership; }
            set
            {
                _selectedOwnership = value;
                OnPropertyChanged("SelectedOwnership");
            }
        }

        #endregion
    }
}
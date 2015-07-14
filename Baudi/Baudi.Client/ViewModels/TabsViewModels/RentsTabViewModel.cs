using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                RentsList = con.Rents
                    .Include(r => r.Ownership)
                    .ToList();
            }
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Edit()
        {
            throw new NotImplementedException();
        }

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
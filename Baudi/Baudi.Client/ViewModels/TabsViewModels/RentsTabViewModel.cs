using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class RentsTabViewModel :TabViewModel
    {

        private List<Rent> _rentsList;
        public List<Rent> RentsList
        {
            get { return _rentsList; }
            set { _rentsList = value; OnPropertyChanged("RentsList"); }
        }
        public Rent SelectedRent
        {
            get;
            set;
        }
        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                _rentsList = con.Rents
                    .Include(r => r.Ownership)
                    .ToList();

            }
        }
        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Update()
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
    }
}

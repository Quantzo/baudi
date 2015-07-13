using System;
using System.Collections.Generic;
using System.Linq;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class OwningCompaniesTabViewModel : TabViewModel
    {
        private List<OwningCompany> _owningCompaniesList;

        public List<OwningCompany> OwningCompaniesList
        {
            get { return _owningCompaniesList; }
            set
            {
                _owningCompaniesList = value;
                OnPropertyChanged("OwningCompaniesList");
            }
        }

        public OwningCompany SelectedOwningCompany { get; set; }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                OwningCompaniesList = con.OwningCompanies.Where(oc => oc.Ownerships.Count != 0).ToList();
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

        public override bool IsSomethingSelected()
        {
            throw new NotImplementedException();
        }
    }
}
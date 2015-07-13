using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class OwningCompaniesTabViewModel :TabViewModel
    {

        private List<OwningCompany> _OwningCompaniesList;
        public List<OwningCompany> OwningCompaniesList
        {
            get { return _OwningCompaniesList; }
            set { _OwningCompaniesList = value; OnPropertyChanged("OwningCompaniesList"); }
        }

        public OwningCompany SelectedOwningCompany
        {
            get;
            set;
        }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                _OwningCompaniesList = con.OwningCompanies.Where(oc => oc.Ownerships.Count != 0).ToList();

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

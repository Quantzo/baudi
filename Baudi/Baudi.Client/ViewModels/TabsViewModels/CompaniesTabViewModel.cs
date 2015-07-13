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
    public class CompaniesTabViewModel : TabViewModel
    {
        private List<Company> _companiesList;
        public List<Company> CompaniesList
        {
            get { return _companiesList; }
            set { _companiesList = value; OnPropertyChanged("CompaniesList"); }
        }


        public Company SelectedCompany
        {
            get;
            set;
        }


        public override void  Load()
        {
            using (var con = new BaudiDbContext())
            {
                CompaniesList = con.Companies.ToList();

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

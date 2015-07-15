using System;
using System.Collections.Generic;
using System.Linq;
using Baudi.DAL;
using Baudi.DAL.Models;
using Baudi.Client.View.EditWindows;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class CompaniesTabViewModel : TabViewModel
    {
        private List<Company> _companiesList;

        public List<Company> CompaniesList
        {
            get { return _companiesList; }
            set
            {
                _companiesList = value;
                OnPropertyChanged("CompaniesList");
            }
        }

        public Company SelectedCompany { get; set; }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                CompaniesList = con.Companies.ToList();
            }
        }

        public override void Add()
        {
            var companyEditWindow = new CompanyEditWindow(this, null);
            companyEditWindow.Show();
        }
        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var company = con.Companies.Find(SelectedCompany.CompanyID);
                company.CyclicOrders.Clear();
                company.Orders.Clear();
                company.Specializations.Clear();
                con.Companies.Remove(company);
                con.SaveChanges();
            }
            Update();
        }

        public override void Edit()
        {
            var companyEditWindow = new CompanyEditWindow(this, SelectedCompany);
            companyEditWindow.Show();
        }

        public override bool IsSomethingSelected()
        {
            if (SelectedCompany != null)
            {
                return true;
            }
            return false;
        }
    }
}
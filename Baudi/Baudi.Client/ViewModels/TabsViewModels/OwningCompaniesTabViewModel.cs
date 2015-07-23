using System;
using System.Collections.Generic;
using System.Linq;
using Baudi.DAL;
using Baudi.DAL.Models;
using Baudi.Client.View.EditWindows;

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
            var owningCompanyEditWindow = new OwningCompanyEditWindow(this, null);
            owningCompanyEditWindow.Show();
        }
        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var owningCompany = con.OwningCompanies.Find(SelectedOwningCompany.OwnerID);
                owningCompany.Notifications.Clear();
                con.Ownerships.RemoveRange(owningCompany.Ownerships);
                con.OwningCompanies.Remove(owningCompany);
                con.SaveChanges();
            }
            Update();
        }

        public override void Edit()
        {

            var owningCompanyEditWindow = new OwningCompanyEditWindow(this, SelectedOwningCompany);
            owningCompanyEditWindow.Show();
        }

        public override bool IsSomethingSelected()
        {
            if (SelectedOwningCompany != null)
            {
                return true;
            }
            return false;
        }
    }
}
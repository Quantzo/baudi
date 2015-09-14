using System.Collections.Generic;
using System.Linq;
using Baudi.Client.View.EditWindows;
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

        /// <summary>
        /// Load action
        /// </summary>
        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                OwningCompaniesList = con.OwningCompanies.ToList();
            }
        }

        /// <summary>
        /// Add action
        /// </summary>
        public override void Add()
        {
            var owningCompanyEditWindow = new OwningCompanyEditWindow(this, null);
            owningCompanyEditWindow.Show();
        }

        /// <summary>
        /// Delete action
        /// </summary>
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

        /// <summary>
        /// Edit action
        /// </summary>
        public override void Edit()
        {
            var owningCompanyEditWindow = new OwningCompanyEditWindow(this, SelectedOwningCompany);
            owningCompanyEditWindow.Show();
        }

        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
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
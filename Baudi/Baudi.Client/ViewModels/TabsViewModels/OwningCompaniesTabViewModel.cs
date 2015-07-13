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
    public class OwningCompaniesTabViewModel : INotifyPropertyChanged
    {
        public OwningCompaniesTabViewModel()
        {
            Load();
        }
        public event PropertyChangedEventHandler PropertyChanged;
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

        public void Load()
        {
            using (var con = new BaudiDbContext())
            {
                _OwningCompaniesList = con.OwningCompanies.Where(oc => oc.Ownerships.Count != 0).ToList();

            }
        }
        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        } 
    }
}

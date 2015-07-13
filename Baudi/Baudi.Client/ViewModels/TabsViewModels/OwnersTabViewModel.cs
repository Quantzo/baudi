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
    public class OwnersTabViewModel : INotifyPropertyChanged
    {
        public OwnersTabViewModel()
        {
            Load();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Person> _ownersList;
        public List<Person> OwnersList
        {
            get { return _ownersList; }
            set { _ownersList = value; OnPropertyChanged("OwnersList"); }
        }
        public Person SelectedOwner
        {
            get;
            set;
        }
        public void Load()
        {
            using (var con = new BaudiDbContext())
            {
                _ownersList = con.Peoples.Where(p => p.Ownerships.Count != 0).ToList();

            }
        }
        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        } 
    }
}

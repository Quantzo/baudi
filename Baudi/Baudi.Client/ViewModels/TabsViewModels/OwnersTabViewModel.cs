using System;
using System.Collections.Generic;
using System.Linq;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class OwnersTabViewModel : TabViewModel
    {
        private List<Person> _ownersList;

        public List<Person> OwnersList
        {
            get { return _ownersList; }
            set
            {
                _ownersList = value;
                OnPropertyChanged("OwnersList");
            }
        }

        public Person SelectedOwner { get; set; }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                OwnersList = con.Peoples.Where(p => p.Ownerships.Count != 0).ToList();
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
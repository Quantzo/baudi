using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;


namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class OwnerEditWindowViewModel : EditWindowViewModel
    {
        #region Properties
        private Person _person;
        public Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                OnPropertyChanged("Person");
            }
        }
        #endregion

        public OwnerEditWindowViewModel(OwnersTabViewModel ownerTabViewModel, OwnerEditWindow ownerEditWindow, Owner owner)
            : base(ownerTabViewModel, ownerEditWindow, owner)
        {

        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
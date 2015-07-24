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
    public class RentEditWindowViewModel : EditWindowViewModel
    {
        #region Properties
        private Rent _rent;
        public Rent Rent
        {
            get
            {
                return _rent;
            }
            set
            {
                _rent = value;
                OnPropertyChanged("Rent");
            }

        }

        private List<Ownership> _ownershipsList;
        public List<Ownership> OwnershipsList
        {
            get
            {
                return _ownershipsList;
            }

            set
            {
                _ownershipsList = value;
                OnPropertyChanged("OwnershipsList");
            }
        }
        private Ownership _selectedOwnership;
        public Ownership SelectedOwnership
        {
            get
            {
                return _selectedOwnership;
            }
            set
            {
                _selectedOwnership = value;
                OnPropertyChanged("SelectedOwnership");
            }
        }

        #endregion

        public RentEditWindowViewModel(RentsTabViewModel rentsTabViewModel, RentEditWindow rentEditWindow, Rent rent)
            : base(rentsTabViewModel, rentEditWindow, rent)
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

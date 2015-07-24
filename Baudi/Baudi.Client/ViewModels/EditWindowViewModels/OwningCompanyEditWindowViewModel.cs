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
    public class OwningCompanyEditWindowViewModel : EditWindowViewModel
    {

        #region Properties
        private OwningCompany _owningCompany;
        public OwningCompany OwningCompany
        {
            get
            {
                return _owningCompany;
            }
            set
            {
                _owningCompany = value;
                OnPropertyChanged("OwningCompany");
            }
        }
        #endregion

        public OwningCompanyEditWindowViewModel(OwningCompaniesTabViewModel owningCompaniesTabViewModel, OwningCompanyEditWindow owningCompanyEditWindow, OwningCompany owningCompany)
            : base(owningCompaniesTabViewModel, owningCompanyEditWindow, owningCompany)
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

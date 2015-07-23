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

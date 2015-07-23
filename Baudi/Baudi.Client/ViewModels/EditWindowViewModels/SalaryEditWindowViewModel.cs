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
    public class SalaryEditWindowViewModel : EditWindowViewModel
    {
        #region Properties
        #endregion

        public SalaryEditWindowViewModel(SalariesTabViewModel salaryTabViewModel, SalaryEditWindow salaryEditWindow, Salary salary)
            : base(salaryTabViewModel, salaryEditWindow, salary)
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

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
        private Salary _salary;
        public Salary Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                OnPropertyChanged("Salary");
            }

        }

        private List<Ownership> _menagersList;
        public List<Ownership> MenagersList
        {
            get
            {
                return _menagersList;
            }

            set
            {
                _menagersList = value;
                OnPropertyChanged("MenagersList");
            }
        }
        private Menager _selectedMenager;
        public Menager SelectedMenager
        {
            get
            {
                return _selectedMenager;
            }
            set
            {
                _selectedMenager = value;
                OnPropertyChanged("SelectedMenager");
            }
        }
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

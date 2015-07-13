﻿using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class CompaniesTabViewModel : INotifyPropertyChanged
    {
        public CompaniesTabViewModel()
        {
            Load();
        }
        private List<Company> _companiesList;
        public List<Company> CompaniesList
        {
            get { return _companiesList; }
            set { _companiesList = value; OnPropertyChanged("CompaniesList"); }
        }


        public Company SelectedCompany
        {
            get;
            set;
        }


        public void Load()
        {
            using (var con = new BaudiDbContext())
            {
                _companiesList = con.Companies.ToList();

            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        } 
    }
}

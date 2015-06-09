﻿using Baudi.Client.View.SelectorWindow;
using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Baudi.Client.ViewModels
{
    class BuildingSelectorCode
    {
        BuildingSelector thisWindow;
        OwnershipEditWindowCode thisWindowOwner;
        public BuildingSelectorCode( BuildingSelector thisWindow, OwnershipEditWindowCode ownerWindow)
        {
            this.thisWindow = thisWindow;
            thisWindowOwner = ownerWindow;
            Button_Click_Cancel = new RelayCommand(pars => Cancel());
            Button_Click_Select = new RelayCommand(pars => Select());       
            using(var con = new BaudiDbContext())
            {
                _BuildingsList = con.Buildings.ToList();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = null;

        private List<Building> _BuildingsList;
        public List<Building> BuildingsList
        {
            get { return _BuildingsList; }
            set { _BuildingsList = value; OnPropertyChanged("LocalsList"); }
        }

        public Building SelectedBuilding
        {
            get;
            set;
        }

        public ICommand Button_Click_Cancel { get; set; }
        public ICommand Button_Click_Select { get; set; }

        void Cancel()
        {
            thisWindow.Close();
        }

        void Select()
        {
            thisWindowOwner.Update(null, SelectedBuilding);
            thisWindow.Close();
        }
        
        virtual public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }	
    }
}

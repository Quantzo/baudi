﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.DAL;
using Baudi.DAL.Models;
using Baudi.Client.View.EditWindows;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class SpecializationsTabViewModel : TabViewModel
    {
        #region Properties
        private List<Specialization> _specializationsList;
        public List<Specialization> SpecializationsList
        {
            get
            {
                return _specializationsList;
            }
            set
            {
                _specializationsList = value;
                OnPropertyChanged("SpecializationsList");
            }

        }

        public Specialization SelectedSpecialization { get; set; }
        #endregion
        public override void Add()
        {
            var specializationEditWindow = new SpecializationEditWindow(this, null);
            specializationEditWindow.Show();
        }

        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var specialization = con.Specializations.Find(SelectedSpecialization.SpecializationID);
                specialization.Companies = null;
                specialization.OrderTypes = null;
                con.Specializations.Remove(specialization);
                con.SaveChanges();
            }
            Update();
        }

        public override void Edit()
        {
            var specializationEditWindow = new SpecializationEditWindow(this, SelectedSpecialization);
            specializationEditWindow.Show();
        }

        public override bool IsSomethingSelected()
        {
            if(SelectedSpecialization != null)
                return true;
            return false;            
        }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                SpecializationsList = con.Specializations
                    .ToList();
            }
        }
    }
}
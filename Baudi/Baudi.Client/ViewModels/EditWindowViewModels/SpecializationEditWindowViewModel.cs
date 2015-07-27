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
    public class SpecializationEditWindowViewModel : EditWindowViewModel
    {

        #region Properties
        private Specialization _specialization;
        public Specialization Specialization
        {
            get
            {
                return _specialization;
            }
            set
            {
                _specialization = value;
                OnPropertyChanged("Specialization");
            }
        }
        #endregion
        public SpecializationEditWindowViewModel(SpecializationsTabViewModel specializationsTabViewModel, SpecializationEditWindow specializationEditWindow, Specialization specialization)
            :base(specializationsTabViewModel, specializationEditWindow, specialization)
        {
            if (Update)
            {
                Specialization = new Specialization
                {
                    SpecializationID = specialization.SpecializationID,
                    Name = specialization.Name,
                };
            }
            else
            {
                Specialization = new Specialization();
            }
        }

        public override void Add()
        {
            using (var con = new BaudiDbContext())
            {
                con.Specializations.Add(Specialization);
                con.SaveChanges();
            }
        }

        public override void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                var specialization = con.Specializations.Find(Specialization.SpecializationID);
                specialization.Name = Specialization.Name;

                con.Entry(specialization).State = EntityState.Modified;
                con.SaveChanges();
            }

        }

        public override bool IsValid()
        {
            return true;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class SpecializationsTabViewModel : TabViewModel
    {
        /// <summary>
        /// Add action
        /// </summary>
        public override void Add()
        {
            var specializationEditWindow = new SpecializationEditWindow(this, null);
            specializationEditWindow.Show();
        }

        /// <summary>
        /// Delete action
        /// </summary>
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

        /// <summary>
        /// Edit action
        /// </summary>
        public override void Edit()
        {
            var specializationEditWindow = new SpecializationEditWindow(this, SelectedSpecialization);
            specializationEditWindow.Show();
        }

        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
        public override bool IsSomethingSelected()
        {
            if (SelectedSpecialization != null)
                return true;
            return false;
        }

        /// <summary>
        /// Load action
        /// </summary>
        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                SpecializationsList = con.Specializations
                    .ToList();
            }
        }

        #region Properties

        private List<Specialization> _specializationsList;

        public List<Specialization> SpecializationsList
        {
            get { return _specializationsList; }
            set
            {
                _specializationsList = value;
                OnPropertyChanged("SpecializationsList");
            }
        }

        public Specialization SelectedSpecialization { get; set; }

        #endregion
    }
}
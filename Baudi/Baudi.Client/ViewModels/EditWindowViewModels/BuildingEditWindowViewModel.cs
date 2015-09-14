using System.Data.Entity;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    /// <summary>
    /// BuildingEditWindowViewModel
    /// </summary>
    public class BuildingEditWindowViewModel : EditWindowViewModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="buildingsTabViewModel">Buildings tab view model</param>
        /// <param name="buildingEditWindow">Building edit window</param>
        /// <param name="building">Building</param>
        public BuildingEditWindowViewModel(BuildingsTabViewModel buildingsTabViewModel,
            BuildingEditWindow buildingEditWindow, Building building)
            : base(buildingsTabViewModel, buildingEditWindow, building)
        {
            if (Update)
            {
                Building = new Building
                {
                    NotificationTargetID = building.NotificationTargetID,
                    City = building.City,
                    HouseNumber = building.HouseNumber,
                    Street = building.Street
                };
            }
            else
            {
                Building = new Building();
            }
        }

        /// <summary>
        /// Returns if state is valid
        /// </summary>
        /// <returns>Returns if state is valid</returns>
        public override bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// Adds new item
        /// </summary>
        public override void Add()
        {
            using (var con = new BaudiDbContext())
            {
                con.Buildings.Add(Building);
                con.SaveChanges();
            }
        }

        /// <summary>
        /// Edits item
        /// </summary>
        public override void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                var building = con.Buildings.Find(Building.NotificationTargetID);
                building.City = Building.City;
                building.HouseNumber = Building.HouseNumber;
                building.Street = Building.Street;

                con.Entry(building).State = EntityState.Modified;
                con.SaveChanges();
            }
        }

        #region Properties

        private Building _building;

        public Building Building
        {
            get { return _building; }
            set
            {
                _building = value;
                OnPropertyChanged("Building");
            }
        }

        #endregion
    }
}
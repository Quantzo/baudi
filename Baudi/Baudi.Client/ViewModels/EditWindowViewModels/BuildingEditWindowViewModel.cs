using System.Data.Entity;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class BuildingEditWindowViewModel : EditWindowViewModel
    {
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

        public override bool IsValid()
        {
            return true;
        }

        public override void Add()
        {
            using (var con = new BaudiDbContext())
            {
                con.Buildings.Add(Building);
                con.SaveChanges();
            }
        }

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
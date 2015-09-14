using System.Collections.Generic;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class BuildingsTabViewModel : TabViewModel
    {
        private List<Building> _buildingsList;

        public List<Building> BuildingsList
        {
            get { return _buildingsList; }
            set
            {
                _buildingsList = value;
                OnPropertyChanged("BuildingsList");
            }
        }

        public Building SelectedBuilding { get; set; }

        /// <summary>
        /// Load action
        /// </summary>
        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                BuildingsList = con.Buildings.ToList();
            }
        }

        /// <summary>
        /// Add action
        /// </summary>
        public override void Add()
        {
            var buildingEditWindow = new BuildingEditWindow(this, null);
            buildingEditWindow.Show();
        }

        /// <summary>
        /// Delete action
        /// </summary>
        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var building = con.Buildings.Find(SelectedBuilding.NotificationTargetID);


                building.Locals.ForEach(l => l.Notifactions.ForEach(n => con.Orders.RemoveRange(n.Orders)));
                building.Locals.ForEach(l => con.Notifications.RemoveRange(l.Notifactions));
                building.Locals.ForEach(l => con.Ownerships.RemoveRange(l.Ownerships));
                con.Locals.RemoveRange(building.Locals);


                con.Notifications.RemoveRange(building.Notifactions);
                building.Notifactions.ForEach(n => con.Orders.RemoveRange(n.Orders));

                con.CyclicOrders.RemoveRange(building.CyclicOrders);


                con.Buildings.Remove(building);
                con.SaveChanges();
            }
            Update();
        }

        /// <summary>
        /// Edit action
        /// </summary>
        public override void Edit()
        {
            var buildingEditWindow = new BuildingEditWindow(this, SelectedBuilding);
            buildingEditWindow.Show();
        }

        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
        public override bool IsSomethingSelected()
        {
            if (SelectedBuilding != null)
            {
                return true;
            }
            return false;
        }
    }
}
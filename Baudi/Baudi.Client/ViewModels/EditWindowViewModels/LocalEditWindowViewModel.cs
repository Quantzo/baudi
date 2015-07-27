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
    public class LocalEditWindowViewModel : EditWindowViewModel
    {
#region properties
        private List<Building> _buildingsList;
        public List<Building> BuildingsList
        {
            get
            {
                return _buildingsList;
            }
            set
            {
                _buildingsList = value;
                OnPropertyChanged("BuildingsList");
            }
        }
        private Building _selectedBuilding;
        public Building SelectedBuilding
        {
            get
            {
                return _selectedBuilding;
            }
            set
            {
                _selectedBuilding = value;
                OnPropertyChanged("SelectedBuilding");
            }
        }
        private Local _local;
        public Local Local
    {
            get
        {
            return _local;
        }
            set
        {
            _local = value;
            OnPropertyChanged("Local");
        }
    }
#endregion

        public LocalEditWindowViewModel(LocalsTabViewModel localTabViewModel, LocalEditWindow localEditWindow, Local local)
            : base(localTabViewModel, localEditWindow, local)
        {
            using (var con = new BaudiDbContext())
            {
                BuildingsList = con.Buildings.ToList();
                if(Update)
                {
                    Local = con.Locals.Find(local.NotificationTargetID);
                    SelectedBuilding = Local.Building;
                }
                else
                {
                    Local = new Local();
                }
            }
        }


        public override bool IsValid()
        {
            if(SelectedBuilding != null)
            {
                return true;
            }
            return false;
            
        }

        public override void Add()
        {
            using (var con = new BaudiDbContext())
            {
                var building = con.Buildings.Find(SelectedBuilding.NotificationTargetID);

                Local.LocalNumber = Local.LocalNumber;
                Local.RentValue = Local.RentValue;
                Local.NumberOfRooms = Local.NumberOfRooms;
                Local.Area = Local.Area;
                Local.Building = building;

                con.Locals.Add(Local);
                con.SaveChanges();
            }
        }

        public override void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                var building = con.Buildings.Find(SelectedBuilding.NotificationTargetID);

                var local = con.Locals.Find(Local.NotificationTargetID);
                local.LocalNumber = Local.LocalNumber;
                local.RentValue = Local.RentValue;
                local.NumberOfRooms = Local.NumberOfRooms;
                local.Area = Local.Area;
                local.Building = building;

                con.Entry(local).State = EntityState.Modified;

                con.SaveChanges();
            }
        }
    }
}
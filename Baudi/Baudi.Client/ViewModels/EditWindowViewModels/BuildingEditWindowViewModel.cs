using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class BuildingEditWindowViewModel : EditWindowViewModel
    {
        private Building _building;
        public Building Building
        {
            get
            {
                return _building;
            }
            set
            {
                _building = value;
                OnPropertyChanged("Building");
            }
        }

        public BuildingEditWindowViewModel(BuildingsTabViewModel buildingsTabViewModel, BuildingEditWindow buildingEditWindow,Building building)
            :base(buildingsTabViewModel, buildingEditWindow)
        {
            Building = new Building
            {
                NotificationTargetID = building.NotificationTargetID,
                City = building.City,
                HouseNumber = building.HouseNumber,
                Street = building.Street
            }        
        }

        public override void Save()
        {
            if (Building.NotificationTargetID == 0)
            {
                using (var con = new BaudiDbContext())
                {
                    con.Buildings.Add(Building);
                    con.SaveChanges();
                }
            }
            else
            {
                using (var con = new BaudiDbContext())
                {
                    var building = con.Buildings.Find(Building.NotificationTargetID);
                    building.City = Building.City;
                    building.HouseNumber = Building.HouseNumber;
                    building.Street = Building.Street;
                    con.SaveChanges();
                }
            }

            ParentViewModel.Update();
            CloseWindow();
        }

        public override bool IsValid()
        {
            return true;
        }
    }

}
using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class BuildingsTabViewModel : TabViewModel
    {
        private List<Building> _buildingsList;
        public List<Building> BuildingsList
        {
            get { return _buildingsList; }
            set { _buildingsList = value; OnPropertyChanged("BuildingsList"); }
        }

                    public Building SelectedBuilding
        {
            get;
            set;
        }

                    public override void Load()
{
                                    using (var con = new BaudiDbContext())
            {
                BuildingsList = con.Buildings.ToList();

        }
}
        

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Edit()
        {
            throw new NotImplementedException();
        }

        public override bool IsSomethingSelected()
        {
            throw new NotImplementedException();
        }
    }
}

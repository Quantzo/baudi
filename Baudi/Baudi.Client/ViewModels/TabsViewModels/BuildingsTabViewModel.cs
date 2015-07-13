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
    public class BuildingsTabViewModel : INotifyPropertyChanged
    {
        public BuildingsTabViewModel()
        {
            Load();
        }

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

                    public void Load()
{
                                    using (var con = new BaudiDbContext())
            {
            _buildingsList = con.Buildings.ToList();

        }
}



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        } 
    }
}

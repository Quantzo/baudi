using Baudi.Client.View.SelectorWindow;
using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Baudi.Client.ViewModels
{
    class LocalSelectorCode
    {
        LocalSelector thisWindow;
        OwnershipEditWindowCode thisWindowOwner;
        public LocalSelectorCode( LocalSelector thisWindow, OwnershipEditWindowCode ownerWindow, Building selectedBuilding)
        {
            this.thisWindow = thisWindow;
            thisWindowOwner = ownerWindow;
            Button_Click_Cancel = new RelayCommand(pars => Cancel());
            Button_Click_Select = new RelayCommand(pars => Select());
            using (var con = new BaudiDbContext())
            {
                _LocalsList = con.Locals.Where(x => x.Building.BuildingID == selectedBuilding.BuildingID).ToList();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = null;

        private List<Local> _LocalsList;
        public List<Local> LocalsList
        {
            get { return _LocalsList; }
            set { _LocalsList = value; OnPropertyChanged("LocalsList"); }
        }

        public Local SelectedLocal
        {
            get;
            set;
        }

        public ICommand Button_Click_Cancel { get; set; }
        public ICommand Button_Click_Select { get; set; }

        void Cancel()
        {
            thisWindow.Close();
        }

        void Select()
        {
            thisWindowOwner.Update(SelectedLocal, null);
            thisWindow.Close();
        }
        
        virtual public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }	
    }
}
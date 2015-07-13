using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Baudi.Client.View.SelectorWindow;
using Baudi.Client.ViewModels.EditWindowCode;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.SelectorWindowCode
{
    internal class BuildingSelectorCode : INotifyPropertyChanged
    {
        private readonly BuildingSelector thisWindow;

        /// Handler for window combined with this code.
        private readonly OwnershipEditWindowCode thisWindowOwner;

        private List<Building> _BuildingsList;

        /// Handler for MainWindow code.
        /// <summary>
        ///     Constructor - initialize handler, button, and form.
        /// </summary>
        public BuildingSelectorCode(BuildingSelector thisWindow, OwnershipEditWindowCode ownerWindow)
        {
            this.thisWindow = thisWindow;
            thisWindowOwner = ownerWindow;
            Button_Click_Cancel = new RelayCommand(pars => Cancel());
            Button_Click_Select = new RelayCommand(pars => Select());
            using (var con = new BaudiDbContext())
            {
                _BuildingsList = con.Buildings.ToList();
            }
        }

        public List<Building> BuildingsList
        {
            get { return _BuildingsList; }
            set
            {
                _BuildingsList = value;
                OnPropertyChanged("LocalsList");
            }
        }

        public Building SelectedBuilding { get; set; }

        public ICommand Button_Click_Cancel { get; set; }
        public ICommand Button_Click_Select { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void Cancel()
        {
            thisWindow.Close();
        }

        /// <summary>
        ///     Methode for Select button.
        /// </summary>
        private void Select()
        {
            if (SelectedBuilding != null)
            {
                thisWindowOwner.Update(null, SelectedBuilding);
                thisWindow.Close();
            }
            else
                MessageBox.Show("Musisz wybrać budynek.", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        ///     Methode implementation from INotifyPropertyChanged
        /// </summary>
        public virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
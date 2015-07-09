using Baudi.Client.View.SelectorWindow;
using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Baudi.Client.ViewModels
{
    class LocalSelectorCode : INotifyPropertyChanged
    {
        LocalSelector thisWindow; /// Handler for window combined with this code.
        OwnershipEditWindowCode thisWindowOwner; /// Handler for MainWindow code.
                                                 /// 
        /// <summary>
        /// Constructor - initialize handler, button, and form.
        /// </summary>      
        public LocalSelectorCode( LocalSelector thisWindow, OwnershipEditWindowCode ownerWindow, Building selectedBuilding)
        {
            this.thisWindow = thisWindow;
            thisWindowOwner = ownerWindow;
            Button_Click_Cancel = new RelayCommand(pars => Cancel());
            Button_Click_Select = new RelayCommand(pars => Select());
            using (var con = new BaudiDbContext())
            {
                _LocalsList = con.Locals.Where(x => x.Building.NotificationTargetID == selectedBuilding.NotificationTargetID).ToList();
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

        /// <summary>
        /// Methode for Cancel button.
        /// </summary>
        void Cancel()
        {
            thisWindow.Close();
        }

        /// <summary>
        /// Methode for Select button.
        /// </summary>
        void Select()
        {
            if (SelectedLocal != null)
            {
                thisWindowOwner.Update(SelectedLocal, null);
                thisWindow.Close();
            }
            else
                MessageBox.Show("Musisz wybrać lokal.", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// Methode implementation from INotifyPropertyChanged
        /// </summary>
        virtual public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }	
    }
}
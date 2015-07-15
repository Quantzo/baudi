using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Baudi.Client.View.SelectorWindow;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.SelectorWindowCode
{
    internal class LocalSelectorCode : INotifyPropertyChanged
    {
        private readonly LocalSelector thisWindow;

        /// Handler for window combined with this code.
        private readonly OwnershipEditWindowCode thisWindowOwner;

        private List<Local> _LocalsList;

        /// Handler for MainWindow code.
        /// <summary>
        ///     Constructor - initialize handler, button, and form.
        /// </summary>
        public LocalSelectorCode(LocalSelector thisWindow, OwnershipEditWindowCode ownerWindow,
            Building selectedBuilding)
        {
            this.thisWindow = thisWindow;
            thisWindowOwner = ownerWindow;
            Button_Click_Cancel = new RelayCommand(pars => Cancel());
            Button_Click_Select = new RelayCommand(pars => Select());
            using (var con = new BaudiDbContext())
            {
                _LocalsList =
                    con.Locals.Where(x => x.Building.NotificationTargetID == selectedBuilding.NotificationTargetID)
                        .ToList();
            }
        }

        public List<Local> LocalsList
        {
            get { return _LocalsList; }
            set
            {
                _LocalsList = value;
                OnPropertyChanged("LocalsList");
            }
        }

        public Local SelectedLocal { get; set; }

        public ICommand Button_Click_Cancel { get; set; }
        public ICommand Button_Click_Select { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Methode for Cancel button.
        /// </summary>
        private void Cancel()
        {
            thisWindow.Close();
        }

        /// <summary>
        ///     Methode for Select button.
        /// </summary>
        private void Select()
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
        ///     Methode implementation from INotifyPropertyChanged
        /// </summary>
        public virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
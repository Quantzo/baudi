using System.ComponentModel;
using System.Windows.Input;
using Baudi.Client.View.EditWindows;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowCode
{
    public class LocalEditWindowCode
    {
        /// selected Local in MainWindow
        private readonly LocalEditWindow thisWindow;

        /// Handler for window combined with this code.
        private readonly BuildingEditWindowCode thisWindowOwner;

        private double _Area;
        private string _LocalNumber;
        private int _NumberOfRooms;
        private double _RentValue;
        private Local selectedLocal;

        /// Handler for MainWindow code.
        /// <summary>
        ///     Constructor - initialize handler, button, and form.
        /// </summary>
        public LocalEditWindowCode(Local selectedLocal, LocalEditWindow thisWindow,
            BuildingEditWindowCode thisWindowOwner)
        {
            this.selectedLocal = selectedLocal;
            this.thisWindow = thisWindow;
            this.thisWindowOwner = thisWindowOwner;
            Button_Click_Cancel = new RelayCommand(pars => Cancel());
            Button_Click_Save = new RelayCommand(pars => Save());
            if (selectedLocal != null)
            {
                _LocalNumber = selectedLocal.LocalNumber;
                _RentValue = selectedLocal.RentValue;
                _Area = selectedLocal.Area;
                _NumberOfRooms = selectedLocal.NumberOfRooms;
            }
        }

        public ICommand Button_Click_Cancel { get; set; }
        public ICommand Button_Click_Save { get; set; }

        public string LocalNumber
        {
            get { return _LocalNumber; }
            set
            {
                _LocalNumber = value;
                OnPropertyChanged("LocalNumber");
            }
        }

        public double RentValue
        {
            get { return _RentValue; }
            set
            {
                _RentValue = value;
                OnPropertyChanged("RentValue");
            }
        }

        public int NumberOfRooms
        {
            get { return _NumberOfRooms; }
            set
            {
                _NumberOfRooms = value;
                OnPropertyChanged("NumberOfRooms");
            }
        }

        public double Area
        {
            get { return _Area; }
            set
            {
                _Area = value;
                OnPropertyChanged("Area");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Methode for Cancel button.
        /// </summary>
        private void Cancel()
        {
            thisWindow.Close();
        }

        /// <summary>
        ///     Methode for Save button.
        /// </summary>
        private void Save()
        {
            var b = new Local();
            b.LocalNumber = LocalNumber;
            b.RentValue = RentValue;
            b.NumberOfRooms = NumberOfRooms;
            b.Area = Area;
            thisWindowOwner.Update(b);
            thisWindow.Close();
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
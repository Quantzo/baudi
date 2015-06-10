using Baudi.DAL;
using Baudi.DAL.Models;
using GUIBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Baudi.Client.ViewModels
{
    public class LocalEditWindowCode
    {

        Local selectedLocal; ///selected Local in MainWindow
        LocalEditWindow thisWindow; ///Handler for window combined with this code.
        BuildingEditWindowCode thisWindowOwner; ///Handler for MainWindow code.

        /// <summary>
        /// Constructor - initialize handler, button, and form.
        /// </summary>
        public LocalEditWindowCode(Local selectedLocal, LocalEditWindow thisWindow, BuildingEditWindowCode thisWindowOwner)
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

        public event PropertyChangedEventHandler PropertyChanged = null;

        private string _LocalNumber;
        public string LocalNumber
        {
            get { return _LocalNumber; }
            set { _LocalNumber = value; OnPropertyChanged("LocalNumber"); }
        }

        private double _RentValue;
        public double RentValue
        {
            get { return _RentValue; }
            set { _RentValue = value; OnPropertyChanged("RentValue"); }
        }

        private int _NumberOfRooms;
        public int NumberOfRooms
        {
            get { return _NumberOfRooms; }
            set { _NumberOfRooms = value; OnPropertyChanged("NumberOfRooms"); }
        }

        private double _Area;
        public double Area
        {
            get { return _Area; }
            set { _Area = value; OnPropertyChanged("Area");}
        }

        /// <summary>
        /// Methode for Cancel button.
        /// </summary>
        void Cancel()
        {
            thisWindow.Close();
        }

        /// <summary>
        /// Methode for Save button.
        /// </summary>
        void Save()
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
        /// Methode implementation from INotifyPropertyChanged
        /// </summary>
        virtual public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }	
    }
}

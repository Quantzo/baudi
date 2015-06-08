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

        Local selectedLocal;
        LocalEditWindow thisWindow;
        BuildingEditWindowCode thisWindowOwner;

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

        void Cancel()
        {
            thisWindow.Close();
        }

        void Save()
        {
            using (var con = new BaudiDbContext())
            {
                if (selectedLocal != null)
                {
                    var orginal = con.Locals.Find(selectedLocal.LocalID);
                    if (orginal != null)
                    {
                        orginal.LocalID = selectedLocal.LocalID;
                        orginal.LocalNumber = LocalNumber;
                        orginal.NumberOfRooms = NumberOfRooms;
                        orginal.Area = Area;
                        orginal.RentValue = RentValue;
                        thisWindowOwner.Update(orginal);
                    }
                }
                else
                {
                    var b = new Local();
                    b.LocalNumber = LocalNumber;
                    b.RentValue = RentValue;
                    b.NumberOfRooms = NumberOfRooms;
                    b.Area = Area;
                    thisWindowOwner.Update(b);
                }
                con.SaveChanges();
            }            
            thisWindow.Close();
        }

        virtual public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }	
    }
}

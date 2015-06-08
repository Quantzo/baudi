using Baudi.DAL;
using Baudi.DAL.Models;
using GUIBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApplication1;

namespace Baudi.Client.ViewModels
{
    public class BuildingEditWindowCode : INotifyPropertyChanged
    {
        Building selectedBuilding;
        BuildingEditWindow thisWindow;
        MainWindowCode thisWindowOwner;
        List<Local> addedLocal;
        List<Local> updatedLocal;
        public BuildingEditWindowCode(Building selectedBuilding, BuildingEditWindow thisWindow, MainWindowCode thisWindowOwner)
        {
            this.selectedBuilding = selectedBuilding;
            this.thisWindow = thisWindow;
            this.thisWindowOwner = thisWindowOwner;
            addedLocal = new List<Local>();
            updatedLocal = new List<Local>();
            Button_Click_Cancel = new RelayCommand(pars => Cancel());
            Button_Click_Save = new RelayCommand(pars => Save());
            Button_Click_Add = new RelayCommand(pars => Add());
            Button_Click_Edit = new RelayCommand(pars => Edit());
            Button_Click_Delete = new RelayCommand(pars => Delete());

            if (selectedBuilding != null)
            {
                _City = selectedBuilding.City;
                _HouseNumber = selectedBuilding.HouseNumber;
                _Street = selectedBuilding.Street;
                _LocalsList = selectedBuilding.Locals;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = null;

        private String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; OnPropertyChanged("City"); }
        }

        private String _HouseNumber;
        public String HouseNumber
        {
            get { return _HouseNumber; }
            set { _HouseNumber = value; OnPropertyChanged("HouseNumber"); }
        }

        private String _Street;
        public String Street
        {
            get { return _Street; }
            set { _Street = value; OnPropertyChanged("Street"); }
        }

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
        public ICommand Button_Click_Save { get; set; }
        public ICommand Button_Click_Add { get; set; }
        public ICommand Button_Click_Edit { get; set; }
        public ICommand Button_Click_Delete { get; set; }


        void Cancel()
        {
            thisWindow.Close();
        }

        void Save()
        {
            using (var con = new BaudiDbContext())
            {
                if (selectedBuilding != null)
                {
                    var orginal = con.Buildings.Find(selectedBuilding.BuildingID);
                    if (orginal != null)
                    {
                        orginal.BuildingID = selectedBuilding.BuildingID;
                        orginal.City = _City;
                        orginal.HouseNumber = _HouseNumber;
                        orginal.Street = _Street;
                        //add new locals
                        if (addedLocal.Count != 0)
                        {
                            foreach (Local l in addedLocal)
                            {
                                l.Building = orginal;
                            }
                            con.Locals.AddRange(addedLocal);
                        }
                        //updatelocals
                        if (updatedLocal.Count != 0)
                        {
                            foreach(Local l in updatedLocal)
                            {
                                Local temp = con.Locals.Find(l.LocalID);
                                temp.LocalNumber = l.LocalNumber;
                                temp.NumberOfRooms = l.NumberOfRooms;
                                temp.RentValue = l.RentValue;
                                temp.Area = l.Area;
                            }
                        }
                    }
                }
                else
                {
                    Building b = new Building();
                    b.City = _City;
                    b.HouseNumber = _HouseNumber;
                    b.Street = _Street;
                    b.Locals = _LocalsList;
                    con.Buildings.Add(b);
                    if (addedLocal.Count != 0)
                    {
                        foreach (Local l in addedLocal)
                        {
                            l.Building = b;
                        }
                        con.Locals.AddRange(addedLocal);
                    }
                    if (updatedLocal.Count != 0)
                    {
                        foreach (Local l in updatedLocal)
                        {
                            Local temp = con.Locals.Find(l.LocalID);
                            temp.LocalNumber = l.LocalNumber;
                            temp.NumberOfRooms = l.NumberOfRooms;
                            temp.RentValue = l.RentValue;
                            temp.Area = l.Area;
                        }
                    }
                }
                con.SaveChanges();
            }

            thisWindowOwner.Update();
            thisWindow.Close();
        }
        
        void Add()
        {
            Local b = null;
            LocalEditWindow bew = new LocalEditWindow(b, this);
            bew.Show();
        }

        void Edit()
        {
            Local b = LocalsList.Find(x => x.LocalID.Equals(SelectedLocal.LocalID));
            LocalEditWindow bew = new LocalEditWindow(b, this);
            bew.Show();
        }

        void Delete()
        {
            Local b = LocalsList.Find(x => x.LocalID.Equals(SelectedLocal.LocalID));
            LocalsList.Remove(b);
        }

        public void Update(Local b)
        {
            if (SelectedLocal == null)
            {
                List<Local> actualList = new List<Local>();
                addedLocal.Add(b);
                actualList.Add(b);
                if (LocalsList != null)
                {
                    actualList.AddRange(LocalsList);
                    LocalsList = actualList;
                }
                else
                    LocalsList = addedLocal;
            }
            else
            {

                List<Local> actualList = new List<Local>();
                updatedLocal.Add(b);
                actualList.AddRange(LocalsList);
                Local orginal = actualList.Find(x => x.LocalID == b.LocalID);
                orginal.LocalNumber = b.LocalNumber;
                orginal.Area = b.Area;
                orginal.NumberOfRooms = b.NumberOfRooms;
                orginal.RentValue = b.RentValue;
                LocalsList = actualList;
            }
        }


        virtual public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }	
    }
}

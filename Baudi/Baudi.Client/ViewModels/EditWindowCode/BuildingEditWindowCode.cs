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
        Building selectedBuilding; ///Selected Building in MainWindow.
        BuildingEditWindow thisWindow; ///Handler for window combined with this code.
        MainWindowViewModel thisWindowOwner; ///Handler for MainWindow code.
        List<Local> addedLocal; // list with added Local
        List<Local> updatedLocal; //list with updated Local
        List<Local> deletedLocal; //list with deleted Local
        bool update;

        /// <summary>
        /// Constructor - initialize handler, button, and form.
        /// </summary>
        /// <param name="selectedBuilding"></param>
        /// <param name="thisWindow"></param>
        /// <param name="thisWindowOwner"></param>
        public BuildingEditWindowCode(Building selectedBuilding, BuildingEditWindow thisWindow, MainWindowViewModel thisWindowOwner)
        {
            this.selectedBuilding = selectedBuilding;
            this.thisWindow = thisWindow;
            this.thisWindowOwner = thisWindowOwner;

            addedLocal = new List<Local>();
            updatedLocal = new List<Local>();
            deletedLocal = new List<Local>();

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
            using (var con = new BaudiDbContext())
            {
                //if building was selecteted
                if (selectedBuilding != null)
                {
                    var orginal = con.Buildings.Find(selectedBuilding.NotificationTargetID);
                    if (orginal != null)
                    {
                        orginal.NotificationTargetID = selectedBuilding.NotificationTargetID;
                        orginal.City = _City;
                        orginal.HouseNumber = _HouseNumber;
                        orginal.Street = _Street;
                        orginal.Locals.AddRange(addedLocal);
                        if (updatedLocal.Count != 0)
                        {
                            foreach(Local l in updatedLocal)
                            {
                                Local temp = con.Locals.Find(l.NotificationTargetID);
                                temp.LocalNumber = l.LocalNumber;
                                temp.NumberOfRooms = l.NumberOfRooms;
                                temp.RentValue = l.RentValue;
                                temp.Area = l.Area;
                            }
                        }
                    }
                }
                //if building was not select
                else
                {
                    Building b = new Building();
                    b.City = _City;
                    b.HouseNumber = _HouseNumber;
                    b.Street = _Street;
                    b.Locals = _LocalsList;
                    con.Buildings.Add(b);
                    if (updatedLocal.Count != 0)
                    {
                        foreach (Local l in updatedLocal)
                        {
                            Local temp = con.Locals.Find(l.NotificationTargetID);
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

        /// <summary>
        /// Methode for Add button.
        /// </summary>
        void Add()
        {
            update = false;
            Local b = null;
            LocalEditWindow bew = new LocalEditWindow(b, this);
            bew.Show();
        }

        /// <summary>
        /// Methode for Edit button.
        /// </summary>
        void Edit()
        {
            update = true;
            if (SelectedLocal == null)
            {
                Local b = LocalsList.Find(x => x.NotificationTargetID.Equals(SelectedLocal.NotificationTargetID));
                LocalEditWindow bew = new LocalEditWindow(SelectedLocal, this);
                bew.Show();
            }
            else
            {
                MessageBox.Show("Musisz wybrać lokal żeby edytować", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Methode for Delete button.
        /// </summary>
        void Delete()
        {
            Local b = LocalsList.Find(x => x.NotificationTargetID.Equals(SelectedLocal.NotificationTargetID));
            LocalsList.Remove(b);
        }

        /// <summary>
        /// Methode for update LocalsList
        /// </summary>
        public void Update(Local b)
        {
            //if local is update
            if (update == false)
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
                {
                    LocalsList = addedLocal;
                }
            }
            //if local is add
            else
            {
                List<Local> actualList = new List<Local>();
                updatedLocal.Add(b);
                actualList.AddRange(LocalsList);
                Local orginal = actualList.Find(x => x.NotificationTargetID == b.NotificationTargetID);
                orginal.LocalNumber = b.LocalNumber;
                orginal.Area = b.Area;
                orginal.NumberOfRooms = b.NumberOfRooms;
                orginal.RentValue = b.RentValue;
                LocalsList = actualList;
            }
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

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowCode
{
    public class BuildingEditWindowCode : INotifyPropertyChanged
    {
        /// Handler for MainWindow code.
        private readonly List<Local> addedLocal; // list with added Local

        private readonly Building selectedBuilding;

        /// Selected Building in MainWindow.
        private readonly BuildingEditWindow thisWindow;

        /// Handler for window combined with this code.
        private readonly MainWindowViewModel thisWindowOwner;

        private readonly List<Local> updatedLocal; //list with updated Local
        private string _City;
        private string _HouseNumber;
        private List<Local> _LocalsList;
        private string _Street;
        private List<Local> deletedLocal; //list with deleted Local
        private bool update;

        /// <summary>
        ///     Constructor - initialize handler, button, and form.
        /// </summary>
        /// <param name="selectedBuilding"></param>
        /// <param name="thisWindow"></param>
        /// <param name="thisWindowOwner"></param>
        public BuildingEditWindowCode(Building selectedBuilding, BuildingEditWindow thisWindow,
            MainWindowViewModel thisWindowOwner)
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

        public string City
        {
            get { return _City; }
            set
            {
                _City = value;
                OnPropertyChanged("City");
            }
        }

        public string HouseNumber
        {
            get { return _HouseNumber; }
            set
            {
                _HouseNumber = value;
                OnPropertyChanged("HouseNumber");
            }
        }

        public string Street
        {
            get { return _Street; }
            set
            {
                _Street = value;
                OnPropertyChanged("Street");
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
        public ICommand Button_Click_Save { get; set; }
        public ICommand Button_Click_Add { get; set; }
        public ICommand Button_Click_Edit { get; set; }
        public ICommand Button_Click_Delete { get; set; }
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
                            foreach (var l in updatedLocal)
                            {
                                var temp = con.Locals.Find(l.NotificationTargetID);
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
                    var b = new Building();
                    b.City = _City;
                    b.HouseNumber = _HouseNumber;
                    b.Street = _Street;
                    b.Locals = _LocalsList;
                    con.Buildings.Add(b);
                    if (updatedLocal.Count != 0)
                    {
                        foreach (var l in updatedLocal)
                        {
                            var temp = con.Locals.Find(l.NotificationTargetID);
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
        ///     Methode for Add button.
        /// </summary>
        private void Add()
        {
            update = false;
            Local b = null;
            var bew = new LocalEditWindow(b, this);
            bew.Show();
        }

        /// <summary>
        ///     Methode for Edit button.
        /// </summary>
        private void Edit()
        {
            update = true;
            if (SelectedLocal == null)
            {
                var b = LocalsList.Find(x => x.NotificationTargetID.Equals(SelectedLocal.NotificationTargetID));
                var bew = new LocalEditWindow(SelectedLocal, this);
                bew.Show();
            }
            else
            {
                MessageBox.Show("Musisz wybrać lokal żeby edytować", "Ostrzeżenie", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        /// <summary>
        ///     Methode for Delete button.
        /// </summary>
        private void Delete()
        {
            var b = LocalsList.Find(x => x.NotificationTargetID.Equals(SelectedLocal.NotificationTargetID));
            LocalsList.Remove(b);
        }

        /// <summary>
        ///     Methode for update LocalsList
        /// </summary>
        public void Update(Local b)
        {
            //if local is update
            if (update == false)
            {
                var actualList = new List<Local>();
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
                var actualList = new List<Local>();
                updatedLocal.Add(b);
                actualList.AddRange(LocalsList);
                var orginal = actualList.Find(x => x.NotificationTargetID == b.NotificationTargetID);
                orginal.LocalNumber = b.LocalNumber;
                orginal.Area = b.Area;
                orginal.NumberOfRooms = b.NumberOfRooms;
                orginal.RentValue = b.RentValue;
                LocalsList = actualList;
            }
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
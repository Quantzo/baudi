﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baudi.DAL;
using Baudi.DAL.Models;
using System.Windows.Input;
using GUIBD;
using System.Data;
using WpfApplication1;
using System.Windows;

namespace Baudi.Client.ViewModels
{
    public class MainWindowCode : INotifyPropertyChanged
    {
        public MainWindowCode()
        {
            Load();
            Button_Click_Add = new RelayCommand(pars => Add());
            Button_Click_Edit = new RelayCommand(pars => Edit());
            Button_Click_Delete = new RelayCommand(pars => Delete());
        }

        public event PropertyChangedEventHandler PropertyChanged = null;
        private List<Building> _BuildingsList;
        public List<Building> BuildingsList
        {
            get { return _BuildingsList; }
            set { _BuildingsList = value; OnPropertyChanged("BuildingsList"); }
        }

        private List<Person> _OwnersList;
        public List<Person> OwnersList
        {
            get { return _OwnersList; }
        }

        private List<Employee> _EmployeesList;
        public List<Employee> EmployeesList
        {
            get { return _EmployeesList; }
        }

        private List<Notification> _NotificationsList;
        public List<Notification> NotificationsList
        {
            get { return _NotificationsList; }
        }
        private List<Company> _CompaniesList;
        public List<Company> CompaniesList
        {
            get { return _CompaniesList; }
            set { _CompaniesList = value; OnPropertyChanged("BuildingsList"); }
        }

        public int SelectedTabIndex
        {
            get;
            set;
        }

        public Building SelectedBuilding
        {
            get;
            set;
        }

        public Company SelectedCompany
        {
            get;
            set;
        }

        public ICommand Button_Click_Add { get; set; }
        public ICommand Button_Click_Edit { get; set; }
        public ICommand Button_Click_Delete { get; set; }

        void Load()
        {
            using (var con = Connection.Con)
            {
                 _BuildingsList = con.Buildings.ToList();
                 _OwnersList = con.Peoples.ToList();
                 _EmployeesList = con.Employees.ToList();
                 _NotificationsList = con.Notifications.ToList();
                 _CompaniesList = con.Companies.ToList();
            }
        }

        void Add()
        {
            if (SelectedTabIndex == (int)SelectedTabItem.Buildings)
            {
                Building c = null;
                BuildingEditWindow bew = new BuildingEditWindow(c, this);
                bew.Show();
            }
            if(SelectedTabIndex == (int)SelectedTabItem.Companies)
            {
                Company c = null;
                CompanyEditWindow cew = new CompanyEditWindow(c, this);
                cew.Show();
            }
        }

        void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                if (SelectedTabIndex == (int)SelectedTabItem.Buildings)
                {
                    Building b = con.Buildings.Find(SelectedBuilding.BuildingID);
                    BuildingEditWindow bew = new BuildingEditWindow(b, this);
                    bew.Show();
                }
                if (SelectedTabIndex == (int)SelectedTabItem.Companies)
                {
                    Company b = con.Companies.Find(SelectedCompany.CompanyID);
                    CompanyEditWindow cew = new CompanyEditWindow(b, this);
                    cew.Show();
                }
            }
        }
        
        void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                if (SelectedTabIndex == (int)SelectedTabItem.Buildings)
                {
                    Building b = con.Buildings.Find(SelectedBuilding.BuildingID);
                    con.Buildings.Remove(b);
                }
                if(SelectedTabIndex == (int)SelectedTabItem.Companies)
                {
                    Company c = con.Companies.Find(SelectedCompany.CompanyID);
                    con.Companies.Remove(c);
                }
            }
        }

        public void Update()
        {
            using (var con = new BaudiDbContext())
            {
                if (SelectedTabIndex == (int)SelectedTabItem.Buildings)
                {
                    BuildingsList = con.Buildings.ToList();
                }
                if (SelectedTabIndex == (int)SelectedTabItem.Companies)
                {
                    CompaniesList = con.Companies.ToList();
                }
            }
        }

        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        enum SelectedTabItem 
        {
            Notifications = 0,
            Companies = 1,
            Orders = 2,
            CyclicOrders = 3,
            Buildings = 5,
            Owners = 6,
            Employees = 7,
            Payments = 9,
            Raport = 10,
            Dictionery = 11
        };
    }
}

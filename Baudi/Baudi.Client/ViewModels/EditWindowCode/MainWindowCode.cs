using System;
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
using System.Data.Entity;
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
            set { _OwnersList = value; OnPropertyChanged("OwnersList"); }
        }

        private List<Employee> _EmployeesList;
        public List<Employee> EmployeesList
        {
            get { return _EmployeesList; }
            set { _EmployeesList = value; OnPropertyChanged("EmployeesList"); }
        }

        private List<Notification> _NotificationsList;
        public List<Notification> NotificationsList
        {
            get { return _NotificationsList; }
            set { _NotificationsList = value; OnPropertyChanged("NotificationsList"); }
        }
        private List<Company> _CompaniesList;
        public List<Company> CompaniesList
        {
            get { return _CompaniesList; }
            set { _CompaniesList = value; OnPropertyChanged("CompaniesList"); }
        }


        private List<Order> _OrdersList;
        public List<Order> OrdersList
        {
            get { return _OrdersList; }
            set { _OrdersList = value; OnPropertyChanged("OrdersList"); }
        }



        private List<OrderType> _OrderTypesList;
        public List<OrderType> OrderTypesList
        {
            get { return _OrderTypesList; }
            set { _OrderTypesList = value; OnPropertyChanged("OrdersTypesList"); }
        }

        private List<CyclicOrder> _CyclicOrdersList;
        public List<CyclicOrder> CyclicOrdersList
        {
            get { return _CyclicOrdersList; }
            set { _CyclicOrdersList = value; OnPropertyChanged("CyclicOrdersList"); }
        }



        private List<Expense> _ExpensesList;
        public List<Expense> ExpensesList
        {
            get { return _ExpensesList; }
            set { _ExpensesList = value; OnPropertyChanged("ExpensesList"); }
        }



        private List<Expense> _ExpensesOrderList;
        public List<Expense> ExpensesOrderList
        {
            get { return _ExpensesOrderList; }
            set { _ExpensesOrderList = value; OnPropertyChanged("ExpensesOrderList"); }
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

        public Employee SelectedEmployee
        {
            get;
            set;
        }

        public Person SelectedOwner
        {
            get;
            set;
        }

        public Order SelectedOrder
        {
            get;
            set;
        }

        public CyclicOrder SelectedCyclicOrder
        {
            get;
            set;
        }

        public ICommand Button_Click_Add { get; set; }
        public ICommand Button_Click_Edit { get; set; }
        public ICommand Button_Click_Delete { get; set; }

        void Load()
        {
            using (var con = new BaudiDbContext())
            {
                 _BuildingsList = con.Buildings.ToList();
                 _OwnersList = con.Peoples.Where(x => x.Ownerships.Count != 0).ToList();
                 _EmployeesList = con.Employees.ToList();
                 _NotificationsList = con.Notifications.ToList();
                 _CompaniesList = con.Companies.ToList();
                 _OrdersList = con.Orders.ToList();
                 _OrderTypesList = con.OrderTypes.ToList();
                 _CyclicOrdersList = con.CyclicOrders.ToList();



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
            if(SelectedTabIndex == (int)SelectedTabItem.Employees)
            {
                Employee e = null;
                EmployeeEditWindow eew = new EmployeeEditWindow(e, this);
                eew.Show();
            }
            if(SelectedTabIndex == (int)SelectedTabItem.Owners)
            {
                Person o = null;
                OwnerEditWindow oew = new OwnerEditWindow(o, this);
                oew.Show();
            }
        }

        void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                if (SelectedTabIndex == (int)SelectedTabItem.Buildings)
                {
                    if (SelectedBuilding != null)
                    {
                        Building b = con.Buildings.Find(SelectedBuilding.NotificationTargetID);
                        BuildingEditWindow bew = new BuildingEditWindow(b, this);
                        bew.Show();
                    }
                    else
                        MessageBox.Show("Musisz wybrać budynek żeby edytować", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (SelectedTabIndex == (int)SelectedTabItem.Companies)
                {
                    if (SelectedCompany != null)
                    {
                        Company b = con.Companies.Find(SelectedCompany.CompanyID);
                        CompanyEditWindow cew = new CompanyEditWindow(b, this);
                        cew.Show();
                    }
                    else MessageBox.Show("Musisz wybrać firmę żeby edytować", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                if (SelectedTabIndex == (int)SelectedTabItem.Employees)
                {
                    if (SelectedEmployee != null)
                    {
                        Employee e = con.Employees.Find(SelectedEmployee.OwnerID);
                        EmployeeEditWindow eew = new EmployeeEditWindow(e, this);
                        eew.Show();
                    }
                    else
                        MessageBox.Show("Musisz wybrać pracownika żeby edytować", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if(SelectedTabIndex == (int)SelectedTabItem.Owners)
                {
                    if (SelectedOwner != null)
                    {
                        Person p = con.Peoples.Find(SelectedOwner.OwnerID);
                        OwnerEditWindow oew = new OwnerEditWindow(p, this);
                        oew.Show();
                    }
                    else
                        MessageBox.Show("Musisz wybrać owłaściciela żeby edytować", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        
        void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                if (SelectedTabIndex == (int)SelectedTabItem.Buildings)
                {
                    Building b = con.Buildings.Find(SelectedBuilding.NotificationTargetID);
                    b.CyclicOrders.ForEach(co => con.Expenses.RemoveRange(co.Expenses));
                    b.Locals.ForEach(l => con.Notifications.RemoveRange(l.Notifactions));
                    con.CyclicOrders.RemoveRange(b.CyclicOrders);
                    
                    b.CyclicOrders.Clear();
                    con.Buildings.Remove(b);
                }
                if(SelectedTabIndex == (int)SelectedTabItem.Companies)
                {
                    Company c = con.Companies.Find(SelectedCompany.CompanyID);
                    c.CyclicOrders.Clear();
                    c.Orders.Clear();
                   con.Companies.Remove(c);
                }
                if(SelectedTabIndex == (int)SelectedTabItem.Employees)
                {
                    Employee e = con.Employees.Find(SelectedEmployee.OwnerID);
                    con.Salaries.RemoveRange(e.Salaries);

                    Dispatcher d = e as Dispatcher;
                    Menager m = e as Menager;
                    if (d != null)
                    {
                        d.DispatcherNotifications.Clear();
                        con.Employees.Remove(d);
                    }
                    else if (m != null)
                    {
                        m.MenagerExpenses.Clear();
                        m.CyclicOrders.Clear();
                        m.Orders.Clear();
                        con.Employees.Remove(m);
                    }
                    else
                    {
                        con.Employees.Remove(e);
                    }
                }
                if(SelectedTabIndex == (int)SelectedTabItem.Owners)
                {
                    Person p = con.Employees.Find(SelectedOwner.OwnerID);
                    Employee e = (Employee) p;
                    if (e != null)
                    {
                        con.Salaries.RemoveRange(e.Salaries);
                        Dispatcher d = e as Dispatcher;
                        Menager m = e as Menager;
                        if (d != null)
                        {
                            d.DispatcherNotifications.Clear();
                            con.Employees.Remove(d);
                        }
                        else if (m != null)
                        {
                            m.MenagerExpenses.Clear();
                            m.CyclicOrders.Clear();
                            m.Orders.Clear();
                            con.Employees.Remove(m);
                        }
                        else
                        {
                            con.Employees.Remove(e);
                        }
                    }
                    else
                    {
                        con.Peoples.Remove(p);
                    }
                    
                }
                con.SaveChanges();
                Update();
            }
        }

        public void Update()
        {
            using (var con = new BaudiDbContext())
            {

                    BuildingsList = con.Buildings.ToList();
                    NotificationsList = con.Notifications.ToList();
                    CompaniesList = con.Companies.ToList();
                    EmployeesList = con.Employees.ToList();
                    OwnersList = con.Peoples.Where(x => x.Ownerships.Count != 0).ToList();
                    OrdersList = con.Orders.ToList();
                    

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

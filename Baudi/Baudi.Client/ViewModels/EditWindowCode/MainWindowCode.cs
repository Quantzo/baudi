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
using Baudi.Client.ViewModels.TabsViewModels;

namespace Baudi.Client.ViewModels
{
    public class MainWindowCode : INotifyPropertyChanged
    {
        public BuildingsTabViewModel BuildingsTabViewModel {get; set;}
        public CompaniesTabViewModel CompaniesTabViewModel { get; set; }
        public CyclicOrdersTabViewModel CyclicOrdersTabViewModel { get; set; }
        public DictionariesTabViewModel DictionariesTabViewModel { get; set; }
        public EmployeesTabViewModel EmployeesTabViewModel { get; set; }
        public ExpensesTabViewModel ExpensesTabViewModel { get; set; }
        public NotificationsTabViewModel NotificationsTabViewModel { get; set; }
        public OrdersTabViewModel OrdersTabViewModel { get; set; }
        public OwnersTabViewModel OwnersTabViewModel { get; set; }
        public OwningCompaniesTabViewModel OwningCompaniesTabViewModel { get; set; }
        public RentsTabViewModel RentsTabViewModel { get; set; }
        public ReportsTabViewModel ReportsTabViewModel { get; set; }
        public SalariesTabViewModel SalariesTabViewModel { get; set; }




        public MainWindowCode()
        {
            Load();
            Button_Click_Add = new RelayCommand(pars => Add());
            Button_Click_Edit = new RelayCommand(pars => Edit());
            Button_Click_Delete = new RelayCommand(pars => Delete());
        }

        public event PropertyChangedEventHandler PropertyChanged;       

        

        private List<OrderType> _OrderTypesList;
        public List<OrderType> OrderTypesList
        {
            get { return _OrderTypesList; }
            set { _OrderTypesList = value; OnPropertyChanged("OrdersTypesList"); }
        }

        private List<Ownership> _OwnershipsList;
        public List<Ownership> OwnershipsList
        {
            get { return _OwnershipsList; }
            set { _OwnershipsList = value; OnPropertyChanged("OwnershipsList"); }
        }

        public int SelectedTabIndex
        {
            get;
            set;
        }

        public ICommand Button_Click_Add { get; set; }
        public ICommand Button_Click_Edit { get; set; }
        public ICommand Button_Click_Delete { get; set; }

        void Load()
        {
BuildingsTabViewModel = new BuildingsTabViewModel();
CompaniesTabViewModel = new CompaniesTabViewModel();
CyclicOrdersTabViewModel = new CyclicOrdersTabViewModel();
DictionariesTabViewModel = new DictionariesTabViewModel();
EmployeesTabViewModel = new EmployeesTabViewModel();
ExpensesTabViewModel = new ExpensesTabViewModel();
NotificationsTabViewModel = new NotificationsTabViewModel();
OrdersTabViewModel = new OrdersTabViewModel();
OwnersTabViewModel = new OwnersTabViewModel();
OwningCompaniesTabViewModel = new OwningCompaniesTabViewModel();
RentsTabViewModel =  new RentsTabViewModel();
ReportsTabViewModel = new ReportsTabViewModel();
SalariesTabViewModel = new SalariesTabViewModel();


            using (var con = new BaudiDbContext())
            {
                _OrderTypesList = con.OrderTypes.ToList();
                _OwnershipsList = con.Ownerships.ToList();
            }
        }

        void Add()
        {

        }

        void Edit()
        {
            
        }
        
        void Delete()
        {
            
        }

        public void Update()
        {

        }

        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
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

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
    public class MainWindowViewModel : INotifyPropertyChanged
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




        public MainWindowViewModel()
        {
            Load();
        }

        public event PropertyChangedEventHandler PropertyChanged;       

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

        }

        public void Update()
        {

        }

        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        } 

    }
}

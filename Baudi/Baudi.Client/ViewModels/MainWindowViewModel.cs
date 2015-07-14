using System.ComponentModel;
using Baudi.Client.ViewModels.TabsViewModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Baudi.Client.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            Load();
        }
        public List<TabViewModel> TabsViewModels { get; set; }
        public BuildingsTabViewModel BuildingsTabViewModel { get; set; }
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
        public event PropertyChangedEventHandler PropertyChanged;

        private void Load()
        {
            TabsViewModels = new List<TabViewModel>();
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
            RentsTabViewModel = new RentsTabViewModel();
            ReportsTabViewModel = new ReportsTabViewModel();
            SalariesTabViewModel = new SalariesTabViewModel();


            TabsViewModels.Add(BuildingsTabViewModel);
            TabsViewModels.Add(CompaniesTabViewModel);
            TabsViewModels.Add(CyclicOrdersTabViewModel);
            //TabsViewModels.Add(DictionariesTabViewModel);
            TabsViewModels.Add(EmployeesTabViewModel);
            TabsViewModels.Add(ExpensesTabViewModel);
            TabsViewModels.Add(NotificationsTabViewModel);
            TabsViewModels.Add(OrdersTabViewModel);
            TabsViewModels.Add(OwnersTabViewModel);
            TabsViewModels.Add(OwningCompaniesTabViewModel);
            TabsViewModels.Add(RentsTabViewModel);
            //TabsViewModels.Add(ReportsTabViewModel);
            TabsViewModels.Add(SalariesTabViewModel);

            TabsViewModels.ForEach(vm => vm.PropertyChanged += OnMemberViewModelPropertyChanged);


            
        }

        public void Update()
        {

        }

        private void OnMemberViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Update")
            {
                TabsViewModels.ForEach(vm => vm.Load());
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
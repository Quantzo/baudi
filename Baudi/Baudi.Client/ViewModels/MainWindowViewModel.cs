using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Baudi.Client.Helpers;
using Baudi.Client.ViewModels.TabsViewModels;

namespace Baudi.Client.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            ContextHelp = new RelayCommand(pars => ContextHelpHelper.ContextHelp());
            Load();
        }

        public List<TabViewModel> TabsViewModels { get; set; }
        public BuildingsTabViewModel BuildingsTabViewModel { get; set; }
        public CompaniesTabViewModel CompaniesTabViewModel { get; set; }
        public CyclicOrdersTabViewModel CyclicOrdersTabViewModel { get; set; }
        public EmployeesTabViewModel EmployeesTabViewModel { get; set; }
        public ExpensesTabViewModel ExpensesTabViewModel { get; set; }
        public LocalsTabViewModel LocalsTabViewModel { get; set; }
        public NotificationsTabViewModel NotificationsTabViewModel { get; set; }
        public OrdersTabViewModel OrdersTabViewModel { get; set; }
        public OrderTypesTabViewModel OrderTypesTabViewModel { get; set; }
        public OwnershipsTabViewModel OwnershipsTabViewModel { get; set; }
        public PeopleTabViewModel PeopleTabViewModel { get; set; }
        public OwningCompaniesTabViewModel OwningCompaniesTabViewModel { get; set; }
        public RentsTabViewModel RentsTabViewModel { get; set; }
        public ReportsTabViewModel ReportsTabViewModel { get; set; }
        public SalariesTabViewModel SalariesTabViewModel { get; set; }
        public SpecializationsTabViewModel SpecializationsTabViewModel { get; set; }

        public ICommand ContextHelp { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Load()
        {
            


            TabsViewModels = new List<TabViewModel>();
            BuildingsTabViewModel = new BuildingsTabViewModel();
            CompaniesTabViewModel = new CompaniesTabViewModel();
            CyclicOrdersTabViewModel = new CyclicOrdersTabViewModel();
            EmployeesTabViewModel = new EmployeesTabViewModel();
            ExpensesTabViewModel = new ExpensesTabViewModel();
            LocalsTabViewModel = new LocalsTabViewModel();
            NotificationsTabViewModel = new NotificationsTabViewModel();
            OrdersTabViewModel = new OrdersTabViewModel();
            OrderTypesTabViewModel = new OrderTypesTabViewModel();
            OwnershipsTabViewModel = new OwnershipsTabViewModel();
            PeopleTabViewModel = new PeopleTabViewModel();
            OwningCompaniesTabViewModel = new OwningCompaniesTabViewModel();
            RentsTabViewModel = new RentsTabViewModel();
            ReportsTabViewModel = new ReportsTabViewModel();
            SalariesTabViewModel = new SalariesTabViewModel();
            SpecializationsTabViewModel = new SpecializationsTabViewModel();

            TabsViewModels.Add(BuildingsTabViewModel);
            TabsViewModels.Add(CompaniesTabViewModel);
            TabsViewModels.Add(CyclicOrdersTabViewModel);
            TabsViewModels.Add(EmployeesTabViewModel);
            TabsViewModels.Add(ExpensesTabViewModel);
            TabsViewModels.Add(NotificationsTabViewModel);
            TabsViewModels.Add(LocalsTabViewModel);
            TabsViewModels.Add(OrdersTabViewModel);
            TabsViewModels.Add(OrderTypesTabViewModel);
            TabsViewModels.Add(OwnershipsTabViewModel);
            TabsViewModels.Add(PeopleTabViewModel);
            TabsViewModels.Add(OwningCompaniesTabViewModel);
            TabsViewModels.Add(RentsTabViewModel);
            TabsViewModels.Add(SalariesTabViewModel);
            TabsViewModels.Add(SpecializationsTabViewModel);

            TabsViewModels.ForEach(vm => vm.PropertyChanged += OnMemberViewModelPropertyChanged);
        }

        private void OnMemberViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Update")
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
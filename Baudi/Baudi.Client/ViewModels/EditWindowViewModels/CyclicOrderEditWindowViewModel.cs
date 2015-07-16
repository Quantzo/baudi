using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;



namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class CyclicOrderEditWindowViewModel : EditWindowViewModel
    {
        #region Properties
        private CyclicOrder _cyclicOrder;
        public CyclicOrder CyclicOrder
        {
            get
            {
                return _cyclicOrder;
            }
            set
            {
                _cyclicOrder = value;
                OnPropertyChanged("CyclicOrder");
            }
        }

        private List<Building> _buildingsList;
        public List<Building> BuildingsList
        {
            get
            {
                return _buildingsList;
            }
            set
            {
                _buildingsList = value;
                OnPropertyChanged("BuildingsList");
            }
        }

        private Company _selectedCompany;
        public Company SelectedCompany
        {
            get
            {
                return _selectedCompany;
            }
            set
            {
                _selectedCompany = value;
                OnPropertyChanged("SelectedCompany");
            }
        }

        private Building _selectedBuilding;
        public Building SelectedBuilding
        {
            get
            {
                return _selectedBuilding;
            }
            set
            {
                _selectedBuilding = value;
                OnPropertyChanged("SelectedBuilding");
            }
        }


        private List<Company> _companiesList;
        public List<Company> CompaniesList
        {
            get
            {
                return _companiesList;
            }
            set
            {
                _companiesList = value;
                OnPropertyChanged("CompaniesList");
            }
        }
        #endregion

        public CyclicOrderEditWindowViewModel(CyclicOrdersTabViewModel cyclicOrderTabViewModel, CyclicOrderEditWindow cyclicOrderEditWindow, CyclicOrder cyclicOrder)
            : base(cyclicOrderTabViewModel, cyclicOrderEditWindow, cyclicOrder)
        {
            using (var con = new BaudiDbContext())
            {
                BuildingsList = con.Buildings.ToList();
                CompaniesList = con.Companies.ToList();
                if (Update)
                {
                    CyclicOrder = con.CyclicOrders.Find(cyclicOrder.ExpenseTargetID);
                    SelectedBuilding = CyclicOrder.Building;
                    SelectedCompany = CyclicOrder.Company;
                }
                else
                {
                    CyclicOrder = new CyclicOrder();
                }
            }
        }

        public override void Save()
        {
            if (Update)
            {
                using (var con = new BaudiDbContext())
                {
                    var building = con.Buildings.Find(SelectedBuilding.NotificationTargetID);
                    var company = con.Companies.Find(SelectedCompany.CompanyID);
                    

                    var cyclicOrder = con.CyclicOrders.Find(CyclicOrder.ExpenseTargetID);
                    cyclicOrder.Building = building;
                    cyclicOrder.Company = company;
                    cyclicOrder.Cost = CyclicOrder.Cost;
                    cyclicOrder.Frequency = CyclicOrder.Frequency;


                    con.Entry(cyclicOrder).State = EntityState.Modified;

                    con.SaveChanges();
                }

            }
            else
            {
                using (var con = new BaudiDbContext())
                {
                    var building = con.Buildings.Find(SelectedBuilding.NotificationTargetID);
                    var company = con.Companies.Find(SelectedCompany.CompanyID);

                    CyclicOrder.Building = building;
                    CyclicOrder.Company = company;

                    con.CyclicOrders.Add(CyclicOrder);
                    con.SaveChanges();
                }
            }

            ParentViewModel.Update();
            CloseWindow();
        }

        public override bool IsValid()
        {
            if(SelectedBuilding != null && SelectedCompany != null)
            {
                return true;
            }
            return false;
        }
    }
}

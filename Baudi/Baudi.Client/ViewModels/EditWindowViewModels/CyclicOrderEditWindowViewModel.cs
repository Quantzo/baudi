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
        public CyclicOrderEditWindowViewModel(CyclicOrdersTabViewModel cyclicOrderTabViewModel,
            CyclicOrderEditWindow cyclicOrderEditWindow, CyclicOrder cyclicOrder)
            : base(cyclicOrderTabViewModel, cyclicOrderEditWindow, cyclicOrder)
        {
            using (var con = new BaudiDbContext())
            {
                BuildingsList = con.Buildings.ToList();
                CompaniesList = con.Companies.ToList();
                MenagersList = con.Menagers.ToList();
                if (Update)
                {
                    CyclicOrder = con.CyclicOrders.Find(cyclicOrder.ExpenseTargetID);
                    SelectedBuilding = CyclicOrder.Building;
                    SelectedCompany = CyclicOrder.Company;
                    SelectedMenager = CyclicOrder.Menager;
                }
                else
                {
                    CyclicOrder = new CyclicOrder();
                }
            }
        }

        public override bool IsValid()
        {
            if (SelectedBuilding != null && SelectedCompany != null)
            {
                return true;
            }
            return false;
        }

        public override void Add()
        {
            using (var con = new BaudiDbContext())
            {
                var building = con.Buildings.Find(SelectedBuilding.NotificationTargetID);
                var company = con.Companies.Find(SelectedCompany.CompanyID);
                var menager = con.Menagers.Find(SelectedMenager.OwnerID);

                CyclicOrder.Building = building;
                CyclicOrder.Company = company;
                CyclicOrder.Menager = menager;

                con.CyclicOrders.Add(CyclicOrder);
                con.SaveChanges();
            }
        }

        public override void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                var building = con.Buildings.Find(SelectedBuilding.NotificationTargetID);
                var company = con.Companies.Find(SelectedCompany.CompanyID);
                var menager = con.Menagers.Find(SelectedMenager.OwnerID);


                var cyclicOrder = con.CyclicOrders.Find(CyclicOrder.ExpenseTargetID);
                cyclicOrder.Building = building;
                cyclicOrder.Company = company;
                cyclicOrder.Cost = CyclicOrder.Cost;
                cyclicOrder.Frequency = CyclicOrder.Frequency;
                cyclicOrder.Menager = menager;


                con.Entry(cyclicOrder).State = EntityState.Modified;

                con.SaveChanges();
            }
        }

        #region Properties

        private CyclicOrder _cyclicOrder;

        public CyclicOrder CyclicOrder
        {
            get { return _cyclicOrder; }
            set
            {
                _cyclicOrder = value;
                OnPropertyChanged("CyclicOrder");
            }
        }

        private List<Building> _buildingsList;

        public List<Building> BuildingsList
        {
            get { return _buildingsList; }
            set
            {
                _buildingsList = value;
                OnPropertyChanged("BuildingsList");
            }
        }

        private Company _selectedCompany;

        public Company SelectedCompany
        {
            get { return _selectedCompany; }
            set
            {
                _selectedCompany = value;
                OnPropertyChanged("SelectedCompany");
            }
        }

        private Building _selectedBuilding;

        public Building SelectedBuilding
        {
            get { return _selectedBuilding; }
            set
            {
                _selectedBuilding = value;
                OnPropertyChanged("SelectedBuilding");
            }
        }


        private List<Company> _companiesList;

        public List<Company> CompaniesList
        {
            get { return _companiesList; }
            set
            {
                _companiesList = value;
                OnPropertyChanged("CompaniesList");
            }
        }


        private List<Menager> _menagersList;

        public List<Menager> MenagersList
        {
            get { return _menagersList; }
            set
            {
                _menagersList = value;
                OnPropertyChanged("MenagersList");
            }
        }

        private Menager _selectedMenager;

        public Menager SelectedMenager
        {
            get { return _selectedMenager; }
            set
            {
                _selectedMenager = value;
                OnPropertyChanged("SelectedMenager");
            }
        }

        #endregion
    }
}
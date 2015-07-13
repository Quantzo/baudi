using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class CyclicOrdersTabViewModel : TabViewModel
    {
        private List<CyclicOrder> _cyclicOrdersList;

        public List<CyclicOrder> CyclicOrdersList
        {
            get { return _cyclicOrdersList; }
            set
            {
                _cyclicOrdersList = value;
                OnPropertyChanged("CyclicOrdersList");
            }
        }

        public CyclicOrder SelectedCyclicOrder { get; set; }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                CyclicOrdersList = con.CyclicOrders
                    .Include(co => co.Company)
                    .Include(co => co.Building)
                    .ToList();
            }
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Edit()
        {
            throw new NotImplementedException();
        }

        public override bool IsSomethingSelected()
        {
            throw new NotImplementedException();
        }
    }
}
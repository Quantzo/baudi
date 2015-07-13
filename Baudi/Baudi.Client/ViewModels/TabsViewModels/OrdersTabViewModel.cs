using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class OrdersTabViewModel : TabViewModel
    {
        private List<Order> _ordersList;

        public List<Order> OrdersList
        {
            get { return _ordersList; }
            set
            {
                _ordersList = value;
                OnPropertyChanged("OrdersList");
            }
        }

        public Order SelectedOrder { get; set; }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                OrdersList = con.Orders
                    .Include(o => o.Company)
                    .Include(o => o.OrderType)
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
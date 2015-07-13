using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class OrdersTabViewModel : INotifyPropertyChanged
    {
        public OrdersTabViewModel()
        {
            Load();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Order> _ordersList;
        public List<Order> OrdersList
        {
            get { return _ordersList; }
            set { _ordersList = value; OnPropertyChanged("OrdersList"); }
        }
        public Order SelectedOrder
        {
            get;
            set;
        }

        public void Load()
        {
            using (var con = new BaudiDbContext())
            {
                _ordersList = con.Orders
                    .Include(o => o.Company)
                    .Include(o => o.OrderType)
                    .ToList();


            }
        }
        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        } 
    }
}

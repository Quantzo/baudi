using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
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

        /// <summary>
        /// Load action
        /// </summary>
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

        /// <summary>
        /// Add action
        /// </summary>
        public override void Add()
        {
            var orderEditWindow = new OrderEditWindow(this, null);
            orderEditWindow.Show();
        }

        /// <summary>
        /// Delete action
        /// </summary>
        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var order = con.Orders.Find(SelectedOrder.ExpenseTargetID);
                order.Company = null;
                con.Expenses.RemoveRange(order.Expenses);
                order.Menager = null;
                order.Notification = null;
                order.OrderType = null;
                con.Orders.Remove(order);
                con.SaveChanges();
            }
            Update();
        }

        /// <summary>
        /// Edit action
        /// </summary>
        public override void Edit()
        {
            var orderEditWindow = new OrderEditWindow(this, SelectedOrder);
            orderEditWindow.Show();
        }

        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
        public override bool IsSomethingSelected()
        {
            if (SelectedOrder != null)
            {
                return true;
            }
            return false;
        }
    }
}
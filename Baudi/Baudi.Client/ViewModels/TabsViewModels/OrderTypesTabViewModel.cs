using System.Collections.Generic;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class OrderTypesTabViewModel : TabViewModel
    {
        public override void Add()
        {
            var orderTypeEditWindow = new OrderTypeEditWindow(this, null);
            orderTypeEditWindow.Show();
        }

        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var orderType = con.OrderTypes.Find(SelectedOrderType.OrderTypeID);
                orderType.Orders.Clear();
                orderType.Specializations = null;
                con.OrderTypes.Remove(orderType);
                con.SaveChanges();
            }
            Update();
        }

        public override void Edit()
        {
            var orderTypeEditWindow = new OrderTypeEditWindow(this, SelectedOrderType);
            orderTypeEditWindow.Show();
        }

        public override bool IsSomethingSelected()
        {
            if (SelectedOrderType != null)
                return true;
            return false;
        }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                OrderTypesList = con.OrderTypes
                    .ToList();
            }
        }

        #region Properties

        private List<OrderType> _orderTypesList;

        public List<OrderType> OrderTypesList
        {
            get { return _orderTypesList; }
            set
            {
                _orderTypesList = value;
                OnPropertyChanged("OrderTypesList");
            }
        }

        public OrderType SelectedOrderType { get; set; }

        #endregion
    }
}
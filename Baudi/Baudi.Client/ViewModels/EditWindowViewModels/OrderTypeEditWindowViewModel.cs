using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class OrderTypeEditWindowViewModel : EditWindowViewModel
    {
        public OrderTypeEditWindowViewModel(OrderTypesTabViewModel orderTypeTabViewModel,
            OrderTypeEditWindow orderTypeEditWindow, OrderType orderType)
            : base(orderTypeTabViewModel, orderTypeEditWindow, orderType)
        {
            using (var con = new BaudiDbContext())
            {
                SpecializationList = con.Specializations.ToList();
                if (Update)
                {
                    OrderType = con.OrderTypes.Find(orderType.OrderTypeID);
                    OrderType.Specializations.ForEach(s => s.IsSelected = true);
                }
                else
                {
                    OrderType = new OrderType();
                }
            }
        }

        /// <summary>
        /// Adds new item
        /// </summary>
        public override void Add()
        {
            using (var con = new BaudiDbContext())
            {
                var specializations = SpecializationList.Where(s => s.IsSelected).ToList();
                specializations.ForEach(s => con.Specializations.Attach(s));

                OrderType.Specializations = specializations;
                con.OrderTypes.Add(OrderType);
                con.SaveChanges();
            }
        }

        /// <summary>
        /// Edits item
        /// </summary>
        public override void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                var specializations = SpecializationList.Where(s => s.IsSelected).ToList();
                specializations.ForEach(s => con.Specializations.Attach(s));

                var orderType = con.OrderTypes.Find(OrderType.OrderTypeID);
                orderType.Name = OrderType.Name;

                if (specializations.Count == 0)
                {
                    orderType.Specializations.Clear();
                }
                else
                {
                    orderType.Specializations = specializations;
                }

                con.Entry(orderType).State = EntityState.Modified;

                con.SaveChanges();
            }
        }

        /// <summary>
        /// Returns if state is valid
        /// </summary>
        /// <returns>Returns if state is valid</returns>
        public override bool IsValid()
        {
            return true;
        }

        #region Properties

        private OrderType _orderType;

        public OrderType OrderType
        {
            get { return _orderType; }
            set
            {
                _orderType = value;
                OnPropertyChanged("OrderType");
            }
        }

        private List<Specialization> _specializationList;

        public List<Specialization> SpecializationList
        {
            get { return _specializationList; }
            set
            {
                _specializationList = value;
                OnPropertyChanged("SpecializationList");
            }
        }

        #endregion
    }
}
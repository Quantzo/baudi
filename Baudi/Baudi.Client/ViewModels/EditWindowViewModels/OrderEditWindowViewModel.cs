using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class OrderEditWindowViewModel : EditWindowViewModel
    {
        public OrderEditWindowViewModel(OrdersTabViewModel orderTabViewModel, OrderEditWindow orderEditWindow,
            Order order)
            : base(orderTabViewModel, orderEditWindow, order)
        {
            CompaniesList = new List<Company>();
            using (var con = new BaudiDbContext())
            {
                OrderTypesList = con.OrderTypes.ToList();
                MenagersList = con.Menagers.ToList();
                NotificationsList = con.Notifications.ToList();
                if (Update)
                {
                    Order = con.Orders.Find(order.ExpenseTargetID);
                    SelectedOrderType = Order.OrderType;
                    SelectedCompany = Order.Company;
                    SelectedMenager = Order.Menager;
                    SelectedNotification = Order.Notification;
                    ProvideCompaniesWithCorrectSpecialization();
                }
                else
                {
                    Order = new Order();
                }
            }
        }

        public void ProvideCompaniesWithCorrectSpecialization()
        {
            using (var con = new BaudiDbContext())
            {
                var companies = new List<Company>();
                var orderType = con.OrderTypes.Find(SelectedOrderType.OrderTypeID);
                orderType.Specializations.ForEach(s => companies.AddRange(s.Companies));
                CompaniesList = companies;
            }
        }

        public override bool IsValid()
        {
            if (SelectedOrderType != null && SelectedCompany != null && SelectedMenager != null &&
                SelectedNotification != null)
            {
                return true;
            }
            return false;
        }

        public override void Add()
        {
            using (var con = new BaudiDbContext())
            {
                var orderType = con.OrderTypes.Find(SelectedOrderType.OrderTypeID);
                var company = con.Companies.Find(SelectedCompany.CompanyID);
                var menager = con.Menagers.Find(SelectedMenager.OwnerID);
                var notification = con.Notifications.Find(SelectedNotification.NotificationID);

                Order.OrderType = orderType;
                Order.Company = company;
                Order.Menager = menager;
                Order.Notification = notification;

                con.Orders.Add(Order);
                con.SaveChanges();
            }
        }

        public override void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                var orderType = con.OrderTypes.Find(SelectedOrderType.OrderTypeID);
                var company = con.Companies.Find(SelectedCompany.CompanyID);
                var menager = con.Menagers.Find(SelectedMenager.OwnerID);
                var notification = con.Notifications.Find(SelectedNotification.NotificationID);


                var order = con.Orders.Find(Order.ExpenseTargetID);
                order.OrderType = orderType;
                order.Company = company;
                order.Menager = menager;
                order.Notification = notification;

                order.Status = SelectedOrderStatus;
                order.Cost = Order.Cost;
                order.LastChanged = Order.LastChanged;
                order.FilingDate = order.FilingDate;

                con.Entry(order).State = EntityState.Modified;

                con.SaveChanges();
            }
        }

        #region Properties

        private Order _order;

        public Order Order
        {
            get { return _order; }
            set
            {
                _order = value;
                OnPropertyChanged("Order");
            }
        }

        public IEnumerable<OrderStatus> OrderStatus
        {
            get
            {
                return Enum.GetValues(typeof (OrderStatus))
                    .Cast<OrderStatus>();
            }
        }

        private OrderStatus _selectedOrderStatus;

        public OrderStatus SelectedOrderStatus
        {
            get { return _selectedOrderStatus; }
            set
            {
                _selectedOrderStatus = value;
                OnPropertyChanged("SelectedOrderStatusStatus");
            }
        }

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

        private OrderType _selectedOrderType;

        public OrderType SelectedOrderType
        {
            get { return _selectedOrderType; }
            set
            {
                _selectedOrderType = value;
                OnPropertyChanged("SelectedOrderType");
                ProvideCompaniesWithCorrectSpecialization();
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

        private List<Notification> _notificationsList;

        public List<Notification> NotificationsList
        {
            get { return _notificationsList; }

            set
            {
                _notificationsList = value;
                OnPropertyChanged("NotificationsList");
            }
        }

        private Notification _selectedNotification;

        public Notification SelectedNotification
        {
            get { return _selectedNotification; }
            set
            {
                _selectedNotification = value;
                OnPropertyChanged("SelectedNotification");
            }
        }

        #endregion
    }
}
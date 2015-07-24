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
        #region Properties

        private Order _order;
        public Order Order
        {
            get
            {
                return _order;
            }
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
                return Enum.GetValues(typeof(OrderStatus))
                    .Cast<OrderStatus>();
            }
        }

        private OrderStatus _selectedOrderStatus;
        public OrderStatus SelectedOrderStatus
        {
            get
            {
                return _selectedOrderStatus;
            }
            set
            {
                _selectedOrderStatus = value;
                OnPropertyChanged("SelectedOrderStatusStatus");
            }

        }

        private List<OrderType> _orderTypesList;
        public List<OrderType> OrderTypesList
        {
            get
            {
                return _orderTypesList;
            }

            set
            {
                _orderTypesList = value;
                OnPropertyChanged("OrderTypesList");
            }
        }
        private OrderType _selectedOrderType;
        public OrderType SelectedOrderType
        {
            get
            {
                return _selectedOrderType;
            }
            set
            {
                _selectedOrderType = value;
                OnPropertyChanged("SelectedOrderType");
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


        private List<Menager> _menagersList;
        public List<Menager> MenagersList
        {
            get
            {
                return _menagersList;
            }

            set
            {
                _menagersList = value;
                OnPropertyChanged("MenagersList");
            }
        }
        private Menager _selectedMenager;
        public Menager SelectedMenager
        {
            get
            {
                return _selectedMenager;
            }
            set
            {
                _selectedMenager = value;
                OnPropertyChanged("SelectedMenager");
            }
        }

        private List<Notification> _notificationsList;
        public List<Notification> NotificationsList
        {
            get
            {
                return _notificationsList;
            }

            set
            {
                _notificationsList = value;
                OnPropertyChanged("NotificationsList");
            }
        }
        private Notification _selectedNotification;
        public Notification SelectedNotification
        {
            get
            {
                return _selectedNotification;
            }
            set
            {
                _selectedNotification = value;
                OnPropertyChanged("SelectedNotification");
            }
        }
        #endregion

        public OrderEditWindowViewModel(OrdersTabViewModel orderTabViewModel, OrderEditWindow orderEditWindow, Order order)
            : base(orderTabViewModel, orderEditWindow, order)
        {

        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}

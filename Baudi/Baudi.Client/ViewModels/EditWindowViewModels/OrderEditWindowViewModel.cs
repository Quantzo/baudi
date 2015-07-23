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

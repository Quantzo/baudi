﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
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

        /// <summary>
        /// Load action
        /// </summary>
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

        /// <summary>
        /// Add action
        /// </summary>
        public override void Add()
        {
            var cyclicOrderEditWindow = new CyclicOrderEditWindow(this, null);
            cyclicOrderEditWindow.Show();
        }

        /// <summary>
        /// Delete action
        /// </summary>
        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var cyclicOrder = con.CyclicOrders.Find(SelectedCyclicOrder.ExpenseTargetID);
                cyclicOrder.Building = null;
                cyclicOrder.Company = null;
                con.Expenses.RemoveRange(cyclicOrder.Expenses);
                cyclicOrder.Menager = null;

                con.CyclicOrders.Remove(cyclicOrder);
                con.SaveChanges();
            }
            Update();
        }

        /// <summary>
        /// Edit action
        /// </summary>
        public override void Edit()
        {
            var cyclicOrderEditWindow = new CyclicOrderEditWindow(this, SelectedCyclicOrder);
            cyclicOrderEditWindow.Show();
        }

        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
        public override bool IsSomethingSelected()
        {
            if (SelectedCyclicOrder != null)
            {
                return true;
            }
            return false;
        }
    }
}
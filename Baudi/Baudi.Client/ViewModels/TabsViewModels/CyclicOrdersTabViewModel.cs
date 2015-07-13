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
    public class CyclicOrdersTabViewModel : INotifyPropertyChanged
    {
        public CyclicOrdersTabViewModel()
        {
            Load();
        }
        private List<CyclicOrder> _cyclicOrdersList;
        public List<CyclicOrder> CyclicOrdersList
        {
            get { return _cyclicOrdersList; }
            set { _cyclicOrdersList = value; OnPropertyChanged("CyclicOrdersList"); }
        }

        public CyclicOrder SelectedCyclicOrder
        {
            get;
            set;
        }
        public void Load()
        {
            using (var con = new BaudiDbContext())
            {
                _cyclicOrdersList = con.CyclicOrders
                    .Include(co => co.Company)
                    .Include(co => co.Building)
                    .ToList();

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        } 

    }
}

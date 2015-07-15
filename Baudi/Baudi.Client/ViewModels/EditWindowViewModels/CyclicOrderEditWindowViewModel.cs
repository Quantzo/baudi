using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;


namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class CyclicOrderEditWindowViewModel : EditWindowViewModel
    {
        private CyclicOrder _cyclicOrder;
        public CyclicOrder CyclicOrder
        {
            get
            {
                return _cyclicOrder;
            }
            set
            {
                _cyclicOrder = value;
                OnPropertyChanged("CyclicOrder");
            }
        }


        public CyclicOrderEditWindowViewModel(CyclicOrdersTabViewModel cyclicOrderTabViewModel, CyclicOrderEditWindow cyclicOrderEditWindow, CyclicOrder cyclicOrder)
            : base(cyclicOrderTabViewModel, cyclicOrderEditWindow, cyclicOrder)
        {

        }

        public override void Save()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}

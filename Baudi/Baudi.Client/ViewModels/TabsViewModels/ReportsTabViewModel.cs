using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class ReportsTabViewModel : INotifyPropertyChanged
    {
        public ReportsTabViewModel()
        {
            Load();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void Load()
        {
        }
    }
}

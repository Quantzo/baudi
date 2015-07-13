using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class DictionariesTabViewModel : INotifyPropertyChanged
    {
        public DictionariesTabViewModel()
        {
            Load();
        }
        public void Load()
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

using System.ComponentModel;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class DictionariesTabViewModel : INotifyPropertyChanged
    {
        public DictionariesTabViewModel()
        {
            Load();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Load()
        {
        }
    }
}
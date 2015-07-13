using System.ComponentModel;

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
using System.ComponentModel;
using System.Windows.Input;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public abstract class TabViewModel : INotifyPropertyChanged
    {
        public TabViewModel()
        {
            ButtonAdd = new RelayCommand(pars => Add());
            ButtonRemove = new RelayCommand(pars => Delete(), pars => IsSomethingSelected());
            ButtonEdit = new RelayCommand(pars => Edit(), pars => IsSomethingSelected());
            Load();
        }

        public ICommand ButtonAdd { get; set; }
        public ICommand ButtonRemove { get; set; }
        public ICommand ButtonEdit { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public abstract void Add();
        public abstract void Delete();
        public abstract void Edit();
        public abstract void Load();
        public abstract bool IsSomethingSelected();

        public void Update()
        {
            OnPropertyChanged("Update");
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
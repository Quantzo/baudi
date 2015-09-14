using System.ComponentModel;
using System.Windows.Input;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public abstract class TabViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TabViewModel()
        {
            ButtonAdd = new RelayCommand(pars => Add());
            ButtonRemove = new RelayCommand(pars => Delete(), pars => IsSomethingSelected());
            ButtonEdit = new RelayCommand(pars => Edit(), pars => IsSomethingSelected());
            Load();
        }

        /// <summary>
        /// Command for add button
        /// </summary>
        public ICommand ButtonAdd { get; set; }
        /// <summary>
        /// Command for remove button
        /// </summary>
        public ICommand ButtonRemove { get; set; }
        /// <summary>
        /// Command for edit button
        /// </summary>
        public ICommand ButtonEdit { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Add action
        /// </summary>
        public abstract void Add();
        /// <summary>
        /// Delete action
        /// </summary>
        public abstract void Delete();
        /// <summary>
        /// Edit action
        /// </summary>
        public abstract void Edit();
        /// <summary>
        /// Load action
        /// </summary>
        public abstract void Load();
        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
        public abstract bool IsSomethingSelected();

        /// <summary>
        /// On update oaction
        /// </summary>
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
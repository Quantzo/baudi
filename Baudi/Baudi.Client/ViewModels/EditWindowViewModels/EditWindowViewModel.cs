using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Baudi.Client.ViewModels.TabsViewModels;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public abstract class EditWindowViewModel : INotifyPropertyChanged
    {
        protected readonly bool Update;

        public EditWindowViewModel(TabViewModel parentViewModel, Window editWindow, object itemToEdit)
        {
            ParentViewModel = parentViewModel;
            EditWindow = editWindow;
            ButtonCancel = new RelayCommand(pars => CloseWindow());
            ButtonSave = new RelayCommand(pars => Save(), pars => IsValid());
            Update = itemToEdit != null;
        }

        private TabViewModel ParentViewModel { get; set; }
        protected Window EditWindow { get; set; }
        public ICommand ButtonCancel { get; set; }
        public ICommand ButtonSave { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public abstract void Add();
        public abstract void Edit();

        public void Save()
        {
            if (Update)
            {
                Edit();
            }
            else
            {
                Add();
            }
            CloseWindow();
        }

        public abstract bool IsValid();

        private void CloseWindow()
        {
            ParentViewModel.Update();
            EditWindow.Close();
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
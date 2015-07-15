using Baudi.Client.ViewModels.TabsViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public abstract class EditWindowViewModel: INotifyPropertyChanged
    {

        protected TabViewModel ParentViewModel { get; set; }
        protected readonly bool Update;
        private Window EditWindow { get; set; }
        public ICommand ButtonCancel { get; set; }
        public ICommand ButtonSave { get; set; }

        public abstract void Save();
        public abstract bool IsValid();

        public EditWindowViewModel(TabViewModel parentViewModel, Window editWindow, Object itemToEdit)
        {
            ParentViewModel = parentViewModel;
            EditWindow = editWindow;
            ButtonCancel = new RelayCommand(pars => CloseWindow());
            ButtonSave = new RelayCommand(pars => Save(), pars => IsValid());
            Update = itemToEdit != null;
        }

        protected void CloseWindow()
        {
            ParentViewModel.Update();
            EditWindow.Close();
        }
   
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}

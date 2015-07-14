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
        private Window _editWindow { get; set; }
        public ICommand ButtonCancel { get; set; }
        public ICommand ButtonSave { get; set; }

        public abstract void Save();
        //public abstract bool IsValid();

        public EditWindowViewModel(TabViewModel parentViewModel, Window editWindow)
        {
            ParentViewModel = parentViewModel;
            _editWindow = editWindow;
            ButtonCancel = new RelayCommand(pars => CloseWindow());
            ButtonSave = new RelayCommand(pars => Save()/*, pars => IsValid()*/);
        }

        protected void CloseWindow()
        {
            _editWindow.Close();
        }

    
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}

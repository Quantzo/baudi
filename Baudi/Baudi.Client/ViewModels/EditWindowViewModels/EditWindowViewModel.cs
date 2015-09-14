using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Baudi.Client.Helpers;
using Baudi.Client.ViewModels.TabsViewModels;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    /// <summary>
    /// View model for edit window
    /// </summary>
    public abstract class EditWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Flag to differntiate update and adding new item
        /// </summary>
        protected readonly bool Update;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parentViewModel">parent view Model</param>
        /// <param name="editWindow">Edit Window</param>
        /// <param name="itemToEdit">Item to edit</param>
        public EditWindowViewModel(TabViewModel parentViewModel, Window editWindow, object itemToEdit)
        {
            ContextHelp = new RelayCommand(pars => ContextHelpHelper.ContextHelp());
            ParentViewModel = parentViewModel;
            EditWindow = editWindow;
            ButtonCancel = new RelayCommand(pars => CloseWindow());
            ButtonSave = new RelayCommand(pars => Save(), pars => IsValid());
            Update = itemToEdit != null;
        }

        private TabViewModel ParentViewModel { get; set; }
        /// <summary>
        /// Edit window
        /// </summary>
        protected Window EditWindow { get; set; }
        /// <summary>
        /// Cancel button command
        /// </summary>
        public ICommand ButtonCancel { get; set; }
        /// <summary>
        /// Help button command
        /// </summary>
        public ICommand ContextHelp { get; set; }
        /// <summary>
        /// Context help button command
        /// </summary>
        public ICommand ButtonSave { get; set; }
        /// <summary>
        /// Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Adds new item
        /// </summary>
        public abstract void Add();
        /// <summary>
        /// Edits item
        /// </summary>
        public abstract void Edit();

        /// <summary>
        /// Saves item
        /// </summary>
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

        /// <summary>
        /// Returns if state is valid
        /// </summary>
        /// <returns>Returns if state is valid</returns>
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
using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    public partial class PersonEditWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ownersTabViewModel">Owners tab view model</param>
        /// <param name="person">Person</param>
        public PersonEditWindow(PeopleTabViewModel ownersTabViewModel, Person person)
        {
            InitializeComponent();
            DataContext = new PersonEditWindowViewModel(ownersTabViewModel, this, person);
        }
    }
}
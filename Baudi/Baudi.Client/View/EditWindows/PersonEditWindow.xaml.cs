using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    public partial class PersonEditWindow : Window
    {
        public PersonEditWindow(PeopleTabViewModel ownersTabViewModel, Person person)
        {
            InitializeComponent();
            DataContext = new PersonEditWindowViewModel(ownersTabViewModel, this, person);
        }
    }
}
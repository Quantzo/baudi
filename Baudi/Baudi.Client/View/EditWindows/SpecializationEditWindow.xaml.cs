using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;


namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    /// Interaction logic for SpecializationEditWindow.xaml
    /// </summary>
    public partial class SpecializationEditWindow : Window
    {
        public SpecializationEditWindow(SpecializationsTabViewModel specializationsTabViewModel, Specialization specialization)
        {
            InitializeComponent();
            DataContext = new SpecializationEditWindowViewModel(specializationsTabViewModel, this, specialization);
        }
    }
}

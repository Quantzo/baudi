using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for SpecializationEditWindow.xaml
    /// </summary>
    public partial class SpecializationEditWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="specializationsTabViewModel">Specialization tab view model</param>
        /// <param name="specialization">Specialization</param>
        public SpecializationEditWindow(SpecializationsTabViewModel specializationsTabViewModel,
            Specialization specialization)
        {
            InitializeComponent();
            DataContext = new SpecializationEditWindowViewModel(specializationsTabViewModel, this, specialization);
        }
    }
}
using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.Client.ViewModels.EditWindowCode;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for OknoEdycjiPracownika.xaml
    /// </summary>
    public partial class EmployeeEditWindow : Window
    {
        public EmployeeEditWindow(Employee selectedCompany, MainWindowViewModel owner)
        {
            InitializeComponent();
            DataContext = new EmployeeEditWindowCode(selectedCompany, this, owner);
        }

        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
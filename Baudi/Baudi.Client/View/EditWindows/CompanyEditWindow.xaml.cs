using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.Client.ViewModels.EditWindowCode;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for OknoEdycjiFirmy.xaml
    /// </summary>
    public partial class CompanyEditWindow : Window
    {
        public CompanyEditWindow(Company selectedCompany, MainWindowViewModel owner)
        {
            InitializeComponent();
            DataContext = new CompanyEditWindowCode(selectedCompany, this, owner);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
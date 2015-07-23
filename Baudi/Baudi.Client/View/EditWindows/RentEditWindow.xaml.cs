using Baudi.Client.ViewModels.TabsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    /// Interaction logic for RentEditWindow.xaml
    /// </summary>
    public partial class RentEditWindow : Window
    {
        public RentEditWindow(RentsTabViewModel rentsTabViewModel, Rent rent)
        {
            InitializeComponent();
            DataContext = new RentEditWindowViewModel(rentsTabViewModel, this, rent);
        }
    }
}

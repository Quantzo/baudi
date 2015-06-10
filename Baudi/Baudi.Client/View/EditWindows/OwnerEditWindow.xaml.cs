using Baudi.Client.ViewModels;
using Baudi.DAL.Models;
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

namespace GUIBD
{
    /// <summary>
    /// Interaction logic for OwnerEditWindow.xaml
    /// </summary>
    public partial class OwnerEditWindow : Window
    {
        public OwnerEditWindow(Person selectedOwner, MainWindowCode owner)
        {
            InitializeComponent();
            this.DataContext = new OwnerEditWindowCode(selectedOwner, this, owner);
        }


    }
}

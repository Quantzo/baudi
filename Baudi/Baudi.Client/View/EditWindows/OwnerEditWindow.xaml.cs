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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //OwnershipEditWindow OEW = new OwnershipEditWindow();
            //OEW.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Selector Wnd = new Selector();
            //Wnd.Show(); 
        }
    }
}

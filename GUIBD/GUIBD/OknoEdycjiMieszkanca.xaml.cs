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
    /// Interaction logic for OknoEdycjiMieszkanca.xaml
    /// </summary>
    public partial class OknoEdycjiMieszkanca : Window
    {
        public OknoEdycjiMieszkanca()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OwnershipEditWindow OEW = new OwnershipEditWindow();
            OEW.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Selector Wnd = new Selector();
            Wnd.Show(); 
        }
    }
}

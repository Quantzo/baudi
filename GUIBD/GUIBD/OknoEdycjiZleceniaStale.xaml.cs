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
    /// Interaction logic for OknoEdycjiZleceniaStale.xaml
    /// </summary>
    public partial class OknoEdycjiZleceniaStale : Window
    {
        public OknoEdycjiZleceniaStale()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Selector Wnd = new Selector();
            Wnd.Show();
        }
    }
}

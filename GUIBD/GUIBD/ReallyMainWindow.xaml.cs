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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ReallyMainWindow.xaml
    /// </summary>
    public partial class ReallyMainWindow : Window
    {
        public ReallyMainWindow()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OknoEdycjiZgloszenia OE = new OknoEdycjiZgloszenia();
            OE.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OknoEdycjiFirmy OF = new OknoEdycjiFirmy();
            OF.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OknoEdycjiPracownika OP = new OknoEdycjiPracownika();
            OP.Show();
        }
    }
}

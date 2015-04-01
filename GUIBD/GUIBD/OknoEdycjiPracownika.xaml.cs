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
    /// Interaction logic for OknoEdycjiPracownika.xaml
    /// </summary>
    public partial class OknoEdycjiPracownika : Window
    {
        public OknoEdycjiPracownika()
        {
            InitializeComponent();
        }
        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {
            if (JestMieszkancemBox.IsChecked.Value)
            {
                WyborMieszkancaLabel.IsEnabled = true;
                WyborMieszkancaBox.IsEnabled = true;
            }
            else
            {
                WyborMieszkancaLabel.IsEnabled = false;
                WyborMieszkancaBox.IsEnabled = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

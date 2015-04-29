using GUIBD;
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

        private void Button_Click_Zgloszenia(object sender, RoutedEventArgs e)
        {
            OknoEdycjiZgloszenia OE = new OknoEdycjiZgloszenia();
            OE.Show();
        }

        private void Button_Click_Firma(object sender, RoutedEventArgs e)
        {
            OknoEdycjiFirmy OF = new OknoEdycjiFirmy();
            OF.Show();
        }

        private void Button_Click_Pracownik(object sender, RoutedEventArgs e)
        {
            OknoEdycjiPracownika OP = new OknoEdycjiPracownika();
            OP.Show();
        }

        private void Button_Click_Zlecenia(object sender, RoutedEventArgs e)
        {
            OknoEdycjiZlecenia OP = new OknoEdycjiZlecenia();
            OP.Show();
        }

        private void Button_Click_Zlecenia_Stale(object sender, RoutedEventArgs e)
        {
            OknoEdycjiZleceniaStale OP = new OknoEdycjiZleceniaStale();
            OP.Show();
        }

        private void Button_Click_Budynki(object sender, RoutedEventArgs e)
        {
            OknoEdycjiBudynku OP = new OknoEdycjiBudynku();
            OP.Show();
        }

        private void Button_Click_Mieszkancy(object sender, RoutedEventArgs e)
        {
            OknoEdycjiMieszkanca OP = new OknoEdycjiMieszkanca();
            OP.Show();
        }

        private void Button_Click_Platnosci(object sender, RoutedEventArgs e)
        {
            OknoEdycjiPlatnosci OP = new OknoEdycjiPlatnosci();
            OP.Show();
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}

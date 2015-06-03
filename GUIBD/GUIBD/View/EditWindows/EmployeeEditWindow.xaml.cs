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
    public partial class EmployeeEditWindow : Window
    {
        public EmployeeEditWindow()
        {
            InitializeComponent();
        }
        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {
            if (JestMieszkancemBox.IsChecked.Value)
            {
                WyborMieszkancaLabel.IsEnabled = true;
                WyborMieszkancaButton.IsEnabled = true;

                ImieLabel.IsEnabled = false;
                NazwiskoLabel.IsEnabled = false;
                MiejscowoscLabel.IsEnabled = false;
                UlicaLabel.IsEnabled = false;
                NrDomuLabel.IsEnabled = false;
                NrMieszkaniaLabel.IsEnabled = false;

                ImieBox.IsEnabled = false;
                NazwiskoBox.IsEnabled = false;
                MiejscowoscBox.IsEnabled = false;
                UlicaBox.IsEnabled = false;
                NrDomuBox.IsEnabled = false;
                NrMieszkaniaBox.IsEnabled = false;
            }
            else
            {
                WyborMieszkancaLabel.IsEnabled = false;
                WyborMieszkancaButton.IsEnabled = false;

                ImieLabel.IsEnabled = true;
                NazwiskoLabel.IsEnabled = true;
                MiejscowoscLabel.IsEnabled = true;
                UlicaLabel.IsEnabled = true;
                NrDomuLabel.IsEnabled = true;
                NrMieszkaniaLabel.IsEnabled = true;

                ImieBox.IsEnabled = true;
                NazwiskoBox.IsEnabled = true;
                MiejscowoscBox.IsEnabled = true;
                UlicaBox.IsEnabled = true;
                NrDomuBox.IsEnabled = true;
                NrMieszkaniaBox.IsEnabled = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GUIBD.Selector Wnd = new GUIBD.Selector();
            Wnd.Show(); 
        }
    }
}

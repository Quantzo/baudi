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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Zgloszenia(object sender, RoutedEventArgs e)
        {
            NotificationEditWindow OE = new NotificationEditWindow();
            OE.Show();
        }

        private void Button_Click_Firma(object sender, RoutedEventArgs e)
        {
            CompanyEditWindow OF = new CompanyEditWindow();
            OF.Show();
        }

        private void Button_Click_Pracownik(object sender, RoutedEventArgs e)
        {
            EmployeeEditWindow OP = new EmployeeEditWindow();
            OP.Show();
        }

        private void Button_Click_Zlecenia(object sender, RoutedEventArgs e)
        {
            OrderEditWindow OP = new OrderEditWindow();
            OP.Show();
        }

        private void Button_Click_Zlecenia_Stale(object sender, RoutedEventArgs e)
        {
            OknoEdycjiZleceniaStale OP = new OknoEdycjiZleceniaStale();
            OP.Show();
        }

        private void Button_Click_Budynki(object sender, RoutedEventArgs e)
        {
            BuildingEditWindow OP = new BuildingEditWindow();
            OP.Show();
        }

        private void Button_Click_Mieszkancy(object sender, RoutedEventArgs e)
        {
            OwnerEditWindow OP = new OwnerEditWindow();
            OP.Show();
        }

        private void Button_Click_Platnosci(object sender, RoutedEventArgs e)
        {
            PaymentEditWindow OP = new PaymentEditWindow();
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

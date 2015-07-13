using System.Windows;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for OknoEdycjiPlatnosci.xaml
    /// </summary>
    public partial class PaymentEditWindow : Window
    {
        public PaymentEditWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Wnd = new Selector();
            Wnd.Show();
        }
    }
}
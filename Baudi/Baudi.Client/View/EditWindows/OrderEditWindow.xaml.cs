using System.Windows;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for OknoEdycjiZlecenia.xaml
    /// </summary>
    public partial class OrderEditWindow : Window
    {
        public OrderEditWindow()
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
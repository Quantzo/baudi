using System.Windows;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for OknoEdycjiZgloszenia.xaml
    /// </summary>
    public partial class NotificationEditWindow : Window
    {
        public NotificationEditWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Wnd = new Selector();
            Wnd.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
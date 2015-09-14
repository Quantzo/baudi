using System.Windows;
using Baudi.Client.ViewModels;

namespace Baudi.Client.View
{
    /// <summary>
    ///     Interaction logic for ReallyMainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
using System.Windows;
using Baudi.Client.ViewModels.EditWindowCode;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for OknoEdycjiLokalu.xaml
    /// </summary>
    public partial class LocalEditWindow : Window
    {
        public LocalEditWindow(Local selectedLocal)
        {
            InitializeComponent();            
        }
    }
}
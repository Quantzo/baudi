using System.Linq;
using System.Windows;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowOld : Window
    {
        public MainWindowOld()
        {
            Building local;
            InitializeComponent();
            using (var con = new BaudiDbContext())
            {
                local = con.Buildings.First();
            }
        }
    }
}
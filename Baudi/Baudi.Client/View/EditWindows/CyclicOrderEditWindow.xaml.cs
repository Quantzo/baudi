using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    public partial class CyclicOrderEditWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cyclicOrderTabViewModel">Cyclic order tab view model</param>
        /// <param name="cyclicOrder">Cyclic order</param>
        public CyclicOrderEditWindow(CyclicOrdersTabViewModel cyclicOrderTabViewModel, CyclicOrder cyclicOrder)
        {
            InitializeComponent();
            DataContext = new CyclicOrderEditWindowViewModel(cyclicOrderTabViewModel, this, cyclicOrder);
        }
    }
}
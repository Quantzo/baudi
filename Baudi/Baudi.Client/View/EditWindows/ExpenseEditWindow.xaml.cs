using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for ExpenseEditWindow.xaml
    /// </summary>
    public partial class ExpenseEditWindow : Window
    {
        public ExpenseEditWindow(ExpensesTabViewModel expensesTabViewModel, Expense expense)
        {
            InitializeComponent();
            DataContext = new ExpenseEditWindowViewModel(expensesTabViewModel, this, expense);
        }
    }
}
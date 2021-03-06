﻿using System.Windows;
using Baudi.Client.ViewModels.EditWindowViewModels;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL.Models;

namespace Baudi.Client.View.EditWindows
{
    /// <summary>
    ///     Interaction logic for SalaryEditWindow.xaml
    /// </summary>
    public partial class SalaryEditWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="salariesTabViewModel">Salaries tab view model</param>
        /// <param name="salary">Salary</param>
        public SalaryEditWindow(SalariesTabViewModel salariesTabViewModel, Salary salary)
        {
            InitializeComponent();
            DataContext = new SalaryEditWindowViewModel(salariesTabViewModel, this, salary);
        }
    }
}
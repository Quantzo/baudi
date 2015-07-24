﻿using System.Windows;
using Baudi.Client.ViewModels;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;

namespace Baudi.Client.View.EditWindows
{
    public partial class PersonEditWindow : Window
    {
        public PersonEditWindow(PeopleTabViewModel ownersTabViewModel, Person person)
        {
            InitializeComponent();
            DataContext = new PersonEditWindowViewModel(ownersTabViewModel, this, person);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class OwnersTabViewModel : TabViewModel
    {
        private List<Person> _ownersList;

        public List<Person> OwnersList
        {
            get { return _ownersList; }
            set
            {
                _ownersList = value;
                OnPropertyChanged("OwnersList");
            }
        }

        public Person SelectedOwner { get; set; }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                OwnersList = con.Peoples.ToList();
            }
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var owner = con.Peoples.Find(SelectedOwner.OwnerID);
                owner.Notifications.Clear();
                con.Ownerships.RemoveRange(owner.Ownerships);

                var employee = owner as Employee;
                if(employee != null)
                {
                    con.Salaries.RemoveRange(employee.Salaries);
                    var dispatcher = employee as Dispatcher;
                    var menager = employee as Menager;
                    if (dispatcher != null)
                    {
                        dispatcher.DispatcherNotifications.Clear();
                        con.Employees.Remove(dispatcher);
                    }
                    else if (menager != null)
                    {
                        menager.MenagerSalaries.Clear();
                        menager.MenagerExpenses.Clear();
                        menager.CyclicOrders.Clear();
                        menager.Orders.Clear();
                        con.Employees.Remove(menager);
                    }
                    else
                    {
                        con.Employees.Remove(employee);
                    }
                }
                else
                {
                    con.Owners.Remove(owner);
                }
                con.SaveChanges();                
            }
            Update();
        }

        public override void Edit()
        {
            throw new NotImplementedException();
        }

        public override bool IsSomethingSelected()
        {
            if (SelectedOwner != null)
            {
                return true;
            }
            return false;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class PeopleTabViewModel : TabViewModel
    {
        private List<Person> _peopleList;

        public List<Person> PeopleList
        {
            get { return _peopleList; }
            set
            {
                _peopleList = value;
                OnPropertyChanged("PeopleList");
            }
        }

        public Person SelectedOwner { get; set; }

        /// <summary>
        /// Load action
        /// </summary>
        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                PeopleList = con.Peoples.ToList();
            }
        }

        /// <summary>
        /// Add action
        /// </summary>
        public override void Add()
        {
            var personEditWindow = new PersonEditWindow(this, null);
            personEditWindow.Show();
        }

        /// <summary>
        /// Delete action
        /// </summary>
        public override void Delete()
        {
            using (var con = new BaudiDbContext())
            {
                var owner = con.Peoples.Find(SelectedOwner.OwnerID);
                owner.Notifications.Clear();
                con.Ownerships.RemoveRange(owner.Ownerships);

                var employee = owner as Employee;
                if (employee != null)
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

        /// <summary>
        /// Edit action
        /// </summary>
        public override void Edit()
        {
            var personEditWindow = new PersonEditWindow(this, SelectedOwner);
            personEditWindow.Show();
        }

        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
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
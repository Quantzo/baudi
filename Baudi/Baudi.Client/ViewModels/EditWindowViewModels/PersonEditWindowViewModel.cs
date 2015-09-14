using System.Data.Entity;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class PersonEditWindowViewModel : EditWindowViewModel
    {
        public PersonEditWindowViewModel(PeopleTabViewModel ownerTabViewModel, PersonEditWindow ownerEditWindow,
            Person person)
            : base(ownerTabViewModel, ownerEditWindow, person)
        {
            if (Update)
            {
                Person = new Person
                {
                    OwnerID = person.OwnerID,
                    Name = person.Name,
                    Surname = person.Surname,
                    PESEL = person.PESEL,
                    City = person.City,
                    Street = person.Street,
                    HouseNumber = person.HouseNumber,
                    LocalNumber = person.LocalNumber,
                    Telephone = person.Telephone
                };
            }
            else
            {
                Person = new Person();
            }
        }

        /// <summary>
        /// Returns if state is valid
        /// </summary>
        /// <returns>Returns if state is valid</returns>
        public override bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// Adds new item
        /// </summary>
        public override void Add()
        {
            using (var con = new BaudiDbContext())
            {
                con.Peoples.Add(Person);
                con.SaveChanges();
            }
        }

        /// <summary>
        /// Edits item
        /// </summary>
        public override void Edit()
        {
            using (var con = new BaudiDbContext())
            {
                var person = con.Peoples.Find(Person.OwnerID);
                person.Name = Person.Name;
                person.Surname = Person.Surname;
                person.PESEL = Person.PESEL;
                person.City = Person.City;
                person.Street = Person.Street;
                person.HouseNumber = Person.HouseNumber;
                person.LocalNumber = Person.LocalNumber;
                person.Telephone = Person.Telephone;

                con.Entry(person).State = EntityState.Modified;
                con.SaveChanges();
            }
        }

        #region Properties

        private Person _person;

        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged("Person");
            }
        }

        #endregion
    }
}
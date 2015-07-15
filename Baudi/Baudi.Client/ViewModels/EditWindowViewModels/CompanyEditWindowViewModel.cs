using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;
using System.Collections.ObjectModel;

namespace Baudi.Client.ViewModels.EditWindowCode
{
    public class CompanyEditWindowViewModel : EditWindowViewModel
    {
        private bool _update;
        private Company _company;
        public Company Company
        {
            get
            {
                return _company;
            }
            set
            {
                _company = value;
                OnPropertyChanged("Comapny");
            }
               
        }
        
        private List<Specialization> _specializationList;
        public List<Specialization> SpecializationList
        {
            get 
            {
                return _specializationList;
            }
            set
            {
                _specializationList = value;
                OnPropertyChanged("SpecializationList");
            }
        }


        public CompanyEditWindowViewModel(CompaniesTabViewModel companiesTabViewModel, CompanyEditWindow companyEditWindow, Company company)
            : base(companiesTabViewModel, companyEditWindow)
        {

                using (var con = new BaudiDbContext())
                {
                    SpecializationList = con.Specializations.ToList();
                    if (company != null)
                    {
                        Company = con.Companies.Find(company.CompanyID);                        
                        Company.Specializations.ForEach(s => s.IsSelected = true);
                        _update = true;
                    }
                    else
                    {
                        Company = new Company();
                        _update = false;
                    }
                }
            

        }



        public override void Save()
        {
         if(_update)
         {
             using (var con = new BaudiDbContext())
             {
                 var company = con.Companies.Find(Company.CompanyID);
                 company.City = Company.City;
                 company.HouseNumber = Company.HouseNumber;
                 company.LocalNumber = Company.LocalNumber;
                 company.Name = Company.Name;
                 company.NIP = Company.NIP;
                 company.Owner = Company.Owner;

                 company.Specializations = 
                 company.Street = Company.Street;
                 company.TelephoneNumber = Company.TelephoneNumber;
                 con.SaveChanges();
             }

         }
         else
         {
             using (var con = new BaudiDbContext())
             {
                 Company.Specializations = SpecializationList.Where(s => s.IsSelected).ToList();
                 con.Companies.Add(Company);
                 con.SaveChanges();
             }
         }

            ParentViewModel.Update();
            CloseWindow();
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
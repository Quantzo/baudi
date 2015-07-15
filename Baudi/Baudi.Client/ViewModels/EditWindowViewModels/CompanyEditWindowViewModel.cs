using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class CompanyEditWindowViewModel : EditWindowViewModel
    {
        
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
            : base(companiesTabViewModel, companyEditWindow, company)
        {

                using (var con = new BaudiDbContext())
                {
                    SpecializationList = con.Specializations.ToList();
                    if (Update)
                    {
                        Company = con.Companies.Find(company.CompanyID);                        
                        Company.Specializations.ForEach(s => s.IsSelected = true);
                    }
                    else
                    {
                        Company = new Company();
                    }
                }
            

        }



        public override void Save()
        {
         if(Update)
         {
             using (var con = new BaudiDbContext())
             {
                 var specializations = SpecializationList.Where(s => s.IsSelected).ToList();
                 specializations.ForEach(s => con.Specializations.Attach(s));

                 var company = con.Companies.Find(Company.CompanyID);
                 company.City = Company.City;
                 company.HouseNumber = Company.HouseNumber;
                 company.LocalNumber = Company.LocalNumber;
                 company.Name = Company.Name;
                 company.NIP = Company.NIP;
                 company.Owner = Company.Owner;


                 if (specializations.Count == 0)
                 {
                     company.Specializations.Clear();
                 }
                 else
                 {
                     company.Specializations = specializations;
                 }
                 company.Street = Company.Street;
                 company.TelephoneNumber = Company.TelephoneNumber;

                 con.Entry(company).State = EntityState.Modified;

                 con.SaveChanges();
             }

         }
         else
         {
             using (var con = new BaudiDbContext())
             {
                 var specializations = SpecializationList.Where(s => s.IsSelected).ToList();
                 specializations.ForEach(s => con.Specializations.Attach(s));

                 Company.Specializations = specializations;
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Data.Entity;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.Client.ViewModels.EditWindowViewModels;

namespace Baudi.Client.ViewModels.EditWindowCode
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
        public CompanyEditWindowViewModel(CompaniesTabViewModel companiesTabViewModel, CompanyEditWindow companyEditWindow, Company company)
            : base(companiesTabViewModel, companyEditWindow)
        {
            if (Company.CompanyID == 0)
            {
                using (var con = new BaudiDbContext())
                {
                    Company = con.Companies
                        .Include(c => c.Specializations)
                        .Find(company.CompanyID);
                }
            }
            else
            {
                Company = Company;
            }
        }



        public override void Save()
        {
         if(Company.CompanyID == 0)
         {
             using (var con = new BaudiDbContext())
             {
                 con.Companies.Add(Company);
                 con.SaveChanges();
             }
         }
         else
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
                 company.Street = Company.Street;
                 company.TelephoneNumber = Company.TelephoneNumber;
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
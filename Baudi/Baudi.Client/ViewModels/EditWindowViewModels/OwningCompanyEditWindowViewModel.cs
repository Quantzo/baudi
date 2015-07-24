using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.Client.ViewModels.TabsViewModels;
using Baudi.DAL;
using Baudi.DAL.Models;


namespace Baudi.Client.ViewModels.EditWindowViewModels
{
    public class OwningCompanyEditWindowViewModel : EditWindowViewModel
    {

        #region Properties
        private OwningCompany _owningCompany;
        public OwningCompany OwningCompany
        {
            get
            {
                return _owningCompany;
            }
            set
            {
                _owningCompany = value;
                OnPropertyChanged("OwningCompany");
            }
        }
        #endregion

        public OwningCompanyEditWindowViewModel(OwningCompaniesTabViewModel owningCompaniesTabViewModel, OwningCompanyEditWindow owningCompanyEditWindow, OwningCompany owningCompany)
            : base(owningCompaniesTabViewModel, owningCompanyEditWindow, owningCompany)
        {
            if (Update)
            {
                OwningCompany = new OwningCompany
                {
                    OwnerID = owningCompany.OwnerID,
                    Name = owningCompany.Name,
                    NIP = owningCompany.NIP,
                    City = owningCompany.City,
                    Street = owningCompany.Street,
                    HouseNumber = owningCompany.HouseNumber,
                    LocalNumber = owningCompany.LocalNumber,
                    Telephone = owningCompany.Telephone
                };
            }
            else
            {
                OwningCompany = new OwningCompany();
            }
        }

        public override bool IsValid()
        {
            return true;
        }

        public override void Save()
        {
            if (Update)
            {
                using (var con = new BaudiDbContext())
                {
                    var owningCompany = con.OwningCompanies.Find(OwningCompany.OwnerID);
                    owningCompany.Name = OwningCompany.Name;
                    owningCompany.NIP = OwningCompany.NIP;
                    owningCompany.City = OwningCompany.City;
                    owningCompany.Street = OwningCompany.Street;
                    owningCompany.HouseNumber = OwningCompany.HouseNumber;
                    owningCompany.LocalNumber = OwningCompany.LocalNumber;
                    owningCompany.Telephone = OwningCompany.Telephone;

                    con.Entry(owningCompany).State = EntityState.Modified;
                    con.SaveChanges();
                }
            }
            else
            {
                using (var con = new BaudiDbContext())
                {
                    con.OwningCompanies.Add(OwningCompany);
                    con.SaveChanges();
                }
            }

            ParentViewModel.Update();
            CloseWindow();
        }
    }
}

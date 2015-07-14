using Baudi.DAL;
using Baudi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Baudi.Client.ViewModels.TabsViewModels
{
    public class LocalsTabViewModel : TabViewModel
    {
        private List<Local> _localsList;

        public List<Local> LocalsList
        {
            get { return _localsList; }
            set
            {
                _localsList = value;
                OnPropertyChanged("LocalsList");
            }
        }

        public Local SelectedLocal { get; set; }

        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                LocalsList = con.Locals
                    .Include(l => l.Building)
                    .ToList();
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
                var local = con.Locals.Find(SelectedLocal.NotificationTargetID);
                local.Building = null;
                con.Notifications.RemoveRange(local.Notifactions);
                con.Ownerships.RemoveRange(local.Ownerships);
                con.Locals.Remove(local);
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
            if (SelectedLocal != null)
            {
                return true;
            }
            return false;
        }
    }
}

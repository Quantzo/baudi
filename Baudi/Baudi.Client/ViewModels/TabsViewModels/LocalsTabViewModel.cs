using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Baudi.Client.View.EditWindows;
using Baudi.DAL;
using Baudi.DAL.Models;

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

        /// <summary>
        /// Load action
        /// </summary>
        public override void Load()
        {
            using (var con = new BaudiDbContext())
            {
                LocalsList = con.Locals
                    .Include(l => l.Building)
                    .ToList();
            }
        }

        /// <summary>
        /// Add action
        /// </summary>
        public override void Add()
        {
            var localEditWindow = new LocalEditWindow(this, null);
            localEditWindow.Show();
        }

        /// <summary>
        /// Delete action
        /// </summary>
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

        /// <summary>
        /// Edit action
        /// </summary>
        public override void Edit()
        {
            var localEditWindow = new LocalEditWindow(this, SelectedLocal);
            localEditWindow.Show();
        }

        /// <summary>
        /// Check if item is selected
        /// </summary>
        /// <returns></returns>
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
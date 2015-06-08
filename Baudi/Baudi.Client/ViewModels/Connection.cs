using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Baudi.DAL;
using Baudi.DAL.Models;
using System.Windows.Input;

namespace Baudi.Client.ViewModels
{
    sealed class Connection
    {
        private static BaudiDbContext con = new BaudiDbContext();
        public static BaudiDbContext Con
        {
            get
            {
                return con;
            }
        }
    }
}

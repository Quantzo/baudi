using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.Client.Helpers
{
    static class FullNameHelper
    {
        public static string ToFullName(string name, string surname)
        {
            return name + " " + surname;
        }

    }
}

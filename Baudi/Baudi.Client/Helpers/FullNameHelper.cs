using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.Client.Helpers
{
    /// <summary>
    /// Full name helper
    /// </summary>
    static class FullNameHelper
    {
        /// <summary>
        /// Makes full name from name and surname
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <returns>Full name</returns>
        public static string ToFullName(string name, string surname)
        {
            return name + " " + surname;
        }

    }
}

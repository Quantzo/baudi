using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.Client.Helpers
{
    /// <summary>
    ///     Bool to text converter
    /// </summary>
    public static class ContextHelpHelper
    {
        /// <summary>
        /// Runs the help file
        /// </summary>
        public static void ContextHelp()
        {
            System.Diagnostics.Process.Start("help.chm");
        }
    }
}

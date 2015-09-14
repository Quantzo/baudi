using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.Client.Helpers
{
    public static class ContextHelpHelper
    {
        public static void ContextHelp()
        {
            System.Diagnostics.Process.Start("help.chm");
        }
    }
}

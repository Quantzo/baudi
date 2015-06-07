using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baudi.Client.ViewModels.Validation.Exceptions
{
    public class WrongDataException: Exception
    {
        public WrongDataException()
        {
        }

        public WrongDataException(string message)
            : base(message)
        {
        }
    }
}
